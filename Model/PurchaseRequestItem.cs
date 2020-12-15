using cmlMySqlStandard;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RuhunaSupply.Common;
using RuhunaSupply.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class PurchaseRequestItem : IndexedObject
    {
        public PurchaseRequestItem()
        {

        }
        #region Dynamic
        public Item GetItem(int id,bool notNull)
        {
            return Cache.GetItem(ItemId, true);
        }
        private PurchaseRequest purchaseRequest = null;
        public PurchaseRequest GetPurchaseRequest(ApplicationDbContext db)
        {
            if (purchaseRequest == null)
                purchaseRequest = db.PurchaseRequests.Find(PurchaseRequestId);
            return purchaseRequest;
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        public int PurchaseRequestId { get; set; }
        public int ItemId { get; set; }
        public double QtySupplied { get; set; }
        public double QtyRequired { get; set; } 
        public double Rate { get; set; }
        public double TotalValue { get; set; }
        public double EstimatedCost { get; set; }
        public List<PurchaseRequestItemSpecification> Specifications { get; set; }
            = new List<PurchaseRequestItemSpecification>();
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
    }
}
