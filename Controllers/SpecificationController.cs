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
                max_id = _context.Specification.Max((sp) => sp.Id);
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
            _context.Specification.Add(sp);
            _context.SaveChanges();
            return Ok();
        }

       [HttpGet]
       public Specification[] Index(string Category,string Search)
        {
            IQueryable<Specification> query = _context.Specification;
            if (Category != null && Category.Trim().Length > 0 && Category != "undefined")
                query = query.Where(s => s.SpecificationCategory.Id.ToString() == Category);
            if (Search != null && Search.Trim().Length > 0 && Search != "undefined")
                query = query.Where(s => s.SpecificationCategory.ToString().Contains(Search));
            Specification[] specification = query.Include(s => s.SpecificationCategory).ToArray();
            return specification;
        } 

        // GET: api/Specification/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specification>>> GetSpecification()
        {
            return await _context.Specification.ToListAsync();
        }

        // GET: api/Specification/6
        [HttpGet("{id}")]
        public async Task<ActionResult<Specification>> GetSpecification(int id)
        {
            var specification = await _context.Specification.FindAsync(id);

            if (specification == null)
            {
                return NotFound();
            }

            return specification;
        }

        [HttpPost]
        public async Task<ActionResult<Specification>> PostSpecification(object specification)
        {
            JsonData jd = JsonMapper.ToObject(specification.ToString());
            int specId = int.Parse(jd["SpecificationCategoryId"].ToString());
            int itemId = int.Parse(jd["ItemId"].ToString());
            Specification sp = new Specification()
            {
                SpecificationCategory = _context.SpecificationCategories.FirstOrDefault(cat => cat.Id == specId),
                Item = _context.Items.FirstOrDefault(it => it.Id == itemId),
                Name = jd["Name"].ToString(),
                Value = jd["Value"].ToString()

            };
            _context.Specification.Add(sp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Specification", new { id = sp.Id }, sp);
        }

        [HttpPut]
        public IActionResult Edit(int Id, SpecificationCategory SpecificationCategory, Item Item, string Name, string Value)
        {
            _context.Specification.Update(new Specification()
            {
                Id = Id, 
                SpecificationCategory= SpecificationCategory, 
                Item = Item, 
                Name = Name, 
                Value = Value 
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