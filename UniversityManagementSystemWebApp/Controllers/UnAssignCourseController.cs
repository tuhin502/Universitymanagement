using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnAssignCourseController : Controller
    {
       CourseAssignToTeacherManager courseAssignToTeacherManager = new CourseAssignToTeacherManager();
        //
        // GET: /UnAssignCourses/
        [HttpGet]
        public ActionResult UnAssign()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAssign(int id = 1)
        {
            ViewBag.Message = courseAssignToTeacherManager.UnAssignCourses();
            return View();
        }
	}
}