using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class Category1
    {
        public Category1() 
        {
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Description { get; set; }
    }
}
