using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class LabAssayQuotes
    {
        [Key]
        [DisplayName("Assay ID")]
        public String AssayID { get; set; }

        [DisplayName("Assay Name")]
        public String AssayName { get; set; }

        [DisplayName("Assay Description")]
        public String AssayDescription { get; set; }

        [DisplayName("Estimated Time")]
        public TimeSpan EstimatedTime { get; set; }

        [DisplayName("Estimated Price")]
        public decimal AssayQuote { get; set; }
    }
}