using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class SpecificationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpecificationController(ApplicationDbContext context)
        {
            _context = context;
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
            int specId = int.Parse(jd["SpecCategory"].ToString());
            int itemId = int.Parse(jd["Item"].ToString());
            Specification sp = new Specification()
            {
                SpecificationCategoryId = specId,
                ItemId = itemId,
                Name = jd["Name"].ToString(),
                Value = jd["Value"].ToString()

            };
            _context.Specification.Add(sp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Specification", new { id = sp.Id }, sp);
        }

        [HttpPut]
        public IActionResult Edit(object specification)
        {
            _context.Specification.Update(new Specification()
            {
                
            });
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecification(int id, Specification specification)
        {
            
           // _context.Specification.FirstOrDefault(cat => cat.SpecificationCategory == );

            if (id != specification.Id)
            {
                return BadRequest();
            }

            _context.Entry(specification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Specification>> DeleteSpecification(int id)
        {
            var specification = await _context.Specification.FindAsync(id);
            if (specification == null)
            {
                return NotFound();
            }

            _context.Specification.Remove(specification);
            await _context.SaveChangesAsync();

            return specification;
        }

        private bool SpecificationExists(int id)
        {
            return _context.Specification.Any(e => e.Id == id);
        }
    }
}