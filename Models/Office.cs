using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Office")]
    public class Office
    {
        [Key]
        [DisplayName("Office ID")]
        public int OfficeID { get; set; }
        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Office Phone Number")]
        [StringLength(15, ErrorMessage = "Field Must Be Shorter Than 15 Characters!")]
        public String Phone { get; set; }
        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Street Address 1")]
        [StringLength(50, ErrorMessage = "Field Must Be Shorter Than 50 Characters!")]
        public String StreetAddress1 { get; set; }
        [DisplayName("Street Address 2")]
        [StringLength(50, ErrorMessage = "Field Must Be Shorter Than 50 Characters!")]
        public String StreetAddress2 { get; set; }
        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("City")]
        [StringLength(30, ErrorMessage = "Field Must Be Shorter Than 30 Letters!")]
        public String City { get; set; }
        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Country")]
        [StringLength(30, ErrorMessage = "Field Must Be Less Than 30 Letters!")]
        public String Country { get; set; }
    }
}