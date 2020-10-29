using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class CategoryController : ControllerBase
    {
        private ApplicationDbContext _db;
        
        public CategoryController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpPost]
        public IActionResult Add1(string Name,string Description)
        {
            int max_id = 0;
            try{ max_id = _db.Category1.Max((cat) => cat.Id);} catch { }
            Category1 cat = new Category1()
            {
                Id = max_id + 1,
                Name = Name,
                Description = Description
            };
            _db.Category1.Add(cat);
            _db.SaveChanges();
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Edit1(int Id,string Name, string Description)
        {
            _db.Category1.Update(
                new Category1() { Id = Id, Name = Name, Description = Description });
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete1(int Id)
        {
            _db.Category1.Remove(new Category1() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Add2(int PId,string Name, string Description)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Category2.Max((cat2) => cat2.Id);
            }
            catch { }

            Category2 cat2= new Category2()
            {
                Id = max_id + 1,
                PId=PId,
                Name = Name,
                Description = Description
            };
            _db.Category2.Add(cat2);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit2(int Id, int PId, String Name, String Description)
        {
            _db.Category2.Update(new Category2()
            {
                Id = Id,
                PId = PId,
                Name = Name,
                Description = Description
            });
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete2(int Id,int PId,String Name,String Description)

        {
            _db.Category2.Remove(new Category2 { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Add3(int PId,int GpId,String Name,String Description)
        {
            int max_id = 0;
            try 
            { 
                max_id = _db.Category3.Max((cat3) => cat3.Id); 
            } catch { }

            Category3 cat3 = new Category3()
            {
                Id = max_id + 1,
                PId = PId,
                GpId = GpId,
                Name = Name,
                Description = Description
            };
            _db.Category3.Add(cat3);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit3(int Id,int PId,int GpId,String Name,String Description)
        {
            _db.Category3.Update(new Category3()
            {
                Id = Id,
                PId = PId,
                GpId = GpId,
                Name = Name,
                Description = Description
            });
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete3(int Id,int PId,int GpId,String Name,String Description)
        {
            _db.Category3.Remove(new Category3 { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}