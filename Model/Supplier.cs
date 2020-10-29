using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class Supplier
    {
        public Supplier()
        { 
        
        }

        [Key]
        public int Id { get; set; }
        public Category2 Category2Id { get; set; }
        public int RegisterNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string TelephoneNumber { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string BusinessName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string BusinessMail { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string BusinessAddress { get; set; }
        
    }
}
