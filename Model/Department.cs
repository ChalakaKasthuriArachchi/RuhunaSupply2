using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Location { get; set; }
        public double BudgetAllocation { get; set; }
        public double UsedAmount { get; set; }
        public Faculty Faculty { get; set; }
    }
}
