using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key, Column(Order = 1)]
        [DisplayName("Employee ID")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("First Name")]
        [StringLength(25, ErrorMessage = "Field Must Be Shorter Than 25 Letters!")]
        public String EmpFirstName { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Last Name")]
        [StringLength(25, ErrorMessage = "Field Must Be Shorter Than 25 Letters!")]
        public String EmpLastName { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Employee Email")]
        [StringLength(50, ErrorMessage = "Field Must Be Shorter Than 50 Characters!")]
        public String EmpEmail { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Field Must Be 6 to 20 Characters!")]
        public String EmpPassword { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Street Address")]
        [StringLength(50, ErrorMessage = "Field Must Be Shorter Than 50 Characters!")]
        public String EmpStreetAddress { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("City")]
        [StringLength(30, ErrorMessage = "Field Must Be Shorter Than 30 Letters!")]
        public String EmpCity { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("State")]
        [StringLength(2, ErrorMessage = "Field Must Be 2 Letters!")]
        public String EmpState { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Zip Code")]
        [StringLength(5, ErrorMessage = "Field Must Be 5 Letters!")]
        public String EmpZipCode { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Area Code")]
        [StringLength(5, ErrorMessage = "Field Must Be Shorter Than 5 Numbers!")]
        public String EmpAreaCode { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Phone Number")]
        [StringLength(8, ErrorMessage = "Field Must Be Shorter Than 8 Numbers!")]
        public String EmpPhoneNumber { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Employee Wage")]
        public Decimal EmpWage { get; set; }

        //[Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Employee Postion")]
        //[StringLength(20, ErrorMessage = "Field Must Be Shorter Than 20 Letters!")]
        [ForeignKey("Position")]
        public virtual int? PositionCode { get; set; }
        public virtual Position Position { get; set; }

        [Required(ErrorMessage = "This Field Cannot Be Left Blank!")]
        [DisplayName("Office ID")]
        [ForeignKey("Office")]
        public virtual int EmpOfficeID { get; set; }
        public virtual Office Office { get; set; }
    }
}