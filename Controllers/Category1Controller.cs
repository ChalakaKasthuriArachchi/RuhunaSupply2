using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Common;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //use as api controller
    public class Category1Controller : ControllerBase
    {
        private ApplicationDbContext _db;

        public Category1Controller(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet]
        public Category1[] GetCategory1s()
        {
            return _db.Category1s.OrderBy(cat => cat.Name).ToArray();
        }
        [HttpPost]
        public async Task<ActionResult<Category1>> PostCategory1(object category1)
        {
            JsonData jd = JsonMapper.ToObject(category1.ToString());
            Category1 c1 = new Category1()
            {
                Name = jd["Name"].ToString(),
                Description = jd["Description"].ToString(),
                TimeStamp = Functions.DateTime
            };
            _db.Category1s.Add(c1);
            await _db.SaveChangesAsync();
            await Task.Run(() => { Cache.RefreshCategory1(_db); });
            return CreatedAtAction("Category1", new { id = c1.Id }, c1);
        }
    }
}
