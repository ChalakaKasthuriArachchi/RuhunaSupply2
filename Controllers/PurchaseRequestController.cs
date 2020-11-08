using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Controllers
{
    public class PurchaseRequestController : ControllerBase
    {
        private ApplicationDbContext _db;

        public PurchaseRequestController(ApplicationDbContext context)
        {
            this._db = context;
        }

        public IActionResult Add(Faculties admin, string branch, double budgetAllocation, string FundGoes, string Project, string Vote, string IsInProcumentPlan, string Purpose, string TelephonNumber)
        {
            //int max_id = 0;
            //try
            //{
            //    max_id = _db.PurchaseRequests.Max((pr) => pr.Id);
            //}
            //catch
            //{

            //}

            //PurchaseRequest pr = new PurchaseRequest()
            //{

            //    Id = max_id,
            //    Faculty = admin,
            //    Branch = branch,
            //    BudgetAllocation = budgetAllocation,
            //    FundGoes = FundGoes,
            //    Project = Project,
            //    Vote = Vote,
            //    IsInProcumentPlan = IsInProcumentPlan,
            //    Purpose = Purpose,
            //    TelephonNumber = TelephonNumber
            //};
            //_db.PurchaseRequests.Add(pr);
            //_db.SaveChanges();
            return Ok();
        
        }
        [HttpPost]
        public IActionResult Edit(int Id, Faculties admin, string branch, double budgetAllocation, string FunsGoes, string Project, string Vote, string IsInProcumentPlan, string Purpose, string TelephonNumber)
        {
            //_db.PurchaseRequests.Update(new PurchaseRequest() {
            //    Id = Id,
            //    Faculty = admin,
            //    Branch = branch,
            //    BudgetAllocation = budgetAllocation,
            //    FundGoes = FunsGoes,
            //    Project = Project,
            //    Vote = Vote,
            //    IsInProcumentPlan = IsInProcumentPlan,
            //    Purpose = Purpose,
            //    TelephonNumber = TelephonNumber
            //});
            //_db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _db.PurchaseRequests.Remove(new PurchaseRequest() { Id = Id });
            _db.SaveChanges();
            return Ok();
        }
    }
}
