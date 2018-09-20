using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class LabAssaySchedule
    {
        [Key]
        [DisplayName("Work Order Number")]
        public int WorkOrderID { get; set; }

        [DisplayName("Assay")]
        public String AssayName { get; set; }

        [DisplayName("Description")]
        public String AssayDescription { get; set; }

        [DisplayName("Date Scheduled")]
        public DateTime? ScheduledDate { get; set; }

        [DisplayName("Date Completed")]
        public DateTime? CompletionDate { get; set; }

        [DisplayName("Assay Length (In Hours)")]
        public TimeSpan EstimatedTime { get; set; }
    }
}