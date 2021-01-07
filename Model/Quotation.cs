using cmlMySqlStandard;
using Microsoft.EntityFrameworkCore;
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
        #region Static
        internal static int GetNextId(ApplicationDbContext db)
        {
            Quotation pr =
                db.Quotations.FromSqlRaw("SELECT * FROM Quotations ORDER BY Id DESC").FirstOrDefault();
            if (pr == null)
                return 1;
            return pr.Id + 1;
        }
        #endregion
        
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
        public string StatusText => Status.ToString();
        public string DateText => Date.ToString("yyyy-MM-dd");
        #endregion
        #region Saved
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int PurchaseRequestId { get; set; }
        public int SupplierId { get; set; }
        public QuatationStatus Status { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public List<QuotationItem> QuotationItems { get; set; } =
            new List<QuotationItem>();
        public int Index => Id;
        public DateTime TimeStamp { get; set; }
        #endregion
    }
}
