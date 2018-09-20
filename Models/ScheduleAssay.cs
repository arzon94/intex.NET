using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class ScheduleAssay
    {
        [Key, Column(Order = 0)]
        [DisplayName("Work Order ID")]
        public virtual int WorkOrderID { get; set; }
        public virtual WorkOrder workorder { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("Assay ID")]
        public virtual String AssayID { get; set; }
        public virtual Assay assay { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime ScheduledDate { get; set; }
    }
}