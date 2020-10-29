using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class UserName
    {
        public UserName()
        { 
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public string Password { get; set; }
        public Tables Table { get; set; }
    }
}
