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
                max_id = _db.QuatationItemSpecification.Max((qis) => qis.Id);
            }
            catch
            {
            }

            _QuatationItemSpecification qis = new _QuatationItemSpecification()
            {
                Id = max_id,
                QuatationItem = QuatationItem,
                Specification = Specification,
                Satisfied = Satisfied,
                Description = Description
            };
            _db.QuatationItemSpecification.Add(qis);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit(int Id, QuotationItem QuatationItem, Specification Specification, string Satisfied, string Description)
        {
            _db.QuatationItemSpecification.Update(new _QuatationItemSpecification()
            {
                Id = Id,
                QuatationItem = QuatationItem,
                Specification = Specification,
                Satisfied = Satisfied,
                Description = Description
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.QuatationItemSpecification.Remove(new _QuatationItemSpecification() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}

