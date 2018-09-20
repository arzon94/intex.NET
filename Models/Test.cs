using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        [DisplayName("Test ID")]
        public int TestID { get; set; }
        [Required(ErrorMessage = "All Tests need a Time Estimate")]
        [DisplayName("Time Estimate (In Hours)")]
        public DateTime TimeEstimate { get; set; }
        [Required(ErrorMessage = "All Tests have a base price")]
        [DisplayName("Test Base Price")]
        public decimal TestBasePrice { get; set; }
    }
}