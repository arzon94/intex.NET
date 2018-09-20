using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using System.Web;
using System.ComponentModel;

namespace intex.Models
{
    public class Manager
    {
        //[Key]
        //[DisplayName("Invoice ID")]
        //public int InvoiceID { get; set; }

        //[Required]
        //[DisplayName("Order Total")]
        //public decimal OrderTotal { get; set; }

        //[DisplayName("Discount")]
        //public decimal Discount { get; set; }

        //[Required]
        //[DisplayName("TotalPrice")]
        //public decimal TotalPrice { get; set; }
        [Key]
        public Decimal sumInvoice { get; set; }
        public Decimal sumDiscount { get; set; }
        public Decimal avgQuotedPrice { get; set; }
        public Decimal avgTotalPrice { get; set; }
    }
}