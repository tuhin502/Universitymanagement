using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Manager
{
    public class CourseManager
    {
        private CourseGateway courseGateway;

        public CourseManager()
        {
            courseGateway=new CourseGateway();
        }

        public string Save(Course course)
        {
            if (course.Description == null)
            {
                course.Description = " ";
            }
            if (IsCourseCodeExist(course.Code) && IsCourseNameExist(course.Name))
            {
                return "Course Code & Name already Exist";
            }
            else if (IsCourseCodeExist(course.Code))
            {
                return "Course Code already Exist";
            }
            else if (IsCourseNameExist(course.Name))
            {
                return "Course Name already Exist";
            }
            else
            {
                int rowAffect = courseGateway.Save(course);
                if (rowAffect > 0)
                {
                    return "Save successful";
                }
                else
                {
                    return "Save Failed";
                }
            }

        }

        public bool IsCourseCodeExist(string code)
        {
            return courseGateway.IsCourseCodeExist(code);
        }
        public bool IsCourseNameExist(string name)
        {
            return courseGateway.IsCourseNameExist(name);
        }

        public List<Course> GetCourses()
        {
            return courseGateway.GetCourses();
        }
        public List<SelectListItem> GetAllCoursesForDropdown()
        {
            List<Course> Courses = GetCourses();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (Course course in Courses)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = course.Code;
                selectListItem.Value = course.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public List<SelectListItem> GetAllCourse()
        {
            List<Course> Courses = GetCourses();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (Course course in Courses)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = course.Name;
                selectListItem.Value = course.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public List<Course> GetCoursesById(int departmentId)
        {
            return courseGateway.GetCoursesById(departmentId);
        }
        
    }
}