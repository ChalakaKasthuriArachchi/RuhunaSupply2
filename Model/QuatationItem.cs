using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static RuhunaSupply.Common.MyEnum;

namespace RuhunaSupply.Model
{
    public class QuatationItem
    {
        public QuatationItem() 
        {
        }

        [Key]
        public int Id { get; set; }

        public Quatation Quatation { get; set; }
        public PurchaseRequestItem PurchaseRequestItem { get; set; }
        public Item Item { get; set; }

        public QuatationStatus Status { get; set; }

        public string IsSupply { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Description { get; set; }

        public int Qty { get; set; }
        public int Total { get; set; }
        public string Rate { get; set; }
    }
}
