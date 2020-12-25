using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationCategoryController : ControllerBase
    {
        private ApplicationDbContext _db;

        public SpecificationCategoryController(ApplicationDbContext context)
        {
            this._db = context;
        }


        public IActionResult Add(Item Item, string Title, string Description)
        {
            int max_id = 0;
            try
            {
                max_id = _db.SpecificationCategories.Max((sp) => sp.Id);
            }
            catch
            {
            }

            SpecificationCategory sp = new SpecificationCategory()
            {
                Id = max_id,
                Item = Item,
                Title = Title,
                Description = Description
            };

            _db.SpecificationCategories.Add(sp);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public SpecificationCategory[] Index(string Item, string Search)
        {
            IQueryable<SpecificationCategory> query = _db.SpecificationCategories;
            if (Item != null && Item.Trim().Length > 0 && Item != "undefined")
                query = query.Where(s => s.Item.Id.ToString() == Item);
            if (Search != null && Search.Trim().Length > 0 && Search != "undefined")
                query = query.Where(s => s.Id.ToString().Contains(Search)
                            || s.Title.Contains(Search)
                            || s.Description.Contains(Search));
            SpecificationCategory[] specificationcategories = query.Include(s => s.Item).ToArray();
            return specificationcategories;
        }

        [HttpPost]
        public async Task<ActionResult<SpecificationCategory>> PostSpecificationCategory(object specificationcategory)
        {
            JsonData jd = JsonMapper.ToObject(specificationcategory.ToString());
            int itemId = int.Parse(jd["ItemId"].ToString());
            SpecificationCategory sp = new SpecificationCategory()
            {
                Item = _db.Items.FirstOrDefault(it => it.Id == itemId),
                Title = jd["Title"].ToString(),
                Description = jd["Description"].ToString()
            };
            _db.SpecificationCategories.Add(sp);
            await _db.SaveChangesAsync();

            return CreatedAtAction("SpecificationCategory", new { id = sp.Id }, sp);
        }

        [HttpPut]
        public IActionResult Edit(int Id, Item Item, string Title, string Description)
        {
            _db.SpecificationCategories.Update(new SpecificationCategory() 
            { 
                Id=Id, 
                Item=Item, 
                Title=Title, 
                Description=Description
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _db.SpecificationCategories.Remove(new SpecificationCategory() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
