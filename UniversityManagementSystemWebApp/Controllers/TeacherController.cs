using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        private TeacherManager teacherManager;
        private DesignationManager designationManager;
        private DepartmentManager departmentManager;

        public TeacherController()
        {
            teacherManager = new TeacherManager();
            designationManager = new DesignationManager();
            departmentManager = new DepartmentManager();
        }
        public string Index()
        {
            return "Hello From Teacher/Index";
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Designation = designationManager.GetAllDesignationsForDropdown();
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {

            if (ModelState.IsValid)
            {

                string message = teacherManager.Save(teacher);
                ViewBag.Message = message;
                ViewBag.Designation = designationManager.GetAllDesignationsForDropdown();
                ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
                ModelState.Clear();
                return View();

            }
            else
            {
                ViewBag.Message = "Model State is Invalid";
                return View();
            }
        }
    }
}