using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Manager;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Controllers
{
    public class ClassRoomController : Controller
    {

        private AllocateClassRoomManager allocateClassRoomManager;
        private DepartmentManager departmentManager;
        private CourseManager courseManager;
        private RoomManager roomManager;
        private DayManager dayManager;
        public ClassRoomController()
        {
            allocateClassRoomManager = new AllocateClassRoomManager();
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
            roomManager = new RoomManager();
            dayManager = new DayManager();
        }
        //
        // GET: /ClassRoom/
      

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
            ViewBag.Courses = courseManager.GetAllCoursesForDropdown();
            ViewBag.Rooms = roomManager.GetAllRoomsforDropDown();
            ViewBag.Days = dayManager.GetAllDayList();
            return View();
        }

        [HttpPost]
        public ActionResult Save(AllocateClassroom allocateClassroom)
        {

            if (ModelState.IsValid)
            {
                string message = allocateClassRoomManager.Save(allocateClassroom);
                ViewBag.Message = message;
                ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
                ViewBag.Courses = courseManager.GetAllCoursesForDropdown();
                ViewBag.Rooms = roomManager.GetAllRoomsforDropDown();
                ViewBag.Days = dayManager.GetAllDayList();
                return View();
            }
            else
            {
                ViewBag.Message = "Model State is Invalid";
                return View();
            }

        }



        [HttpGet]
        public ActionResult ClassSchedule()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult ClassSchedule(ClassSchedule classSchedule)
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentsForDropdown();
            return View();
        }
	}
}