using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : Controller
    {
        private ApplicationDbContext _db;

        public QuotationController(ApplicationDbContext context)
        {
            this._db = context;
        }
        [HttpGet("supplier/{id}")]
        public Quotation[] GetQuotations(int id)
        {
            var vs = _db.Quotations.Where(s => s.SupplierId == id).ToArray();
            foreach (var item in vs)
            {
                item.GetSupplier(_db);
            }
            return vs;
        }
        [HttpGet("{id}")]
        public Quotation GetQuotation(int id)
        {
            try
            {
                Quotation quotations = _db.Quotations.Include(qu => qu.QuotationItems).FirstOrDefault(qu => qu.Id == id);
                for (int i = 0; i < quotations.QuotationItems.Count; i++)
                {
                    quotations.QuotationItems[i].Specifications
                        = _db.QuotationItemSpecification
                            .Where(qis => qis.QuotationItemId == quotations.QuotationItems[i].Id)
                                .ToList();
                    for (int j = 0; j < quotations.QuotationItems[i].Specifications.Count;j++)
                    {
                        quotations.QuotationItems[i].Specifications[j].PurchaseRequestItemSpecification
                            = _db.PurchaseRequestItemSpecifications.Find(quotations.QuotationItems[i].Specifications[j].PurchaseRequestItemSpecificationId);
                    }
                }
                return quotations;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
