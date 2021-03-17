using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class SemesterManager
    {
        private SemesterGateway semesterGateway;

        public SemesterManager()
        {
            semesterGateway=new SemesterGateway();
        }

        public List<Semester> GetSemesters()
        {
            return semesterGateway.GetSemesters();
        }

        public List<SelectListItem> GetAllSemesterForDropdown()
        {
            List<Semester> semesters = GetSemesters();
            List<SelectListItem> selectListItems = semesters.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });
            List<SelectListItem> selectItem = new List<SelectListItem>();
            selectItem.Add(new SelectListItem() { Text = "--Select--", Value = "" });
            selectItem.AddRange(selectListItems);
            return selectItem;
        } 
    }
}