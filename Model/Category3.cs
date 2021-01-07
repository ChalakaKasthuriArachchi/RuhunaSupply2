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
    public class Category3 : IndexedObject
    {
        public Category3()
        {

        }
        #region Dynamic
        public Category1 GPCategory
        {
            get
            {
                return Cache.GetCategory1(GPCategoryId, true);
            }
        }
        public Category2 ParentCategory
        {
            get
            {
                return Cache.GetCategory2(ParentCategoryId, true);
            }
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        [Required]
        public int GPCategoryId { get; set; }
        [MaxLength(50)]
        [Required]
        public int ParentCategoryId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public int Index => Id;
        public DateTime TimeStamp { get; set; }
        #endregion
    }
}
