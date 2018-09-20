using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [DisplayName("Invoice ID")]
        public int InvoiceID { get; set; }

        [Required]
        [DisplayName("Invoice Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DueDate { get; set; }

        [Required]
        [DisplayName("Invoice Early Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EarlyDate { get; set; }

        [Required]
        [DisplayName("Order Total")]
        public decimal OrderTotal { get; set; }

        [DisplayName("Discount")]
        public decimal Discount { get; set; }

        [Required]
        [DisplayName("TotalPrice")]
        public decimal TotalPrice { get; set; }

        [Required]
        [DisplayName("WorkOrderID")]
        [ForeignKey("WorkOrder")]
        public virtual int WorkOrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        [ForeignKey("Customer")]
        public virtual int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}