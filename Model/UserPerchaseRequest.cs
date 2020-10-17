using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class UserPerchaseRequest
    {
        public UserPerchaseRequest()
        {

        }

     
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
      
        public int PurchaseRequestId { get; set; }
    }
}

