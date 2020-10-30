using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class Category2Controller : Controller
    {
        private ApplicationDbContext _db;

        public Category2Controller(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(int PId, string Name, string Description)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Category2s.Max((ct) => ct.Id);
            }
            catch
            {
            }

            Category2 ct = new Category2()
            {
                //Id = max_id,
                //PId=PId,
                //Name = Name,
                //Description = Description
            };

            _db.Category2s.Add(ct);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, int PId, string Name, string Description)
        {
            _db.Category2s.Update(new Category2()
            {
                //Id = Id,
                //PId = PId,
                //Name = Name,
                //Description = Description
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.Category2s.Remove(new Category2() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }

    }
}