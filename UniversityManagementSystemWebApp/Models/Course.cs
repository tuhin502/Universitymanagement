using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystemWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Code must be 5 character long")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.5, 5.0, ErrorMessage = "Credit Must Be Between 0.5 To 5.0)")]
        public double Credit { get; set; }
        public string Description { get; set; }
        [Required]
        [Display (Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        
    }
}