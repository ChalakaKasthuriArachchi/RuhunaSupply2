using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{   [Route("api/[controller]")]
    [ApiController] 
    public class ItemController : ControllerBase // get Base because not view this
    {
        private ApplicationDbContext _db;

        public ItemController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet]
        public Item[] GetItems()
        {
            return _db.Items.ToArray();
        }
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(object item)
        {
            JsonData jd = JsonMapper.ToObject(item.ToString());
            Item I1 = new Item()
            {
                Category1 = _db.Category1s
                    .FirstOrDefault(c1 => c1.Id == int.Parse(jd["Category1"].ToString())),
                Category2 = _db.Category2s
                    .FirstOrDefault(c2 => c2.Id == int.Parse(jd["Category2"].ToString())),
                Category3 = _db.Category3s
                    .FirstOrDefault(c3 => c3.Id == int.Parse(jd["Category3"].ToString())),
                Name = jd["Name"].ToString(),
                Description = jd["Description"].ToString(),


            };
            _db.Items.Add(I1);
            await _db.SaveChangesAsync();

            return CreatedAtAction("Items", new { id = I1.Id }, I1);
        }
        

        /*[HttpPut]
        public IActionResult Edit(int id, string Name, string Description, Category1 Category1, Category2 Category2, Category3 Category3)
        {
            _db.Items.Update(
                new Item() { Id = id, Name = Name, Description = Description, Category1 = Category1, Category2 = Category2, Category3 = Category3 });
            _db.SaveChanges();
            return Ok();
        }*/

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            _db.Items.Remove(new Item() { Id = id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
