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
    public class Category2 : IndexedObject
    {
        public Category2()
        {
        }
        #region Dynamic
        public Category1 ParentCategory
        {
            get
            {
                return Cache.GetCategory1(ParentCategoryId, true);
            }
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        [Required]
        public int ParentCategoryId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int Index => Id;
        #endregion
    }
}
