using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SupplierController : ControllerBase
    {
        private ApplicationDbContext _db;

        public SupplierController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet]
        public Supplier[] Index(string Category,string Search)
        {
            IQueryable<Supplier> query = _db.Suppliers;
            if (Category != null && Category.Trim().Length > 0 && Category != "undefined")
                query = query.Where(s => s.Category2.Id.ToString() == Category);
            if (Search != null && Search.Trim().Length > 0 && Search != "undefined")
                query = query.Where(s => s.BusinessName.Contains(Search)
                            || s.BusinessAddress.Contains(Search)
                            || s.ContactNumber.Contains(Search)
                            || s.BusinessMail.Contains(Search));
            Supplier[] suppliers = query.Include(s => s.Category2).ToArray();
            return suppliers;
        }
        [HttpGet("{id}")] // api/supplier/1
        public Supplier GetSupplier(int id)
        {
            return _db.Suppliers.Find(id);
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(object supplier)
        {
            JsonData jd = JsonMapper.ToObject(supplier.ToString());
            string userId = Request.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            Supplier sp = new Supplier()
            {
                Id = int.Parse(userId),
                BusinessAddress = jd["BusinessAddress"].ToString(),
                BusinessCategory = (BusinessCategories)int.Parse(jd["Category2"].ToString()),
                BusinessMail = jd["BusinessMail"].ToString(),
                BusinessName = jd["BusinessName"].ToString(),
                BusinessRegisteredDate = DateTime.Parse(jd["BusinessRegisteredDate"].ToString()),
                Category2Id = int.Parse(jd["Category2"].ToString()),
                RegisteredDate = DateTime.Now,
                RegistrationNumber = jd["RegistrationNumber"].ToString(),
                ContactNumber = jd["ContactNumber"].ToString()
            };
            _db.Suppliers.Add(sp);
            await _db.SaveChangesAsync();

            return CreatedAtAction("Supplier", new { id = sp.Id }, sp);
        }
        [HttpPut]
        public IActionResult Edit(int Id, Category2 Category2, string RegisterNumber, DateTime RegisterDate, string TelephoneNumber, string BusinessName, string BusinessMail, string BusinessAddress)
        {
            _db.Suppliers.Update(new Supplier()
            {
                Id = Id,
                //Category2=Category2,
                RegistrationNumber = RegisterNumber,
                RegisteredDate = RegisterDate,
                ContactNumber = TelephoneNumber,
                BusinessName = BusinessName,
                BusinessMail = BusinessMail,
                BusinessAddress = BusinessAddress
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _db.Suppliers.Remove(new Supplier() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
