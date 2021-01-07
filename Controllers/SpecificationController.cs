using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Common;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        private ApplicationDbContext _db;

        public SpecificationController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpPost]
        public async Task<ActionResult<Specification>> PostSpecification(object specification)
        {
            JsonData jd = JsonMapper.ToObject(specification.ToString());
            int specId = int.Parse(jd["SpecCategory"].ToString());
            int itemId = int.Parse(jd["Item"].ToString());
            Specification sp = new Specification()
            {
                SpecificationCategoryId = specId,
                ItemId = itemId,
                Name = jd["Name"].ToString(),
                Value = jd["Value"].ToString(),
                TimeStamp = Functions.DateTime
            };
            _db.Specification.Add(sp);
            await _db.SaveChangesAsync();

            return CreatedAtAction("Specification", new { id = sp.Id }, sp);
        }

        [HttpPut]
        public IActionResult Edit(object specification)
        {
            _db.Specification.Update(new Specification()
            {
                
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