using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class WorkOrderInfo
    {
        [Key]
        [Display(Name = "Order Number")]
        public int WorkOrderID { get; set; }

        [Display(Name = "Compound")]
        public string CompoundName { get; set; }

        public int? LTNumber { get; set; }

        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Completed Date")]
        public DateTime? CompleteDate { get; set; }

        [Display(Name = "Status")]
        public string StatusDescription { get; set; }

        [Display(Name = "Total Price")]
        public decimal? TotalPrice { get; set; }
    }
}