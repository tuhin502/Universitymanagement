using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager studentManager;
        private DepartmentManager departmentManager;

        public StudentController()
        {
            studentManager = new StudentManager();
            departmentManager = new DepartmentManager();
        }



        //
        // GET: /Student/
        public string Index()
        {
            return "Hello From Student/Index";
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();

            if (ModelState.IsValid)
            {

                string message = studentManager.Save(student);
                if (message == "Save Successful")
                {
                    List<string> details = new List<string>();
                    details.Add(student.Name);
                    details.Add(student.Email);
                    details.Add(student.ContactNo);
                    details.Add(student.Date.ToString());
                    details.Add(student.Address);
                    details.Add(departmentManager.GetDepartmentNameById(student.DepartmentId));
                    details.Add(student.RegNo);
                    ModelState.Clear();
                    ViewBag.Details = details;
                }
                ViewBag.Message = message;



                return View();
            }
            else
            {
                ViewBag.Message = "Model State is Invalid";
                return View();
            }

        }
















        ////
        //// GET: /Student/
        //private DepartmentManager departmentManager;
        //private StudentManager studentManager;

        //public StudentController()
        //{
        //    departmentManager=new DepartmentManager();
        //    studentManager=new StudentManager();
        //}
        //[HttpGet]
        //public ActionResult Save()
        //{
        //    ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Save(Student student)
        //{
            
        //        student.RegistrationNo = registrationNumber(student.DepartmentId, student.RegisterDate);
        //        ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
        //        ViewBag.StudentReg = student.RegistrationNo;
        //        ViewBag.Name = student.Name;
        //        ViewBag.Email = student.Email;
        //        ViewBag.Contact = student.Contact;
        //        ViewBag.RegDate = student.RegisterDate;
        //        //string message = studentManager.Save(student);

        //        //ViewBag.Message = message;
        //        //if (message == "Sucesess")
        //        //{
        //        //    ViewBag.StudentInfo = studentManager.GetStudentInfoByRagNo(student.RegistrationNo);
        //        //}
        //        ModelState.Clear();
        //        return View();
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.Message = "Model state is Invalide";
        //    //    return View();
        //    //}
        //}

        //public string registrationNumber(int departmentId,DateTime registerdate)
        //{
        //    string departmentCode = departmentManager.GetDepartmentById(departmentId).Name;
        //    int year = registerdate.Year;

        //    int num = 0;
        //    int count = studentManager.GetAllStudent(departmentId);
        //    count = count + 1;
        //    string countString = count.ToString();
        //    if (countString.Length == 1)
        //    {
        //        string newNumber = "00" + countString;
        //        string RegistrationNo = departmentCode + "-" + year.ToString() + "-"+newNumber;
        //        return RegistrationNo;
        //    }
        //    else if (countString.Length == 2)
        //    {
        //        string newNumber = "0" + countString;
        //        string RegistrationNo = departmentCode + "-" + year.ToString() + "-"+newNumber;
        //        return RegistrationNo;
        //    }
        //    else
        //    {
        //        string newNumber = countString;
        //        string RegistrationNo = departmentCode + "-" + year.ToString() + "-" + newNumber;
        //        return RegistrationNo;
        //    }
        //}
	}
}