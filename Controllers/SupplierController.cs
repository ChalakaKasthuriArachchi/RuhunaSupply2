using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class SupplierController : ControllerBase
    {
        private ApplicationDbContext _db;

        public SupplierController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(int RegisterNumber, Category2 Category2Id, DateTime RegisterDate, string TelephoneNumber,  string BusinessName,  string BusinessMail, string BusinessAddress)
        {
            int max_id = 0;
            try
            {
                max_id = _db.Suppliers.Max((sup) => sup.Id);
            }
            catch
            { 
            }

            Supplier sup = new Supplier()
            {
                Id = max_id,
                Category2Id=Category2Id,
                RegisterNumber = RegisterNumber,
                RegisterDate = RegisterDate,
                TelephoneNumber = TelephoneNumber,
                BusinessName = BusinessName,
                BusinessMail = BusinessMail,
                BusinessAddress = BusinessAddress
            };
            _db.Suppliers.Add(sup);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit(int Id, Category2 Category2Id, int RegisterNumber, DateTime RegisterDate, string TelephoneNumber, string BusinessName, string BusinessMail, string BusinessAddress)
        {
            _db.Suppliers.Update(new Supplier()
            {
                Id = Id,
                Category2Id=Category2Id,
                RegisterNumber = RegisterNumber,
                RegisterDate = RegisterDate,
                TelephoneNumber = TelephoneNumber,
                BusinessName = BusinessName,
                BusinessMail = BusinessMail,
                BusinessAddress = BusinessAddress
            });
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.Suppliers.Remove(new Supplier() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
