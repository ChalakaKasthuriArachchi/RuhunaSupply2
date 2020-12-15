﻿using System;
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
                using (DbTransaction trans = _db.Database.BeginTransaction() as DbTransaction)
                {
                    JsonData jd = JsonMapper.ToObject(req.ToString());
                    JsonData jform = jd["form"];
                    PurchaseRequest pr = new PurchaseRequest()
                    {
                        Id = PurchaseRequest.GetNextId(_db),
                        FundGoes = jform["Funds"].ToString(),
                        Project = jform["Project"].ToString(),
                        //_DateTime = DateTime.Parse(jform["DateTime"].ToString()),
                        
                    };
                    _db.PurchaseRequests.Add(pr);
                    foreach (JsonData ji in jd["items"])
                    {
                        _db.PurchaseRequestItems.Add(
                            new PurchaseRequestItem()
                            {
                                ItemId = int.Parse(ji["id"].ToString()),
                                QtyRequired = double.Parse(ji["quantity"].ToString()),
                            }
                            );
                    }
                }
                return Ok();
            }
            catch(Exception ex)
            {
                Functions.UpdateErrorLog("Unable to Save Purchase Request", ex);
                return BadRequest();
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
