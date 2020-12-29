using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class QuotationItemSpecificationController : ControllerBase
    {
        private ApplicationDbContext _db;

        public QuotationItemSpecificationController(ApplicationDbContext context)
        {
            this._db = context;
        }
        public IActionResult Add(QuotationItem QuotationItem, Specification Specification, string Satisfied, string Description)
        {
            int max_id = 0;
            try
            {
                max_id = _db.QuotationItemSpecifications.Max((qis) => qis.Id);
            }
            catch
            {
            }

            //QuotationItemSpecification qis = new QuotationItemSpecification()
            //{
            //    Id = max_id,
            //    QuotationItem = QuotationItem,
            //    Specification = Specification,
            //    Satisfied = Satisfied,
            //    Description = Description
            //};
            //_db.QuotationItemSpecifications.Add(qis);
            //_db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Edit(int Id, QuotationItem QuotationItem, Specification Specification, string Satisfied, string Description)
        {
            //_db.QuotationItemSpecifications.Update(new QuotationItemSpecification()
            //{
            //    Id = Id,
            //    QuotationItem = QuotationItem,
            //    Specification = Specification,
            //    Satisfied = Satisfied,
            //    Description = Description
            //});
            //_db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            //_db.QuotationItemSpecifications.Remove(new QuotationItemSpecification() { Id = Id });
            //_db.SaveChanges();
            return Ok();
        }
    }
}

