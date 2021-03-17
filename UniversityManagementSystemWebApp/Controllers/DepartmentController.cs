using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        public string Index()
        {
            return "Hello From Department/index";

        }

        private DepartmentManager departmentManager;

        public DepartmentController()
        {
            departmentManager=new DepartmentManager();
        }

        

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Save(Department department)
        {
            string message = departmentManager.Save(department);
            ViewBag.Message = message;
            ModelState.Clear();
            return View();
        }

        public ActionResult DepartmentDetails()
        {
            ViewBag.Departments = GetAllDepartment();
            ModelState.Clear();
            //ViewBag.DepartmentDetails = department;
            return View();
        }

        public List<Department> GetAllDepartment()
        {

            return departmentManager.GetAllDepartment();
        }
       
    }
}