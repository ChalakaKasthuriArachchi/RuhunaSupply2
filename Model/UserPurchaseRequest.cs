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
        public int PurchaseRequest { get; set; }
        public DateTime Date { get; set; }
        public Involvements Involvement { get; set; }
    }
}

