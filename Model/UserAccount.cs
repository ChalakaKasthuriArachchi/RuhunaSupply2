using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

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
        [MaxLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string ShortName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string HashedPassword { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string Privileges { get; set; }
        [Required]
        public UserTypes Type { get; set; }
        [NotMapped]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
