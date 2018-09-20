using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        [DisplayName("Status Code")]
        public int StatusCode { get; set; }
        [Required(ErrorMessage = "What's the Status?")]
        [DisplayName("Status Name")]
        [StringLength(30, ErrorMessage = "The Status Must Be Less Than 30 Characters")]
        public String StatusDescription { get; set; }
    }
}