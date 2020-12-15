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
        #endregion
        #region Saved
        [Key]
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
    }
}
