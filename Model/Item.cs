using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class Item
    {
        public Item()
        {

        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public Category1 Category1 { get; set; }
        [Required]
        public Category2 Category2 { get; set; }
        [Required]
        public Category3 Category3 { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength (150)]
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string Description { get; set; }
       
       

    }

}
