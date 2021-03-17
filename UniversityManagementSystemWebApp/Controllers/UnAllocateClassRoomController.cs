using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class UnAllocateClassRoomController : Controller
    {
        AllocateClassRoomManager allocateClassRoomManager = new AllocateClassRoomManager();
        //
        // GET: /UnAssignCourses/
        [HttpGet]
        public ActionResult UnAllocate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAllocate(int id = 1)
        {
            ViewBag.Message = allocateClassRoomManager.UnAllocateRooms();
            return View();
        }
	}
}