using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD.Models
{
    public class EmployeeForm
    {
        [HiddenInput(DisplayValue = false)]
        [Key] public int Id { get; set; }

        [Required]
        public int EmployeeCode { get; set; }

        [Required]
        public  string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public  DateTime DateofBirth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public  DateTime DateofJoining { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Invalid pattern.")]
        public  string EmailAddress { get; set; }

        [Required]
        
        [StringLength(10, ErrorMessage = "Invalid Number", MinimumLength = 10)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Enter Only Numbers")]
        public string PhoneNumber { get; set; }

        [Required]
        public  string Gender { get; set; }


    }
}
