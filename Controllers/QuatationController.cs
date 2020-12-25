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
    public class QuatationController : ControllerBase
    {
        private ApplicationDbContext _db;

        public QuatationController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(PurchaseRequest PurchaseRequest, Supplier Supplier, QuatationStatus Status, DateTime Date)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Quotations.Max((qt) => qt.Id);
            }
            catch
            {

            }
            Quotation qt = new Quotation()
            {
                Id = max_id + 1,
                //PurchaseRequest=PurchaseRequest,
                //Supplier1=Supplier,
                Status = Status,
                Date = Date

            };
            _db.Quotations.Add(qt);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, PurchaseRequest PurchaseRequest, Supplier Supplier, QuatationStatus Status, DateTime Date)
        {
            _db.Quotations.Update(new Quotation()
            {
                Id = Id,
                /*PurchaseRequest = PurchaseRequest,
                Supplier1 = Supplier,*/
                Status = Status,
                Date = Date
            });
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.Quotations.Remove(new Quotation() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
        
    }
}
