using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Compound")]
    public class Compound
    {
        [Key]
        [DisplayName("Labs Test Number")]
        public int LTNumber { get; set; }

        [ForeignKey("WorkOrder")]
        [DisplayName("Work Order Number")]
        public virtual int WorkOrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        [DisplayName("Compound Name")]
        [Required(ErrorMessage = "Please Enter a Compound Name")]
        public string CompoundName { get; set; }

        [DisplayName("Compound Description")]
        [Required(ErrorMessage = "Please Enter a Compound Description")]
        public string CompoundDescription { get; set; }

        [DisplayName("Appearance Description")]
        //[Required(ErrorMessage = "Please Enter a Compound Description")]
        public string AppearanceDescription { get; set; }

        [DisplayName("Molecular Mass")]
        //[Required(ErrorMessage = "Please Enter the Molecular Mass")]
        public decimal? MolecularMass { get; set; }

        [DisplayName("Combined Weight")]
        //[Required(ErrorMessage = "Please Enter the Combined Weight")]
        public int? CombinedWeight { get; set; }

        [DisplayName("Maximum Tolerated Dose")]
        //[Required(ErrorMessage = "Please Enter the Maximum Tolerated Dose")]
        public int? MaxToleratedDose { get; set; }
    }
}