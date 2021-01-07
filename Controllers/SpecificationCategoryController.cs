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
        [HttpGet]
        public SpecificationCategory[] GetSpecificationCategories(int itemId)
        {
            try
            {
                IQueryable<SpecificationCategory> query = _db.SpecificationCategories.OrderBy(cat => cat.Title);
                if (itemId != 0)
                    query = query.Where(cat => cat.ItemId == itemId);
                SpecificationCategory[] specificationCategories = query.ToArray();
                return specificationCategories;
            }
            catch (Exception ex)
            {
                Functions.UpdateErrorLog("Unable to Load Specification Categories", ex);
                return null;
            }
        }
        [HttpGet("{id}")]
        public SpecificationCategory GetSpecificationCategory(int id)
        {
            return _db.SpecificationCategories.Find(id);
        }
        [HttpPost]
        public async Task<ActionResult<SpecificationCategory>> PostSpecificationCategory(object specificationcategory)
        {
            try 
            { 
                JsonData jd = JsonMapper.ToObject(specificationcategory.ToString());
                int itemId = int.Parse(jd["Item"].ToString());
                SpecificationCategory sp = new SpecificationCategory()
                {
                    ItemId = itemId,
                    Title = jd["Title"].ToString(),
                    Description = jd["Description"].ToString(),
                    TimeStamp = Functions.DateTime
                };
                _db.SpecificationCategories.Add(sp);
                await _db.SaveChangesAsync();
                await Task.Run(() => { Cache.RefreshSpecificationCategories(_db); });
                return CreatedAtAction("SpecificationCategory", new { id = sp.Id }, sp);
            }
            catch(Exception ex)
            {
                Functions.UpdateErrorLog("Unable to Add Specification Category", ex);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit(int Id, Item Item, string Title, string Description)
        {
            _db.SpecificationCategories.Update(new SpecificationCategory() 
            { 
                Id=Id, 
                //Item=Item, 
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
