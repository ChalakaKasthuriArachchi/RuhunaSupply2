using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public Faculty Faculty { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public Department Department { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string ShortName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PermissionList { get; set; }

        public UserPositions Position { get; set; }
        public UserTypes Type { get; set; }
        public User Merged { get; set; }
        #region static
        public static User Get(ApplicationDbContext db, int userId)
        {
            User user =
                db.Users.Include(user => user.Merged).FirstOrDefault(user => user.Id == userId);
            if (user.Merged == null)
                return user;
            User mUser = user.Merged;
            StringBuilder permissionList = new StringBuilder(user.PermissionList.Length);
            for (int i = 0; i < user.PermissionList.Length; i++)
            {
                permissionList.Append(
                    (user.PermissionList[i] == '1' || mUser.PermissionList[i] == '1')
                     ? "1" : "0");
            }
            return mUser;
        }
        #endregion
    }
}
