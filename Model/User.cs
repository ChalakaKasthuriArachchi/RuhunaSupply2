using cmlMySqlStandard;
using Microsoft.EntityFrameworkCore;
using RuhunaSupply.Common;
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
    public class User : IndexedObject
    {
        public User()
        { 
        }
        #region Dynamic
        public string PositionText => Position.ToString();
        public Faculty Faculty
        {
            get
            {
                return Cache.GetFaculty(FacultyId, true);
            }
        }
        public Department Department
        {
            get
            {
                return Cache.GetDepartment(DepartmentId, true);
            }
        }
        public User Merged
        {
            get
            {
                return Cache.GetUser(MergedId, false);
            }
        }
        public bool TestPrivileges(UserPrivileges privilege)
        {
            try
            {
                return PermissionList[(int)privilege] == '1';
            }
            catch { return false; }
        }
        public static int GetNext(ApplicationDbContext db)
        {
            int uID1 = 0, uID2 = 0;
            try
            {
                uID1 = db.Users.Max(u => u.Id);
                uID2 = db.UserAccounts.Max(u => u.Id);
            }
            catch { }
            return Math.Max(1, Math.Max(uID1, uID2)) + 1;
        }
        #endregion
        #region Saved
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string ShortName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PermissionList { get; set; }
        public UserPositions Position { get; set; }
        public UserTypes Type { get; set; }
        public int MergedId { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
        public enum UserPrivileges
        {
            //PurchaseRequest
            PurchaseRequest_Add,
            PurchaseRequest_Forward_Outside_Department,
            PurchaseRequest_Forward_Outside_Faculty,
        }
    }
}
