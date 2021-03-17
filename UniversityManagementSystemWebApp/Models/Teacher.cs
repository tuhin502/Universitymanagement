using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Xsl;

namespace UniversityManagementSystemWebApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Contact No must be 11 Character long")]
        public string Contact { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [Required]
        [Display (Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Range(1, 500, ErrorMessage = "Credit Must be Positive")]
        [Display(Name = "Credit Taken")]
        public double CreditTaken { get; set; }
        public double RemainingCredit { get; set; }
    }
}