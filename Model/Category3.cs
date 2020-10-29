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
        public int PId { get; set; }
        public int GpId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Description { get; set; }
    }
}
