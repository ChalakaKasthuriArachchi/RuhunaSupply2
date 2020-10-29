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
        public IActionResult Add(QuatationItem QuatationItem, Specification Specification, string Satisfied, string Description)
        {
            int max_id = 0;
            try
            {
                max_id = _db.QuatationItemSpecifications.Max((qis) => qis.Id);
            }
            catch
            {
            }

            QuatationItemSpecification qis = new QuatationItemSpecification()
            {
                Id = max_id,
                QuatationItem = QuatationItem,
                Specification = Specification,
                Satisfied = Satisfied,
                Description = Description
            };
            _db.QuatationItemSpecifications.Add(qis);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit(int Id, QuatationItem QuatationItem, Specification Specification, string Satisfied, string Description)
        {
            _db.QuatationItemSpecifications.Update(new QuatationItemSpecification()
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
            _db.QuatationItemSpecifications.Remove(new QuatationItemSpecification() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}

