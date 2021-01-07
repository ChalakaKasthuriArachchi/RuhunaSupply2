using cmlMySqlStandard;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Common;
using RuhunaSupply.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.LIMIT;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class PurchaseRequest : IndexedObject
    {
        public PurchaseRequest()
        { 
        
        }
        internal static int GetNextId(ApplicationDbContext db)
        {
            PurchaseRequest pr = 
                db.PurchaseRequests.FromSqlRaw("SELECT * FROM PurchaseRequests ORDER BY Id DESC").FirstOrDefault();
            if (pr == null)
               return 1;
            return pr.Id + 1;
        }
        #region Dynamic Fields
        [NotMapped]
        public string DateTime
        {
            get => _DateTime.ToString("yyyy-MM-dd hh:mm tt");
        }
        public string Date
        {
            get => _DateTime.ToString("yyyy-MM-dd");
        }
        public User SubmittedBy 
        {
            get
            {
                return Cache.GetUser(SubmittedById, true);
            }
        }
        public User Examinig 
        {
            get
            {
                return Cache.GetUser(ExaminigId, true);
            } 
        }
        public Faculty Faculty
        {
            get
            {
                return Cache.GetFaculty(FacultyId, true);
            }
        }
        public Department Department
        {
            get
            {
                return Cache.GetDepartment(DepartmentId,true);
            }
        }
        public double AvailbleAmount => BudgetAllocation - UsedAmount;
        #endregion

        #region Saved
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentId { get; set; }
        public double BudgetAllocation { get; set; }
        public double UsedAmount { get; set; }
        public string FundGOSL { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Project { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Vote { get; set; }
        public bool IsInProcumentPlan { get; set; }
        public Purposes Purpose { get; set; }
        public DateTime _DateTime { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Justification { get; set; }
        public PurchaseRequestStatus Status { get; set; }
        public int SubmittedById { get; set; }
        public int ExaminigId { get; set; }
        public List<PurchaseRequestItem> Items { get; set; } = new List<PurchaseRequestItem>();
        public bool IsDeleted { get; set; }

        public int Index => Id;
        public DateTime TimeStamp { get; set; }
        #endregion
    }
}
