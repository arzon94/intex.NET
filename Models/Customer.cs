using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace intex.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please Enter a First Name")]
        public string CustFirstName { get; set; }
        [DisplayName("Last Name")]
        public string CustLastName { get; set; }
        [DisplayName("Street Address")]
        public string CustStreetAddress { get; set; }
        [DisplayName("City")]
        public string CustCity { get; set; }
        [DisplayName("State")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Please use the State Abbreviation")]
        public string CustState { get; set; }
        [DisplayName("Zip Code")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Must be 5 digits")]
        public string CustZipCode { get; set; }
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(\d{3}\)\s\d{3}-\d{4}", ErrorMessage = "(XXX) XXX-XXXX")]
        public string CustPhoneNumber { get; set; }
        [DisplayName("Company")]
        public string CustCompany { get; set; }
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "@ Sign Required")]
        [EmailAddress]
        public string CustEmail { get; set; }
    }
}