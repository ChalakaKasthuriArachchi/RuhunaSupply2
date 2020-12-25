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
            int userId = Functions.GetCurrentUserId(Request.HttpContext, _db);
            var data = _db.UserAccounts.Where(u => u.Id == userId)
                .Join(
                    _db.UserPurchaseRequests,
                    user => user.Id,
                    upr => upr.User.Id,
                    (user, upr) => new
                    {
                        PurchaseRequestId = upr.PurchaseRequestId
                    }
                ).
                Join(
                    _db.PurchaseRequests/*.Include(pr => pr.Department)
                        .Include(pr => pr.Faculty)*/,
                    upr => upr.PurchaseRequestId,
                    pr => pr.Id,
                    (upr, pr) => new ViewPurchaseRequest
                    {
                        DateTime = pr.DateTime,
                        Department = pr.Department.Name,
                        Faculty = pr.Faculty.Name,
                        Id = pr.Id,
                        Purpose = pr.Purpose.ToString(),
                        _Status = (int)pr.Status,
                        Status = pr.Status.ToString().Replace("_", " "),
                        _ExaminigId = pr.ExaminigId,
                        _SubmittedById = pr.SubmittedById
                    }
                );
            if (status >= 0)
                data = data.Where(a => a._Status == status);
            var res = data.ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                res[i].Examining = Cache.GetUser(res[i]._ExaminigId,true).FullName;
                res[i].SubmittedBy = Cache.GetUser(res[i]._SubmittedById, true).FullName;
            }
            //string json = JsonSerializer.Serialize(res[0]);
            return res;
        }
        [HttpPost]
        public IActionResult PostPurchaseRequest(object req)
        {
            try
            {
                UserAccount useraccount = Functions.GetCurrentUser(Request.HttpContext, _db);
                User user = Cache.GetUser(useraccount.Id, false);
                if (user == null)
                    throw new Exception("User Not Found");
                using (IDbContextTransaction trans = _db.Database.BeginTransaction())
                {
                    JsonData jd = JsonMapper.ToObject(req.ToString());
                    JsonData jform = jd["form"];
                    JsonData forwardTo = jd["forwardTo"];
                    PurchaseRequest pr = new PurchaseRequest()
                    {
                        FundGoes = jform["Funds"].ToString(),
                        Project = jform["Project"].ToString(),
                        DepartmentId = user.DepartmentId,
                        FacultyId = user.FacultyId,
                        IsInProcumentPlan = jform["IsInProcumentPlan"].ToString() == "Yes",
                        Purpose = (Purposes)int.Parse(jform["Purpose"].ToString()),
                        Justification = jform["Justification"].ToString(),
                    };
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
                            PurchaseRequestItem pri = new PurchaseRequestItem()
                            {
                                //Id = pri_Id++,
                                PurchaseRequestId = pr.Id,
                                ItemId = int.Parse(ji["id"].ToString()),
                                QtyRequired = double.Parse(ji["quantity"].ToString()),
                            };
                            _db.PurchaseRequestItems.Add(pri);
                            int specCat = int.Parse(ji["specificationCategoryId"].ToString());
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
                        _db.UserPurchaseRequests.Add(
                            new UserPurchaseRequest()
                            {
                              Date = Functions.DateTime,
                              Involvement = Involvements.Submitted
                            });
                    }
                    else // Existing Purchase Request
                    { 
                        pr.Id = int.Parse(jform["Id"].ToString());
                        _db.UserPurchaseRequests.Add(
                            new UserPurchaseRequest()
                            {
                                Date = Functions.DateTime,
                                Involvement = Involvements.Approved_and_Forwarded
                            });
                        _db.PurchaseRequests.Update(pr);
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
            List<User> lst = new List<User>(); 
            int userId = Functions.GetCurrentUserId(Request.HttpContext, _db);
            User user = Cache.GetUser(userId, true);
            int headId = user.Department.GetHead(_db).Id;
            int deanId = user.Faculty.GetDean(_db).Id;
            if (user.Id != headId && user.MergedId != user.Id)
                lst.Add(user.Department.GetHead(_db));
            if (user.TestPrivileges(Model.User.UserPrivileges.PurchaseRequest_Forward_Outside_Department) 
                && user.Id != headId && user.MergedId != user.Id)
                lst.Add(user.Faculty.GetDean(_db));
            if (user.TestPrivileges(Model.User.UserPrivileges.PurchaseRequest_Forward_Outside_Faculty))
            {
                lst.Add(Cache.Users.FirstOrDefault(u => u.Position == UserPositions.VC));
                lst.Add(Cache.Users.FirstOrDefault(u => 
                    u.Position == UserPositions.SAB 
                    && u.Department.Name == DepartmentsAdmin.Supply_Branch.ToString().Replace("_", " ")));
            }
            return lst;
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
