using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuhunaSupply.Data;
using RuhunaSupply.Model;

namespace RuhunaSupply.Controllers
{
    public class PurchaseRequestController : ControllerBase
    {
        private ApplicationDbContext _db;

        public PurchaseRequestController(ApplicationDbContext context)
        {
            this._db = context;
        }

        public IActionResult Add(string admin, string branch, double budgetAllocation, string FunsGoes, string Project, string Vote, string IsInProcumentPlan, string Purpose, int TelephonNumber)
        {
            int max_id = 0;
            try
            {
                max_id = _db.PurchaseRequests.Max((pr) => pr.Id);
            }
            catch
            {

            }

            PurchaseRequest pr = new PurchaseRequest()
            {

                Id = max_id,
                admin = admin,
                branch = branch,
                budgetAllocation = budgetAllocation,
                FunsGoes = FunsGoes,
                Project = Project,
                Vote = Vote,
                IsInProcumentPlan = IsInProcumentPlan,
                Purpose = Purpose,
                TelephonNumber = TelephonNumber
            };
            _db.PurchaseRequests.Add(pr);
            _db.SaveChanges();
            return Ok();
        
        }
        [HttpPost]
        public IActionResult Edit(int Id, string admin, string branch, double budgetAllocation, string FunsGoes, string Project, string Vote, string IsInProcumentPlan, string Purpose, int TelephonNumber)
        {
            _db.PurchaseRequests.Update(new PurchaseRequest() {
                Id = Id,
                admin = admin,
                branch = branch,
                budgetAllocation = budgetAllocation,
                FunsGoes = FunsGoes,
                Project = Project,
                Vote = Vote,
                IsInProcumentPlan = IsInProcumentPlan,
                Purpose = Purpose,
                TelephonNumber = TelephonNumber
            });
            _db.SaveChanges();
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
