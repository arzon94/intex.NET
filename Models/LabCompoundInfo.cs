using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class LabCompoundInfo
    {


        [Key]
        [DisplayName("Lab Test Number")]
        public int LTNumber { get; set; }

        [DisplayName("Compound")]
        public String CompoundName { get; set; }

        [DisplayName("Name")]
        public String CompoundDescription { get; set; }

        [DisplayName("Description")]
        public String AppearanceDescription { get; set; }

        [DisplayName("Molecular Mass")]
        public decimal MolecularMass { get; set; }

        [DisplayName("Weight")]
        public int CombinedWeight { get; set; }

        [DisplayName("Maximum Tolerated Dose")]
        public int? MaxToleratedDose { get; set; }

        [DisplayName("Assay")]
        public String AssayName { get; set; }

        [DisplayName("Assay ID")]
        public String AssayID { get; set; }

        [DisplayName("Assay Description")]
        public String AssayDescription { get; set; }

        [DisplayName("Scheduled Date")]
        public DateTime? ScheduledDate { get; set; }

        [DisplayName("Completion Date")]
        public DateTime? CompletionDate { get; set; }

        [DisplayName("Estimated Time")]
        public TimeSpan EstimatedTime { get; set; }

        [DisplayName("Estimated Price Quote")]
        public decimal AssayQuote { get; set; }
    }
}