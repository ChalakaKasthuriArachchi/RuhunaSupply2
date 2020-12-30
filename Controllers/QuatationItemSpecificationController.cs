using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class QuatationItemSpecificationController : ControllerBase
    {
        private ApplicationDbContext _db;

        public QuatationItemSpecificationController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(QuotationItem QuatationItem, Specification Specification, string Satisfied, string Description)
        {
            int max_id = 0;
            try
            {
                max_id = _db.QuotationItemSpecification.Max((qis) => qis.Id);
            }
            catch
            {
            }

            QuotationItemSpecification qis = new QuotationItemSpecification()
            {
                Id = max_id,
                
            };
            _db.QuotationItemSpecification.Add(qis);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit(int Id, QuotationItem QuatationItem, Specification Specification, string Satisfied, string Description)
        {
           
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            //_db.QuotationItemSpecification.Remove(new _QuatationItemSpecification() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}

