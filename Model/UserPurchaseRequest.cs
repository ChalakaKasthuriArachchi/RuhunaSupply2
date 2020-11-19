using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class UserPurchaseRequest
    {
        public UserPurchaseRequest()
        {

        }

     
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public PurchaseRequest PurchaseRequest { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(200)]
        public string Remark { get; set; }
        public Involvements Involvement { get; set; }
    }
}

