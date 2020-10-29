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
        [Column(TypeName = "nvarchar(50)")]
        public string IsInProcumentPlan { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Purpose { get; set; }
        public string TelephonNumber { get; set; }


    }
}
