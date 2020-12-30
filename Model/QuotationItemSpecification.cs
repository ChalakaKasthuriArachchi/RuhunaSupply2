using RuhunaSupply.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class QuotationItemSpecification
    {
        #region Dynamic
        public Item Item
        {
            get => Cache.GetItem(ItemId, true);
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        public int QuotationItemId { get; set; }
        [ForeignKey("PurchaseRequestItemSpecification")]
        public int PurchaseRequestItemSpecificationId { get; set; }
        public PurchaseRequestItemSpecification PurchaseRequestItemSpecification { get; set; }
        public int ItemId { get; set; }
        public bool Satisfied { get; set; }
        [MaxLength(150)]
        public string Remark { get; set; } = "";
        #endregion
    }
}
