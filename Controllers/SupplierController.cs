using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using ThirdParty.Json.LitJson;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ApplicationDbContext _db;

        public SupplierController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet]
        public Supplier[] Index()
        {
            return _db.Suppliers.ToArray();
        }
        [HttpPost]
        //public IActionResult Post(/*int Category2Id,string regNo,string TelephoneNumber,  string BusinessName,  string BusinessMail, string BusinessAddress*/)
        //{
        //    int max_id = 0;
        //    try
        //    {
        //        max_id = _db.Suppliers.Max((sup) => sup.Id);
        //    }
        //    catch
        //    { 
        //    }

        //    Supplier sup = new Supplier()
        //    {
        //        Id = max_id,
        //        //Category2=_db.Category2s.FirstOrDefault((c) => c.Id == Category2Id),
        //        //RegisterNumber = RegisterNumber,
        //        //RegisterDate = DateTime.Now,
        //        //TelephoneNumber = TelephoneNumber,
        //        //BusinessName = BusinessName,
        //        //BusinessMail = BusinessMail,
        //        //BusinessAddress = BusinessAddress
        //    };
        //    _db.Suppliers.Add(sup);
        //    _db.SaveChanges();
        //    return Ok();
        //}
        public async Task<ActionResult<Supplier>> PostSupplier(object supplier)
        {
            JsonData jd = JsonMapper.ToObject(supplier.ToString());
            Supplier sp = new Supplier()
            {
                BusinessAddress = jd["BusinessAddress"].ToString(),
                BusinessCategory = (BusinessCategories)int.Parse(jd["Category2"].ToString()),
                BusinessMail = jd["BusinessMail"].ToString(),
                BusinessName = jd["BusinessName"].ToString(),
                BusinessRegisteredDate = DateTime.Parse(jd["BusinessRegisteredDate"].ToString()),
                Category2 = new Category2() { Description = "(Testing)", Name = "(Testing)",PId }, // For Testing Only
                RegisteredDate = DateTime.Now,
                RegistrationNumber = jd["RegistrationNumber"].ToString(),
                ContactNumber = jd["ContactNumber"].ToString()
            };
            _db.Suppliers.Add(sp);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetBankAccount", new { id = sp.Id }, sp);
        }
        [HttpPut]
        public IActionResult Edit(int Id, Category2 Category2, string RegisterNumber, DateTime RegisterDate, string TelephoneNumber, string BusinessName, string BusinessMail, string BusinessAddress)
        {
            _db.Suppliers.Update(new Supplier()
            {
                Id = Id,
                Category2=Category2,
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
