using cmlMySqlStandard;
using RuhunaSupply.Common;
using RuhunaSupply.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class UserPurchaseRequest : IndexedObject
    {
        public UserPurchaseRequest()
        {

        }
        #region Dynamic
        public User User
        {
            get
            {
                return Cache.GetUser(UserId, true);
            }
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
        public int UserId { get; set; }
        public int PurchaseRequestId { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(200)]
        public string Remark { get; set; }
        public Involvements Involvement { get; set; }
        public bool IsDeleted { get; set; }

        public int Index => Id;
        #endregion
    }
}

