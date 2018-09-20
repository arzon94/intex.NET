using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("OrderedAssay")]
    public class OrderedAssay
    {
        [Key, Column(Order = 0)]
        [DisplayName("Work Order ID")]
        public virtual int WorkOrderID { get; set; }
        public virtual WorkOrder workorder { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("Assay ID")]
        public virtual String AssayID { get; set; }
        public virtual Assay assay { get; set; }

        //[Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Result File Location")]
        //[StringLength(50, ErrorMessage = "Field Must Be Shorter Than 50 Characters!")]
        public String ResultFile { get; set; }

        [DisplayName("Scheduled Date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ScheduledDate { get; set; }

        [DisplayName("Completion Date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? CompletionDate { get; set; }
    }
}