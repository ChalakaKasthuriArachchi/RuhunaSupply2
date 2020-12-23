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
    public class Item : IndexedObject
    {
        public Item()
        {

        }
        #region Dynamic
        public Category1 Category1
        {
            get
            {
                return Cache.GetCategory1(Category1Id, true);
            }
        }
        public Category2 Category2
        {
            get
            {
                return Cache.GetCategory2(Category2Id, true);
            }
        }
        public Category3 Category3
        {
            get
            {
                return Cache.GetCategory3(Category3Id, true);
            }
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        [Required]
        public int Category1Id { get; set; }
        [Required]
        public int Category2Id { get; set; }
        [Required]
        public int Category3Id { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
    }

}
