using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        //
        // GET: /CourseAssign/
        private CourseAssignToTeacherManager courseAssignToTeacherManager;
        private TeacherManager teacherManager;
        private DepartmentManager departmentManager;
        private CourseManager courseManager;
        public CourseAssignToTeacherController()
        {
            courseAssignToTeacherManager=new CourseAssignToTeacherManager();
            teacherManager=new TeacherManager();
            departmentManager=new DepartmentManager();
            courseManager=new CourseManager();
        }


        [HttpGet]
        public ActionResult CourseAssignToTeacher()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();

            return View();
        }
        [HttpPost]
        public ActionResult CourseAssignToTeacher(CourseAssignToTeacher courseAssign)
        {
            if (ModelState.IsValid)
            {
                string message = courseAssignToTeacherManager.Save(courseAssign);
                ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
                ViewBag.Message = message;
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.Message = "Model is not valid";
                return View();
            }
        }
        public JsonResult GetDepartmentId(int departmentId)
        {
            List<CourseAssignViewModel> courseAssignView= courseAssignToTeacherManager.GetTeachersByDepartmentId(departmentId);
            return Json(courseAssignView);
        }

        public JsonResult GetDepartmentIdByCourse(int departmentId)
        {
            List<CourseAssignViewModel> courseAssignView1 = courseAssignToTeacherManager.GetCoursesByDepartmentId(departmentId);
            return Json(courseAssignView1);
        }
        public JsonResult GetCourseId(int courseId)
        {
            List<Course> courseAssignViews = courseAssignToTeacherManager.GetCourseCode(courseId);
            return Json(courseAssignViews);
        }
        public JsonResult GetTeacherId(int teacherId)
        {
            List<Teacher> courseAssignViewsTeachers = teacherManager.GetTeacherId(teacherId);
            return Json(courseAssignViewsTeachers);
        }

        public ActionResult ViewCourseStatistics()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
            return View();
        }

        public JsonResult GetDepartmentByCourseView(int departmentId)
        {
            List<CourseStaticViewModel> courseModel = courseAssignToTeacherManager.GetCourseInfo(departmentId);
            return Json(courseModel);
        }
	}
}