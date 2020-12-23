using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using static RuhunaSupply.Common.MyEnum;
using ThirdParty.Json.LitJson;

namespace RuhunaSupply.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class QuatationController : ControllerBase
    {
        private ApplicationDbContext _db;

        public QuatationController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet]
        public Quotation[] GetQuataions()
        {
            return _db.Quatations.ToArray();
        }
        [HttpGet("api/[Controller]/{id}")]
        public Quotation GetQuotation(int id)
        {
            Quotation q = _db.Quatations.Find(id);
            return q;
        }
        [HttpPost]
        public async Task<ActionResult<Quotation>> PostQautaion(object quatation)
        { 
            JsonData jd = JsonMapper.ToObject(quatation.ToString());
             Quotation qt = new Quotation()
             {
                
             };
                _db.Quatations.Add(qt);
                await _db.SaveChangesAsync();

                return CreatedAtAction("Quataion", new { id = qt.Id }, qt);
        }
    //public IActionResult Add(PurchaseRequest PurchaseRequest, Supplier Supplier, QuatationStatus Status, DateTime Date)
    //  {
    //     int max_id = 0;
    //     try
    //     {
    //         max_id = _db.Quatations.Max((qt) => qt.Id);
    //     }
    //     catch
    //     {

    //     }
    //     Quatation qt = new Quatation()
    //     {
    //         Id = max_id + 1,
    //         PurchaseRequest=PurchaseRequest,
    //         Supplier=Supplier,
    //         Status = Status,
    //         Date = Date

    //     };
    //     _db.Quatations.Add(qt);
    //     _db.SaveChanges();
    //     return Ok();
    // }

    [HttpPut]
        public IActionResult Edit(int Id, PurchaseRequest PurchaseRequest, Supplier Supplier, QuatationStatus Status, DateTime Date)
        {
            _db.Quatations.Update(new Quotation()
            {
                Id = Id,
                //PurchaseRequest = PurchaseRequest,
                //Supplier = Supplier,
                //Status = Status,
                //Date = Date
            });
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _db.Quatations.Remove(new Quotation() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
        
    }
}
