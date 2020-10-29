using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class Quatation
    {
        public Quatation()
        {
        }
        [Key]
        public int Id { get; set; }
        public int PurchaseRequestId { get; set; }
        public int SupplyId { get; set; }
        public QuatationStatus Status { get; set; }
        public DateTime Date { get; set; }


    }
}
