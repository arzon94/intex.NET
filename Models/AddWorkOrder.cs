using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    public class AddWorkOrder
    {
        [Key]
        public int WorkOrderID { get; set; }

        //[ForeignKey("Assay")]
        [Display(Name = "Assay")]
        public string AssayID { get; set; }
        //public virtual Assay Assay {get; set;}
    }
}