using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class TestInfo
    {
        [Key]
        [ScaffoldColumn(true)]
        [Display(Name = "Test Number")]
        public int TestInstanceID { get; set; }

        [Display(Name = "Start Time")]
        public DateTime TestStartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime TestEndTime { get; set; }

        [Display(Name = "Clear Results?")]
        public string ClearResult { get; set; }

        [Display(Name = "Test Result File")]
        public string TestResult { get; set; }
    }
}