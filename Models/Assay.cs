using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        public string AssayID { get; set; }

        [DisplayName("Assay Name")]
        [Required(ErrorMessage = "Please Enter an Assay Name")]
        public string AssayName { get; set; }

        [DisplayName("Assay Description")]
        [Required(ErrorMessage = "Please Enter an Assay Description")]
        public string AssayDescription { get; set; }

        [DisplayName("Estimated Time")]
        [Required(ErrorMessage = "Please Enter an Estimated Time")]
        public TimeSpan EstimatedTime { get; set; }
    }
}