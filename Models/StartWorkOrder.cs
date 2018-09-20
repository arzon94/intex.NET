using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class StartWorkOrder
    {
        [Key]
        public int WorkOrderID { get; set; }

        [Display(Name = "Compound Formula (ex: NaOH)")]
        public string CompoundName { get; set; }

        [Display(Name = "Compound Name (ex: Sodium Hydroxide)")]
        public string CompoundDescription { get; set; }

        [Display(Name = "Special Handling Instructions (if any)")]
        public string SpecialInstructions { get; set; }
    }
}