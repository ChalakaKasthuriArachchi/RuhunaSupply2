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
    public class Quotation : IndexedObject
    {
        public Quotation()
        {
        }
        #region Dynamic
        private Supplier supplier = null;
        private PurchaseRequest purchaseRequest = null;
        public Supplier GetSupplier(ApplicationDbContext db)
        {
            if (supplier == null)
                supplier = db.Suppliers.Find(SupplierId);
            return supplier;
            
        }
        public PurchaseRequest GetPurchaseRequest(ApplicationDbContext db)
        {
            if (purchaseRequest == null)
                purchaseRequest = db.PurchaseRequests.Find(SupplierId);
            return purchaseRequest;
        }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        public int PurchaseRequestId { get; set; }
        public int SupplierId { get; set; }
        public QuatationStatus Status { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
    }
}
