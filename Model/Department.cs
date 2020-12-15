using cmlMySqlStandard;
using RuhunaSupply.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class Department : IndexedObject
    {
        #region Dynamic
        public Faculty Faculty 
        {
            get
            {
                return Cache.GetFaculty(FacultyId, true);
            }
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        public double BudgetAllocation { get; set; }
        public double UsedAmount { get; set; }
        public int FacultyId { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
    }
}
