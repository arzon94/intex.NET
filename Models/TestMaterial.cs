using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("TestMaterial")]
    public class TestMaterial
    {
        [Column(Order = 0), Key]
        [DisplayName("Material ID")]
        public virtual int MaterialID { get; set; }
        public virtual Material Material { get; set; }
        [Column(Order = 1), Key]
        [DisplayName("Test ID")]
        public virtual int TestID { get; set; }
        public virtual Test Test { get; set; }
    }
}