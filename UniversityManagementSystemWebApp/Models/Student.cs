using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        public string RegNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Contact No must be 11 Character long")]
        public string ContactNo { get; set; }
        [Required]
        //[DataType(DataType.Date)]
       
       
        public DateTime Date { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public int Year { get; set; }
    }
}