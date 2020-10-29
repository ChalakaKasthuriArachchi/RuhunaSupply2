using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class Category3
    {
        public Category3()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required]

        public Category2 ParentCategory { get; set; }
        [MaxLength(50)]
        [Required]

        public Category1 GPCategory { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        [Required]
        public String Name { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public String Description { get; set; }
    }
}
