using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class SpecificationCategoryController : ControllerBase
    {
        private ApplicationDbContext _db;

        public SpecificationCategoryController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(Item Item, string Title, string Description)
        {
            int max_id = 0;
            try
            {
                max_id = _db.SpecificationCategories.Max((sp) => sp.Id);
            }
            catch
            {
            }

            SpecificationCategory sp = new SpecificationCategory()
            {
                Id = max_id,
                Item=Item,
                Title=Title,
                Descriptiopn=Description
            };

            _db.SpecificationCategories.Add(sp);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit(int Id, Item Item, string Title, string Description)
        {
            _db.SpecificationCategories.Update(new SpecificationCategory() { Id=Id, Item=Item, Title=Title, Descriptiopn=Description});
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.SpecificationCategories.Remove(new SpecificationCategory() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
