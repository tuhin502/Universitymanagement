﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class CourseAssignToTeacher
    {
        public int Id { get; set; }
        [Required]
        [Display (Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        [Required]
        [Display(Name = "Course Code")]
        public int CourseCode { get; set; }

        public String Status { get; set; }
    }
}