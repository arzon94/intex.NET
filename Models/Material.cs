using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        [DisplayName("Material ID")]
        public int MaterialID { get; set; }

        [Required]
        [DisplayName("Material Name")]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters!")]
        public String DueDate { get; set; }

        [Required]
        [DisplayName("Material Price")]
        public decimal MaterialPrice { get; set; }
    }
}