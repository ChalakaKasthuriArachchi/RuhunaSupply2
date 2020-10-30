using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class User
    {
        public User()
        { 
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Admin { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Branch { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string ShortName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PermissionList { get; set; }

        public UserPositions Position { get; set; }
        public UserTypes Type { get; set; }
        public int MergedId { get; set; }
    }
}
