using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Common;
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
            try
            {
                if (Category1 == 0)
                    return _db.Category2s.OrderBy(cat => cat.Name).ToArray();
                return _db.Category2s.Where(cat => cat.ParentCategoryId == Category1).OrderBy(cat => cat.Name).ToArray();
            }
            catch(Exception ex)
            {
                Functions.UpdateErrorLog("Unable to Get Category 2 s", ex);
                return null;
            }
        }
        [HttpPost]
        public async Task<ActionResult<Category2>> PostCategory2(object category2)
        {
            JsonData jd = JsonMapper.ToObject(category2.ToString());
            Category2 c2 = new Category2()
            {
                ParentCategoryId = int.Parse(jd["Category1"].ToString()),
                Name = jd["Name"].ToString(),
                Description = jd["Description"].ToString(),
                TimeStamp = Functions.DateTime
            };
            _db.Category2s.Add(c2);
            await _db.SaveChangesAsync();
            await Task.Run(() => { Cache.RefreshCategory2(_db); });
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