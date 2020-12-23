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
        public IActionResult Add(Quotation Quatation, PurchaseRequestItem PurchaseRequestItem, Item Item, QuatationStatus Status, string IsSupply, string Description, int Qty, int Total, string Rate)
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
                //Quatation=Quatation,
                //PurchaseRequestItem=PurchaseRequestItem,
                //Item=Item,
                Status =Status,
                //IsSupply=IsSupply,
                Description=Description,
                Qty = Qty,
                Total = Total,
                //Rate = Rate
            };

            _db.QuatationItems.Add(qt);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, Quotation Quatation, PurchaseRequestItem PurchaseRequestItem, Item Item, QuatationStatus Status, string IsSupply, string Description, int Qty, int Total, string Rate)
        {
            //_db.QuatationItems.Update(new QuatationItem { Id = Id, Quatation = Quatation, PurchaseRequestItem = PurchaseRequestItem, Item = Item, Status = Status, IsSupply = IsSupply, Description = Description,Qty=Qty, Total=Total, Rate=Rate});
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
