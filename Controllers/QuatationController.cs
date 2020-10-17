using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class QuatationController : ControllerBase
    {
        private ApplicationDbContext _db;

        public QuatationController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(string Status, DateTime Date)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Quatations.Max((qt) => qt.Id);
            }
            catch
            {

            }
            Quatation qt = new Quatation()
            {
                Id = max_id + 1,
                Status = Status,
                Date = Date

            };
            _db.Quatations.Add(qt);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Status, DateTime Date)
        {
            _db.Quatations.Update(new Quatation()
            {
                Id = Id,
                Status = Status,
                Date = Date
            });
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.Quatations.Remove(new Quatation() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
        
    }
}
