using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Manager
{
    public class CourseAssignToTeacherManager
    {
        private CourseAssignToTeacherGateway courseAssignToTeacherGateway;
        private TeacherGateway teacherGateway;
        private CourseGateway courseGateway;

        public CourseAssignToTeacherManager()
        {
            courseAssignToTeacherGateway=new CourseAssignToTeacherGateway();
            teacherGateway=new TeacherGateway();
            courseGateway =  new CourseGateway();
        }

        public string Save(CourseAssignToTeacher courseAssign)
        {
           
            if (courseAssignToTeacherGateway.IsSubjectAssigned(courseAssign))
            {
                return "This Course already Assigned";
            }
            else
            {
                float Credit = Convert.ToSingle(courseGateway.GetCourseId(courseAssign.CourseCode).Credit);
                float AvailableCredit = Convert.ToSingle(teacherGateway.GetAvailableCreditByTeacherId(courseAssign.TeacherId).RemainingCredit);
                float RemainingCredit = (AvailableCredit - Credit);

                if (RemainingCredit > 0)
                {
                    int rowAffect = teacherGateway.UpdateTeacher(courseAssign.TeacherId, RemainingCredit);
                    if (rowAffect > 0)
                    {
                        int affect = courseAssignToTeacherGateway.Save(courseAssign);
                        if (affect > 0)
                        {
                            return "Save Successfull";

                        }
                        else
                        {
                            return "Failed";
                        }
                    }

                    else
                    {
                        return "Failed";
                    }
                }
                else
                {
                    return "Not Enough Credit Left";
                }
            }

        }
       
        

        public List<CourseAssignViewModel> GetTeachersByDepartmentId(int departmentId)
        {
            return teacherGateway.GetTeachersByDepartmentId(departmentId);
        }
        public List<CourseAssignViewModel> GetCoursesByDepartmentId(int departmentId)
        {
            return courseGateway.GetCoursesByDepartmentId(departmentId);
        }

        public List<Course> GetCourseCode(int courseCode)
        {
            return courseGateway.GetCourseCode(courseCode);
        }

        public List<CourseStaticViewModel> GetCourseInfo(int departmentId)
        {
            return courseGateway.GetCourseInfo(departmentId);
        }


        public string UnAssignCourses()
        {
            int rowAffect = courseAssignToTeacherGateway.UnAssignCourse();
            if (rowAffect > 0)
            {
                return "Unassign Successfully!";
            }
            return "Unassign Failed";
        }
    }
}