using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TimePicker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TimePicker(Timepicker timepicker)
        {
            //timepicker.Time = TimeSpan.FromDays(1);
            return View();
        }
	}
}