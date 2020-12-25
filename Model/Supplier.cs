using cmlMySqlStandard;
using RuhunaSupply.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class Supplier : IndexedObject
    {
        public Supplier()
        { 
        
        }
        #region Dynamic
        public Category2 Category2
        {
            get
            {
                return Cache.GetCategory2(Category2Id, true);
            }
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        public int Category2Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string RegistrationNumber { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime BusinessRegisteredDate { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string ContactNumber { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string BusinessName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string BusinessMail { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string BusinessAddress { get; set; }
        public BusinessCategories BusinessCategory { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
    }
}
