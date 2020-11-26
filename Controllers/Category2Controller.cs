using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category2Controller : Controller
    {
        private ApplicationDbContext _db;

        public Category2Controller(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet]
        public Category2[] GetCategory2s(int Category1)
        {
            if (Category1 == 0)
                return _db.Category2s.Include(cat => cat.ParentCategory).ToArray();
            return _db.Category2s.Where(cat => cat.ParentCategory.Id == Category1).Include(cat => cat.ParentCategory).ToArray();
        }
        [HttpPost]
        public async Task<ActionResult<Category2>> PostCategory2(object category2)
        {
            JsonData jd = JsonMapper.ToObject(category2.ToString());
            Category2 c2 = new Category2()
            {
                ParentCategory = _db.Category1s
                    .FirstOrDefault(c => c.Id == int.Parse(jd["Category1"].ToString())),
                Name = jd["Name"].ToString(),
                Description = jd["Description"].ToString(),
                

            };
            _db.Category2s.Add(c2);
            await _db.SaveChangesAsync();

            return CreatedAtAction("Category2", new { id = c2.Id }, c2);
        }


        //[HttpPut]
        //public IActionResult Edit(int Id, int PId, string Name, string Description)
        //{
        //    _db.Category2s.Update(new Category2()
        //    {
        //        //Id = Id,
        //        //PId = PId,
        //        //Name = Name,
        //        //Description = Description
        //    });
        //    _db.SaveChanges();
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult Delete(int Id)
        //{
        //    _db.Category2s.Remove(new Category2() { Id = Id });
        //    _db.SaveChanges();
        //    return Ok();
        //}

    }
}