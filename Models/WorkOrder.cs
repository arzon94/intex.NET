using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("WorkOrder")]
    public class WorkOrder
    {
        [Key]
        [DisplayName("Work Order ID")]
        public int WorkOrderID { get; set; }

        [ForeignKey("Status")]
        [DisplayName("Status Code")]
        public virtual int StatusCode { get; set; }
        public virtual Status Status { get; set; }

        [ForeignKey("Employee")]
        [DisplayName("Employee ID")]
        public virtual int? EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("Customer")]
        [DisplayName("Customer ID")]
        public virtual int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [DisplayName("Order Date")]
        //[Required(ErrorMessage = "Please Enter an Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Date of Completion")]
        //[Required(ErrorMessage = "Please Enter a Completion Date")]
        public DateTime? CompleteDate { get; set; }

        [DisplayName("Special Instructions")]
        public string SpecialInstructions { get; set; }

        [DisplayName("Quoted Price")]
        //[Required(ErrorMessage = "Please Enter a Quoted Price")]
        public decimal? QuotedPrice { get; set; }

        [DisplayName("Actual Price")]
        public decimal? TotalPrice { get; set; }
    }
}