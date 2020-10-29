using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class PurchaseRequestItemSpecificationController : ControllerBase
    {
        private ApplicationDbContext _db;
        public PurchaseRequestItemSpecificationController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(PurchaseRequestItem PurchaseRequestItem, Specification Specification)
        {
            int max_id = 0;
            try
            {
                max_id = _db.PurchaseRequestItemSpecifications.Max((pris) => pris.Id);
            }
            catch
            {
            }
            PurchaseRequestItemSpecification pris = new PurchaseRequestItemSpecification()
            {
                Id = max_id,
                PurchaseRequestItem = PurchaseRequestItem,
                Specification = Specification
            };
            _db.PurchaseRequestItemSpecifications.Add(pris);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, PurchaseRequestItem PurchaseRequestItem, Specification Specification)
        {
            _db.PurchaseRequestItemSpecifications.Update(new PurchaseRequestItemSpecification()
            {

                Id = Id,
                PurchaseRequestItem = PurchaseRequestItem,
                Specification = Specification
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.PurchaseRequestItemSpecifications.Remove(new PurchaseRequestItemSpecification() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
