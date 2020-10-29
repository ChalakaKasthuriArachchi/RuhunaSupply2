using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class UserAccount
    {
        public UserAccount()
        {

        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string HashedPassword { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Privileges { get; set; }
        [NotMapped]
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }
    }
}
