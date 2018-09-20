using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class LabTestInfo
    {
        [Key]
        public int WorkOrderID { get; set; }

        [Display(Name = "Compound")]
        public string CompoundName { get; set; }

        [Display(Name = "Assay")]
        public String AssayName { get; set; }

        [DisplayName("Assay ID")]
        public String AssayID { get; set; }

        [DisplayName("Lab Test Number")]
        public int LTNumber { get; set; }

        [DisplayName("Sequence Code")]
        public int SequenceCode { get; set; }

        [DisplayName("Sample Number")]
        public int SampleID { get; set; }

        [Display(Name = "Test Number")]
        public int? TestID { get; set; }

        [DisplayName("Test Instance")]
        public int? TestInstanceID { get; set; }

        [Display(Name = "Start Time")]
        public DateTime? TestStartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime? TestEndTime { get; set; }

        [Display(Name = "Clear Result?")]
        public String ClearResult { get; set; }

        [DisplayName("Test Result File")]
        public String TestResult { get; set; }
    }
}