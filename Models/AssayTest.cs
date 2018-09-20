using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("AssayTest")]
    public class AssayTest
    {
        [Column(Order = 0), Key]
        [DisplayName("Assay ID")]
        public virtual string AssayID { get; set; }
        public virtual Assay Assay { get; set; }

        [Column(Order = 1), Key]
        [DisplayName("Test ID")]
        public virtual int TestID { get; set; }
        public virtual Test Test { get; set; }

        [DisplayName("Condition ID")]
        public int ConditionID { get; set; }
    }
}