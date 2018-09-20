using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class OrderedAssayInfo
    {
        [Key]
        [Display(Name = "Order Number")]
        public int WorkOrderID { get; set; }

        public int LTNumber { get; set; }

        [Display(Name = "Compound")]
        public string CompoundName { get; set; }

        [Display(Name = "Assay")]
        public string AssayName { get; set; }
    }
}