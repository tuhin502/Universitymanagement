using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class GradeManager
    {
        private GradeGateway gradeGateway;

        public GradeManager()
        {
            gradeGateway=new GradeGateway();
        }

        public List<Grade> GetAllGrade()
        {
            return gradeGateway.GetAllGrade();
        }

        public List<SelectListItem> GetAllGreadForDropdown()
        {
            List<Grade> gradeLetters = GetAllGrade();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = "",
            });
            foreach (var grade in gradeLetters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = grade.Name;
                selectListItem.Value = grade.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        } 
    }
}