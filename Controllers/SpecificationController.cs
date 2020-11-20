using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class SpecificationController : ControllerBase
    {
        private ApplicationDbContext _db;

        public SpecificationController(ApplicationDbContext context)
        {
            this._db = context;
        }



        public IActionResult Add(int Id, Item Item, SpecificationCategory SpecificationCategory, string Name, string Value)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Specification.Max((sp) => sp.Id);
            }
            catch
            {
            }

            Specification sp = new Specification()
            {
                Id = max_id + 1,
                SpecificationCategory = SpecificationCategory,
                Item = Item,
                Name = Name,
                Value = Value
            };
            _db.Specification.Add(sp);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Specification>> PostSpecification(object specification)
        {
            JsonData jd = JsonMapper.ToObject(specification.ToString());
            int specId = int.Parse(jd["SpecificationCategoryId"].ToString());
            int itemId = int.Parse(jd["ItemId"].ToString());
            Specification sp = new Specification()
            {
                SpecificationCategory = _db.SpecificationCategories.FirstOrDefault(cat => cat.Id == specId),
                Item = _db.Items.FirstOrDefault(it => it.Id == itemId),
                Name = jd["Name"].ToString(),
                Value = jd["Value"].ToString()

            };
            _db.Specification.Add(sp);
            await _db.SaveChangesAsync();

            return CreatedAtAction("Specification", new { id = sp.Id }, sp);
        }

        [HttpPut]
        public IActionResult Edit(int Id, SpecificationCategory SpecificationCategory, Item Item, string Name, string Value)
        {
            _db.Specification.Update(new Specification()
            {
                Id = Id, 
                SpecificationCategory= SpecificationCategory, 
                Item = Item, 
                Name = Name, 
                Value = Value 
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _db.Specification.Remove(new Specification() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
 
    }
}