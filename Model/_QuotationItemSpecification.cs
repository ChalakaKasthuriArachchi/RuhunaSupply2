using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RuhunaSupply.Model
{
    public class _QuotationItemSpecification
    {
        public _QuotationItemSpecification()
        { 
        }
        #region Dynamic
        public QuotationItem QuatationItem { get; set; }
        public Specification Specification { get; set; }
        #endregion
        #region Saved
        [Key]
        public int Id { get; set; }
        public int QuatationItemId { get; set; }
        public int SpecificationId { get; set; }
        [Column(TypeName ="nvarchar(20)")]
        public string Satisfied { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        #endregion
    }
}
