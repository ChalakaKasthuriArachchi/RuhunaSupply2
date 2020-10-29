using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{
    public class UserPurchaseRequestController : ControllerBase
    {
        private ApplicationDbContext _db;

        public UserPurchaseRequestController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(User UserId, int PurchaseRequestId, DateTime Date, Involvements Involvement)
        {
            int max_id = 0;
            try
            {
                max_id = _db.UserPurchaseRequests.Max((upr) => upr.Id);
            }
            catch
            {
            }

            UserPurchaseRequest upr = new UserPurchaseRequest()
            {
                Id = max_id + 1,
                UserId = UserId,
                PurchaseRequestId = PurchaseRequestId,
                Date = Date,
                Involvement = Involvement
            };

            _db.UserPurchaseRequests.Add(upr);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit(int Id, User UserId, int PurchaseRequestId, DateTime Date, Involvements Involvement)
        {
            _db.UserPurchaseRequests.Update(new UserPurchaseRequest() { Id = Id, UserId = UserId, PurchaseRequestId = PurchaseRequestId ,Date = Date,Involvement = Involvement});
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.UserPurchaseRequests.Remove(new UserPurchaseRequest() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }

    }
}

