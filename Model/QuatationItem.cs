using cmlMySqlStandard;
using RuhunaSupply.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class QuatationItem : IndexedObject
    {
        public QuatationItem() 
        {
        }
        #region Dynamic
        private Quotation quotation = null;
        public Quotation GetQuotation(ApplicationDbContext db)
        {
            if (quotation == null)
                quotation = db.Quotations.Find(QuotationId);
            return quotation;
        }
        private PurchaseRequestItem purchaseRequestItem;
        public PurchaseRequestItem GetPurchaseRequestItem(ApplicationDbContext db)
        {
            if (purchaseRequestItem == null)
                purchaseRequestItem = db.PurchaseRequestItems.Find(PurchaseRequestItemId);
            return purchaseRequestItem;
        }
        #endregion

        #region Saved
        [Key]
        public int Id { get; set; }
        public int QuotationId { get; set; }
        public int PurchaseRequestItemId { get; set; }
        public int ItemId { get; set; }
        public QuatationStatus Status { get; set; }
        public bool IsSupplied { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public double Qty { get; set; }
        public double Total { get; set; }
        public double Rate { get; set; }
        public List<Specification> Specifications { get; set; }
            = new List<Specification>();
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
    }
}
