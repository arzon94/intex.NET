using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Position")]
    public class Position
    {
        [Key]
        [DisplayName("Position Code")]
        public int PositionCode { get; set; }
        [DisplayName("Position Description")]
        public string PositionDescription { get; set; }
    }
}