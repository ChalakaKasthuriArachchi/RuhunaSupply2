using cmlMySqlStandard;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class UserAccount : IndexedObject
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
        [Column(TypeName = "nvarchar(64)")]
        [MaxLength(64)]
        public string HashedPassword { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string Privileges { get; set; }
        [Required]
        public UserTypes Type { get; set; }
        [NotMapped]
        public string Token { get; internal set; }
        [NotMapped]
        public string Password { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
    }
}
