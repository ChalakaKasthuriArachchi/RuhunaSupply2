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
    public class QuotationItemController : ControllerBase
    {
        private ApplicationDbContext _db;

        public QuotationItemController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpPost]
        public IActionResult Add(Quotation Quatation, PurchaseRequestItem PurchaseRequestItem, Item Item, QuatationStatus Status, string IsSupply, string Description, int Qty, int Total, string Rate)
        {
            
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, Quotation Quatation, PurchaseRequestItem PurchaseRequestItem, Item Item, QuatationStatus Status, string IsSupply, string Description, int Qty, int Total, string Rate)
        {
           

            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.QuatationItems.Remove(new QuotationItem { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
