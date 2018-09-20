using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("CompoundSequence")]
    public class CompoundSequence
    {
        [Column(Order = 0), Key]
        [DisplayName("Labs Test Number")]
        public virtual int LTNumber { get; set; }
        public virtual Compound Compound { get; set; }

        [Column(Order = 1), Key]
        [DisplayName("Sequence Code")]
        public int SequenceCode { get; set; }

        //[ForeignKey("OrderedAssay")]
        //[DisplayName("Assay ID")]
        //public virtual string AssayID { get; set; }
        //public virtual OrderedAssay OrderedAssay { get; set; }

        [DisplayName("Weight")]
        [Required(ErrorMessage = "Please Enter the Weight")]
        public int Weight { get; set; }

        [DisplayName("Date of Arrival")]
        [Required(ErrorMessage = "Please Enter the Date of Arrival")]
        public DateTime DateArrived { get; set; }
    }
}