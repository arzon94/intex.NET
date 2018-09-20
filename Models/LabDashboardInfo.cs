using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class LabDashboardInfo
    {
        [DisplayName("Work Order")]
        public int WorkOrderID { get; set; }
 
        [DisplayName("Compound")]
        public String CompoundName { get; set; }
    
        [Key]
        [DisplayName("Lab Test Number")]
        public int LTNumber { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Order Status")]
        public String StatusDescription { get; set; }

        [DisplayName("CompleteDate")]
        public DateTime? CompleteDate { get; set; }
    }
}