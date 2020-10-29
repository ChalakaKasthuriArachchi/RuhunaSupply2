using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class SpecificationController : ControllerBase
    {
        private ApplicationDbContext _db;

        public SpecificationController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(Item ItemId, SpecificationCategory SpecificationCategoryId, string Name, string Value)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Specification.Max((sp) => sp.Id);
            }
            catch
            {
            }

            Specification sp = new Specification()
            {
                Id = max_id + 1,
                SpecificationCategoryId= SpecificationCategoryId,
                ItemId =ItemId,
                Name = Name,
                Value=Value
            };
            _db.Specification.Add(sp);
            _db.SaveChanges();
            return Ok();
        }



        [HttpPost]
        public IActionResult Edit(int Id, SpecificationCategory SpecificationCategoryId, Item ItemId, string Name, string Value)
        {
            _db.Specification.Update(
                new Specification() { Id = Id, SpecificationCategoryId= SpecificationCategoryId, ItemId = ItemId, Name = Name, Value = Value });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]

        public IActionResult Delete(int Id)
        {
            _db.Specification.Remove(new Specification() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
 
    }
}