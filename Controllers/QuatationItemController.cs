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
    public class QuatationItemController : ControllerBase
    {
        private ApplicationDbContext _db;

        public QuatationItemController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpPost]
        public IActionResult Add(int QuatationId, int PurchaseRequestItemId, int ItemId, QuatationStatus Status, string IsSupply, string Description)
        {
            int max_id = 0;

            try
            {
                max_id = _db.QuatationItems.Max((qt) => qt.Id);
            }
            catch
            {

                
            }

            QuatationItem qt = new QuatationItem()
            {
                Id = max_id + 1,
                QuatationId=QuatationId,
                PurchaseRequestItemId=PurchaseRequestItemId,
                ItemId=ItemId,
                Status =Status,
                IsSupply=IsSupply,
                Description=Description
            };

            _db.QuatationItems.Add(qt);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, int QuatationId, int PurchaseRequestItemId, int ItemId, QuatationStatus Status, string IsSupply, string Description)
        {
            _db.QuatationItems.Update(new QuatationItem { Id = Id, QuatationId = QuatationId,PurchaseRequestItemId = PurchaseRequestItemId,ItemId = ItemId,Status = Status, IsSupply = IsSupply, Description = Description });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.QuatationItems.Remove(new QuatationItem { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
