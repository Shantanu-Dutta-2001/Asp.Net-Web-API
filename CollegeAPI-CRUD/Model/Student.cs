using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CollegeAPI_CRUD.Validation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CollegeAPI_CRUD.Model
{
    public class Student
    {
        [ValidateNever]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(30)]
        public string StudentName { get; set; }
        [Range(10, 20)]
        public int Age { get; set; }
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        // [DateCheck]
        // public DateTime AddmissionDate { get; set; }
    }
}