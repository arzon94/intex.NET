using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("EmployeeTest")]
    public class EmployeeTest
    {
        [Key, Column(Order = 0)]
        [DisplayName("Employee ID")]
        public virtual int EmployeeID { get; set; }
        public virtual Employee employee { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("Test Instance ID")]
        public virtual int TestInstanceID { get; set; }
        public virtual TestInstance testinstance { get; set; }

        [DisplayName("Time Worked")]
        public int WorkedTime { get; set; }
    }
}