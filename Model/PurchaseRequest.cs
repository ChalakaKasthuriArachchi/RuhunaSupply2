using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class PurchaseRequest
    {
        public PurchaseRequest()
        { 
        
        }

        [Key]
        public int Id { get; set; }
        public string admin { get; set; }
        public string branch { get; set; }
        public double budgetAllocation { get; set; }
        public string FunsGoes { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Project { get; set; }
        public string Vote { get; set; }
        public string IsInProcumentPlan { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Purpose { get; set; }
        public int TelephonNumber { get; set; }


    }
}
