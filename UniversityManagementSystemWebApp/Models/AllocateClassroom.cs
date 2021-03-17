using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class AllocateClassroom
    {
        public int Id { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int DayId { get; set; }
        //[DataType(DataType.Time)]
        public DateTime FromTime { get; set; }
        //[DataType(DataType.Time)]
        public DateTime ToTime { get; set; }
        public int Action { get; set; }
    }
}