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
        public Item[] GetItems(int category,string search,bool fullView)
        {
            if (search != null)
                search = search.Trim().ToLower();
            IQueryable<Item> query = _db.Items;
            query = query.OrderBy(it => it.Name);
            if (search != null && search.Trim().Length > 0 && search != "undefined" && category > 0)
                query = query.Where(it => it.Name.ToLower().Contains(search) || it.Description.ToLower().Contains(search));
            Item[] items = query.ToArray();
            return items;
        }
        [HttpGet("{id}")]
        public Item GetItem(int id,bool fullView)
        {
            //if (fullView)
            //    query = query.Include(i => i.Category1).Include(i => i.Category2).Include(i => i.Category3);
            return _db.Items.Find(id);
        }
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(object item)
        {
            JsonData jd = JsonMapper.ToObject(item.ToString());
            Item I1 = new Item()
            {
                Category1Id = int.Parse(jd["Category1"].ToString()),
                Category2Id = int.Parse(jd["Category2"].ToString()),
                Category3Id = int.Parse(jd["Category3"].ToString()),
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

        //[HttpDelete]

        //public IActionResult Delete(int id)
        //{
        //    _db.Items.Remove(new Item() { Id = id });
        //    _db.SaveChanges();
        //    return Ok();
        //}
    }
}
