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
    public class PurchaseRequestItemSpecification : IndexedObject
    {
        public PurchaseRequestItemSpecification()
        { 
            
        }
        #region Dynamic
        public Item GetItem(int id, bool notNull)
        {
            return Cache.GetItem(ItemId, true);
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        public int PurchaseRequestItemId { get; set; }
        public int ItemId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Value { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
    }
}
