using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using Microsoft.AspNetCore.Http.Features;

namespace RuhunaSupply.Controllers
{
    public class PurchaseRequestItemController : ControllerBase
    {
        private ApplicationDbContext _db;

        public PurchaseRequestItemController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpPost]
        public IActionResult Add(double Cost, int QtyRequired, int QtySupplied, double Rate, double TotalValue, PurchaseRequest PurchaseRequestId, Item ItemId)
        {
            int max_id = 0;
            try
            {
                max_id = _db.PurchaseRequestItems.Max((pri) => pri.Id);
                //max_id = _db.Items.Max((pri) => pri.Id);
            }
            catch
            {
            }

            PurchaseRequestItem pri = new PurchaseRequestItem()
            {
                Id = max_id + 1,
                EstimatedCost=Cost,
                QtyRequired=QtyRequired,
                QtySupplied =QtySupplied,
                Rate=Rate,
                TotalValue=TotalValue,
                PurchaseRequestId=PurchaseRequestId,
                ItemId=ItemId

            };

            _db.PurchaseRequestItems.Add(pri);
            _db.SaveChanges();
            return Ok();
        }



        [HttpPost]
        public IActionResult Edit(double Cost, int QtyRequired, int QtyAlreadyAvailable, int QtySupplied, double Rate, double TotalValue, PurchaseRequest PurchaseRequestId, Item ItemId)
        {
            
            _db.PurchaseRequestItems.Update(
                new PurchaseRequestItem(){EstimatedCost = Cost,QtyRequired = QtyRequired, QtySupplied = QtySupplied,Rate = Rate,TotalValue = TotalValue,PurchaseRequestId = PurchaseRequestId , ItemId=ItemId });
            _db.SaveChanges();
            return Ok();
        }

       [HttpPost]

    

        public IActionResult Delete(int id)
        {
            _db.PurchaseRequestItems.Remove(new PurchaseRequestItem() { Id = id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
