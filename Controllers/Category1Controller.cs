using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class Category1Controller : ControllerBase
    {
        private ApplicationDbContext _db;

        public Category1Controller(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(string Name, string Description)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Category1s.Max((ct) => ct.Id);
            }
            catch
            {
            }

            Category1 ct = new Category1()
            {
                Id = max_id,
                Name = Name,
                Description = Description
            };

            _db.Category1s.Add(ct);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Name, string Description)
        {
            _db.Category1s.Update(new Category1()
            {
                Id = Id,
                Name = Name,
                Description = Description
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.Category1s .Remove(new Category1() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }

    }
}
