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
    public class PurchaseRequest
    {
        public PurchaseRequest()
        { 
        
        }
        #region Dynamic Fields
        [NotMapped]
        public string DateTime
        {
            get => _DateTime.ToString("yyyy-MM-dd hh:mm tt");
        }
        #endregion

        [Key]
        public int Id { get; set; }
       
        public Faculties Faculty { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Branch { get; set; }
        public double BudgetAllocation { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FundGoes { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Project { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Vote { get; set; }
        public bool IsInProcumentPlan { get; set; }
        public Purposes Purpose { get; set; }
        public DateTime _DateTime { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Justification { get; set; }
        //public string TelephonNumber { get; set; }
    }
}
