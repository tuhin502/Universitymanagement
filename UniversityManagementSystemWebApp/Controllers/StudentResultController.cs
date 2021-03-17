using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class StudentResultController : Controller
    {
        private GradeManager gradeManager;
       
        private StudentResultManager studentResultManager;
        private EnrollManager enrollManager;

        public StudentResultController()
        {
            gradeManager=new GradeManager();
            
            studentResultManager=new StudentResultManager();
            enrollManager=new EnrollManager();
        }
        //
        // GET: /StudentResult/
        public ActionResult Save()
        {
            ViewBag.RegNo = enrollManager.GetAllRegNoForDropdown();
            ViewBag.Grades = gradeManager.GetAllGreadForDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Save(StudentResult studentResult)
        {

            string message = studentResultManager.Save(studentResult);
            ViewBag.RegNo = enrollManager.GetAllRegNoForDropdown();
            ViewBag.Grades = gradeManager.GetAllGreadForDropdown();
            ViewBag.Message = message;
            ModelState.Clear();
            return View();
        }

        public JsonResult GetRegNoByStudentInfo(int registrationNo)
        {
            List<EnrollViewModel> studentResultViewModels = enrollManager.GetStudentNoByView(registrationNo);
            return Json(studentResultViewModels);
        }



        public ActionResult ViewResult()
        {
            ViewBag.RegNo = enrollManager.GetAllRegNoForDropdown();
            return View();
        }

        public JsonResult GetResultInfoByRegNo(int registrationNo)
        {
            List<StudentResultViewModel> studentResultViewModels = studentResultManager.GetStudentResultInfoByRegNo(registrationNo);
            return Json(studentResultViewModels);
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
	}
}