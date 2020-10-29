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
        public IActionResult Add(Item Item, SpecificationCategory SpecificationCategory, string Name, string Value)
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
                SpecificationCategory= SpecificationCategory,
                Item =Item,
                Name = Name,
                Value=Value
            };
            _db.Specification.Add(sp);
            _db.SaveChanges();
            return Ok();
        }



        [HttpPost]
        public IActionResult Edit(int Id, SpecificationCategory SpecificationCategory, Item Item, string Name, string Value)
        {
            _db.Specification.Update(
                new Specification() { Id = Id, SpecificationCategory= SpecificationCategory, Item = Item, Name = Name, Value = Value });
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