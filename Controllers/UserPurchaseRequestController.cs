using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class UserPurchaseRequestController : ControllerBase
    {
        private ApplicationDbContext _db;

        public UserPurchaseRequestController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(int UserId, int PurchaseRequestId)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Specification.Max((sp) => sp.Id);
            }
            catch
            {
            }

            UserPerchaseRequest upr = new UserPerchaseRequest()
            {
                Id = max_id + 1,
                UserId = UserId,
                PurchaseRequestId = PurchaseRequestId
            };

            _db.UserPerchaseRequests.Add(upr);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit(int Id, int UserId, int PurchaseRequestId)
        {
            _db.UserPerchaseRequests.Update(new UserPerchaseRequest() { Id = Id, UserId = UserId, PurchaseRequestId = PurchaseRequestId });
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.UserPerchaseRequests.Remove(new UserPerchaseRequest() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }

    }
}

