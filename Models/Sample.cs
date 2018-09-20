using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Sample")]
    public class Sample
    {
        [Key, Column(Order = 0)]
        [DisplayName("Sample ID")]
        public virtual int SampleID { get; set; }
        [Key, Column(Order = 1)]
        [DisplayName("Lab Test Number")]
        public virtual String LTNumber { get; set; }
        public virtual CompoundSequence compoundsequence { get; set; }
        [Key, Column(Order = 2)]
        [DisplayName("Sequence Code")]
        public virtual int SequenceCode { get; set; }
        //public virtual CompoundSequence compoundsequence { get; set; }
        [Required(ErrorMessage = "Samples need weights!")]
        [DisplayName("Weight")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Samples need concentration amounts")]
        [DisplayName("Concentration")]
        public Decimal Concentration { get; set; }
    }
}