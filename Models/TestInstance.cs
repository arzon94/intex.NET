using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("TestInstance")]
    public class TestInstance
    {
        [Key, Column(Order = 0)]
        [DisplayName("TestInstance ID")]
        public int TestInstanceID { get; set; }
        [Key, Column(Order = 1)]
        [DisplayName("Test ID")]
        public virtual int TestID { get; set; }
        public virtual Test test { get; set; }
        [Key, Column(Order = 2)]
        [DisplayName("Sample ID")]
        public virtual int SampleID { get; set; }
        public virtual Sample sample { get; set; }
        [Required]
        [DisplayName("Test Start Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TestStartTime { get; set; }
        [Required]
        [DisplayName("Test End Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TestEndTime { get; set; }
        [Required]
        [DisplayName("Test Result File Location")]
        [StringLength(100, ErrorMessage = ("Please Enter the File Location for the Test Results"))]
        public String TestResult { get; set; }
        [Required]
        [DisplayName("Clear Results")]
        [StringLength(1, ErrorMessage = ("Please Enter 0 or 1"))]
        public String ClearResult { get; set; }
    }
}