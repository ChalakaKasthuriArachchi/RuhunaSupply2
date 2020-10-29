using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class QuatationItemSpecification
    {
        public QuatationItemSpecification()
        { 
        }

        [Key]
        public int Id { get; set; }
        public QuatationItem QuatationItem { get; set; }
        public Specification Specification { get; set; }
        [Column(TypeName ="nvarchar(20)")]
        public string Satisfied { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
    }
}
