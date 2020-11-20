using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class SpecificationCategory
    {
        public SpecificationCategory()
        { 
        }

        [Key]
        public int Id { get; set; }
        public Item Item { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string Title { get; set; }
        [Column(TypeName ="nvarchar(150)")]
        public string Description { get; set; }

        
    }
}
