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
    
    public class Category3Controller : Controller
    {

        private ApplicationDbContext _db;

        public Category3Controller(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet]
        public Category3[] GetCategory3s(int Category2)
        {
            IQueryable<Category3> query = _db.Category3s;
            if (Category2 == 0)
                return query.OrderBy(cat => cat.Name).ToArray();
            return query.Where(cat => cat.ParentCategoryId == Category2).OrderBy(cat => cat.Name).ToArray();
        }
        [HttpPost]
        public async Task<ActionResult<Category3>> PostCategory3(object category3)
        {
            JsonData jd = JsonMapper.ToObject(category3.ToString());
            Category3 c3 = new Category3()
            {
                GPCategoryId = int.Parse(jd["Category1"].ToString()),
                ParentCategoryId = int.Parse(jd["Category2"].ToString()),
                Name = jd["Name"].ToString(),
                Description = jd["Description"].ToString(),
            };
            _db.Category3s.Add(c3);
            await _db.SaveChangesAsync();
            await Task.Run(() => { Cache.RefreshCategory3(_db); });
            return CreatedAtAction("Category3", new { id = c3.Id }, c3);
        }

        //[HttpPut]
        //public IActionResult Edit(int Id, int PId, int GpId, string Name, string Description)
        //{
        //    _db.Category3s.Update(new Category3()
        //    {
        //        //Id = Id,
        //        //PId = PId,
        //        //GpId = GpId,
        //        //Name = Name,
        //        //Description = Description
        //    });
        //    _db.SaveChanges();
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult Delete(int Id)
        //{
        //    _db.Category3s.Remove(new Category3() { Id = Id });
        //    _db.SaveChanges();
        //    return Ok();
        //}

    }
}