using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class Category3Controller : Controller
    {

        private ApplicationDbContext _db;

        public Category3Controller(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(int PId, int GpId, string Name, string Description)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Category3s.Max((ct) => ct.Id);
            }
            catch
            {
            }

            Category3 ct = new Category3()
            {
                //Id = max_id,
                //PId = PId,
                //GpId = GpId,
                //Name = Name,
                //Description = Description
            };

            _db.Category3s.Add(ct);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, int PId, int GpId, string Name, string Description)
        {
            _db.Category3s.Update(new Category3()
            {
                //Id = Id,
                //PId = PId,
                //GpId = GpId,
                //Name = Name,
                //Description = Description
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.Category3s.Remove(new Category3() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }

    }
}