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
    public class SpecificationCategory : IndexedObject
    {
        public SpecificationCategory()
        { 
        }
        #region Dynamic
        public Item Item
        {
            get
            {
                return Cache.GetItem(ItemId, true);
            }
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string Title { get; set; }
        [Column(TypeName ="nvarchar(150)")]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
    }
}
