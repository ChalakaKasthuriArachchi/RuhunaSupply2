using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class ItemController : ControllerBase // get Base because not view this
    {
        private ApplicationDbContext _db;

        public ItemController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpPost]
        public IActionResult Add(string Name, string Description, Category1 Category1, Category2 Category2, Category3 Category3)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Item.Max((it) => it.Id);
            }
            catch
            {
            }
            
            Item it = new Item()
            {
                Id = max_id + 1,
                Name = Name,
                Description = Description,
                Category1 = Category1,
                Category2 = Category2,
                Category3 = Category3
            };
            _db.Item.Add(it);
            _db.SaveChanges();
            return Ok();
        }

        //  public IActionResult Index()
        // {
        //     return View();
        // }

        [HttpPost]
        public IActionResult Edit(int id, string Name, string Description, Category1 Category1, Category2 Category2, Category3 Category3)
        {
            _db.Item.Update(
                new Item() { Id = id, Name = Name, Description = Description, Category1 = Category1, Category2 = Category2, Category3 = Category3 });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            _db.Item.Remove(new Item() { Id = id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
