using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Common;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using static RuhunaSupply.Common.MyEnum;
using RuhunaSupply;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;
using ThirdParty.Json.LitJson;
using System.Data.Common;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PurchaseRequestController : ControllerBase
    {
        private ApplicationDbContext _db;

        public PurchaseRequestController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet]
        public ViewPurchaseRequest[] GetPurchaseRequests(int status)
        {
            try
            {
                int userId = Functions.GetCurrentUserId(Request.HttpContext, _db);
                var data = _db.UserPurchaseRequests.Where(upr => upr.UserId == userId);
                UserPurchaseRequest[] uprs = data.ToArray();
                ViewPurchaseRequest[] vprS = new ViewPurchaseRequest[uprs.Length];
                for(int x = 0; x < uprs.Length; x++)
                {
                    PurchaseRequest pr = _db.PurchaseRequests.Find(uprs[x].PurchaseRequestId);
                    if(pr != null && (status == -1 || (int)pr.Status == status))
                    {
                        vprS[x] = new ViewPurchaseRequest()
                        {
                            DateTime = pr.DateTime,
                            Department = pr.Department.Name,
                            Faculty = pr.Faculty.Name,
                            Id = pr.Id,
                            Purpose = pr.Purpose.ToString(),
                            _Status = (int)pr.Status,
                            Status = pr.Status.ToString().Replace("_", " "),
                            _ExaminigId = pr.ExaminigId,
                            _SubmittedById = pr.SubmittedById,
                            Examining = Cache.GetUser(pr.ExaminigId, true).FullName,
                            SubmittedBy = Cache.GetUser(pr.SubmittedById, true).FullName
                        };
                    }
                     
                }
                return vprS;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet("callquotations/{id}")]
        public IActionResult CallQuotations(int id)
        {
            try
            {
                Supplier[] suppliers = _db.Suppliers./*Where(sup => sup.Category2Id)*/
                    ToArray();
                PurchaseRequest pr = _db.PurchaseRequests.Include(pr => pr.Items).FirstOrDefault(pr => pr.Id == id);
                pr.Status = PurchaseRequestStatus.Done;
                _db.PurchaseRequests.Update(pr);
                int qid = Quotation.GetNextId(_db);
                foreach (var sup in suppliers)
                {
                    Quotation quotation = new Quotation()
                    {
                        Id = qid++,
                        Date = Functions.DateTime,
                        PurchaseRequestId = id,
                        Status = QuatationStatus.Pending,
                        SupplierId = sup.Id
                    };
                    foreach (var item in pr.Items)
                    {
                        PurchaseRequestItemSpecification[] specifications = 
                            _db.PurchaseRequestItemSpecifications.
                                Where(spec => spec.PurchaseRequestItemId == item.Id).ToArray();
                        List<QuotationItemSpecification> qis = new List<QuotationItemSpecification>(specifications.Length);
                        foreach (var spec in specifications)
                        {
                            qis.Add(new QuotationItemSpecification()
                            {
                                ItemId = item.Id,
                                PurchaseRequestItemSpecificationId = spec.Id,
                            });
                        }
                        quotation.QuotationItems.Add(new QuotationItem()
                        {
                             ItemId = item.ItemId,
                             PurchaseRequestItemId = item.Id,
                             Qty = item.QtyRequired,
                             QuotationId = quotation.Id,
                             Specifications = qis
                        });
                    }
                    _db.Quotations.Add(quotation);
                }
                using(var trans = _db.Database.BeginTransaction())
                {
                    try
                    {
                        _db.SaveChanges();
                        trans.Commit();
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult PostPurchaseRequest(object req)
        {
            try
            {
                User user = Functions.GetCurrentUser(Request.HttpContext, _db);
                //User user = Cache.GetUser(useraccount.Id, false);
                if (user == null)
                    throw new Exception("User Not Found");
                using (IDbContextTransaction trans = _db.Database.BeginTransaction())
                {
                    JsonData jd = JsonMapper.ToObject(req.ToString());
                    JsonData jform = jd["form"];
                    JsonData forwardTo = jd["forwardTo"];
                    
                    PurchaseRequest pr = null;
                    if (jform["Id"].ToString() == "0")
                        pr = new PurchaseRequest();
                    else
                        pr = _db.PurchaseRequests.Find(int.Parse(jform["Id"].ToString()));
                    
                    pr.FundGOSL = jform["Funds"].ToString();
                    pr.Project = jform["Project"].ToString();
                    pr.DepartmentId = user.DepartmentId;
                    pr.FacultyId = user.FacultyId;
                    pr.IsInProcumentPlan = jform["IsInProcumentPlan"].ToString() == "Yes";
                    pr.Purpose = (Purposes)int.Parse(jform["Purpose"].ToString());
                    pr.Justification = jform["Justification"].ToString();
                    pr.ExaminigId = int.Parse(forwardTo.ToString());

                    if (jform["Id"].ToString() == "0") //New Purchase Request
                    {
                        pr.Id = PurchaseRequest.GetNextId(_db);
                        pr.Status = PurchaseRequestStatus.On_Approval;
                        pr.SubmittedById = user.Id;
                        pr.ExaminigId = int.Parse(forwardTo.ToString());
                        pr._DateTime = Functions.DateTime;
                        _db.PurchaseRequests.Add(pr);
                        //int pri_Id = PurchaseRequestItem.GetNextId(_db);
                        foreach (JsonData ji in jd["items"])
                        {
                            int specCat = int.Parse(ji["specificationCategoryId"].ToString());
                            PurchaseRequestItem pri = new PurchaseRequestItem()
                            {
                                //Id = pri_Id++,
                                PurchaseRequestId = pr.Id,
                                ItemId = int.Parse(ji["id"].ToString()),
                                QtyRequired = double.Parse(ji["quantity"].ToString()),
                                SpecificationCategoryId = specCat
                            };
                            _db.PurchaseRequestItems.Add(pri);
                            Specification[] specs = _db.Specification.Where(spec => spec.SpecificationCategoryId == specCat).ToArray();
                            foreach (var spec in specs)
                            {
                                pri.Specifications.Add(new PurchaseRequestItemSpecification()
                                {
                                    ItemId = pri.ItemId,
                                    Name = spec.Name,
                                    Value = spec.Value
                                });
                            }
                        }
                        _db.UserPurchaseRequests.AddRange(
                            new UserPurchaseRequest()
                            {
                                PurchaseRequestId = pr.Id,
                                UserId = user.Id,
                                Date = Functions.DateTime,
                                Involvement = Involvements.Submitted
                            },
                            new UserPurchaseRequest()
                            {
                                PurchaseRequestId = pr.Id,
                                UserId = pr.ExaminigId,
                                Date = Functions.DateTime,
                                Involvement = Involvements.On_Approval
                            });
                    }
                    else
                    {
                        UserPurchaseRequest upr =
                            _db.UserPurchaseRequests.FirstOrDefault(
                                upr => upr.PurchaseRequestId == pr.Id
                                   && upr.UserId == user.Id);
                        upr.Date = Functions.DateTime;
                        upr.Involvement = Involvements.Approved_and_Forwarded;
                        _db.UserPurchaseRequests.Update(upr);
                        _db.PurchaseRequests.Update(pr);
                        _db.UserPurchaseRequests.Add(new UserPurchaseRequest()
                        {
                            PurchaseRequestId = pr.Id,
                            UserId = pr.ExaminigId,
                            Date = Functions.DateTime,
                            Involvement = Involvements.On_Approval
                        });
                    }
                    try
                    {
                        _db.SaveChanges();
                        trans.Commit();
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
                return Ok();
            }
            catch(Exception ex)
            {
                Functions.UpdateErrorLog("Unable to Save Purchase Request", ex);
                return BadRequest("Unable to Save Purchase Request now");
            }
        }
        [HttpGet("allowedforwards")]
        public List<User> GetAllowedForwards()
        {
            int headId = 0, deanId = 0;
            List<User> lst = new List<User>(); 
            int userId = Functions.GetCurrentUserId(Request.HttpContext, _db);
            User user = Cache.GetUser(userId, true);
            var head = user.Department.GetHead(_db);
            var dean = user.Faculty.GetDean(_db);
            if (head != null)
                headId = head.Id;
            if (dean != null)
                deanId = dean.Id;
            if (user.TestPrivileges(Model.User.UserPrivileges.PurchaseRequest_Forward_Outside_Faculty))
            {
                lst.Add(Cache.Users.FirstOrDefault(u => u.Position == UserPositions.VC));
                lst.Add(Cache.Users.FirstOrDefault(u =>
                    u.Position == UserPositions.SAB
                    && u.Department.Name == DepartmentsAdmin.Supply_Branch.ToString().Replace("_", " ")));
            }
            else
            {
                if (user.TestPrivileges(Model.User.UserPrivileges.PurchaseRequest_Forward_Outside_Department))
                {
                    lst.Add(user.Faculty.GetDean(_db));
                }
                else
                {
                    lst.Add(user.Department.GetHead(_db));
                }
            }
            foreach (var item in lst)
                if (item.Id == user.Id)
                    lst.Remove(item);
            //if (user.Id != headId && user.MergedId != user.Id)
            //    lst.Add(user.Department.GetHead(_db));
            //if (user.TestPrivileges(Model.User.UserPrivileges.PurchaseRequest_Forward_Outside_Department) 
            //    && user.Id != deanId && user.MergedId != user.Id)
            //    lst.Add(user.Faculty.GetDean(_db));
            //if (user.TestPrivileges(Model.User.UserPrivileges.PurchaseRequest_Forward_Outside_Faculty))
            //{
            //    lst.Add(Cache.Users.FirstOrDefault(u => u.Position == UserPositions.VC));
            //    lst.Add(Cache.Users.FirstOrDefault(u => 
            //        u.Position == UserPositions.SAB 
            //        && u.Department.Name == DepartmentsAdmin.Supply_Branch.ToString().Replace("_", " ")));
            //}
            return lst;
        }
        [HttpGet("{id}")]
        public object GetPurchaseRequest(int id)
        {
            try
            {
                int userId = Functions.GetCurrentUserId(Request.HttpContext, _db);
                var data = _db.UserPurchaseRequests.Where(upr => upr.UserId == userId
                    && upr.PurchaseRequestId == id);
                UserPurchaseRequest upr = data.FirstOrDefault();
                if (upr == null)
                    throw new UnauthorizedAccessException();
                var pr = _db.PurchaseRequests
                        .Include(pr => pr.Items).FirstOrDefault(pr => pr.Id == id);
                object[] items = new object[pr.Items.Count];
                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = new
                    {
                        item = pr.Items[i].Item,
                        name = pr.Items[i].Item.Name,
                        category2 = pr.Items[i].Item.Category2,
                        specificationCategoryName = pr.Items[i].SpecificationCategory.Title,
                        quantity = pr.Items[i].QtyRequired
                    };
                }
                return new { 
                    purchaseRequest = pr,
                    route = _db.UserPurchaseRequests.Where(
                        upr => upr.PurchaseRequestId == id),
                    items = items
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    public class ViewPurchaseRequest
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Faculty { get; set; }
        public string DateTime { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
        public string Examining { get; set; }
        public string SubmittedBy { get; set; }
        internal int _Status;
        internal int _ExaminigId;
        internal int _SubmittedById;
    }
}
