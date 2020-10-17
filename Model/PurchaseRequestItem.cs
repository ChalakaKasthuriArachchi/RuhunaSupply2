using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class PurchaseRequestItem
    {
        public PurchaseRequestItem()
        {

        }
        [Key]
        public int Id { get; set; }
       
        public double Cost { get; set; }

        public int QtyRequired { get; set; }

        public int QtyAlreadyAvailable { get; set; }

        public int QtySupplied { get; set; }

        public double Rate { get; set; }

        public double TotalValue { get; set; }

        public DateTime Date { get; set; }


    }
}
