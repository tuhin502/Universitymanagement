using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DesignationManager
    {
        private DesignationGateway designationGateway;

        public DesignationManager()
        {
            designationGateway=new DesignationGateway();
        }

        public List<Designation> GetAllDesignation()
        {
            return designationGateway.GetAllDesignations();
        }

        public List<SelectListItem> GetAllDesignationsForDropdown()
        {
            List<Designation> designations = GetAllDesignation();
            List<SelectListItem> selectListItems = designations.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            List<SelectListItem> slectItem = new List<SelectListItem>();
            slectItem.Add(new SelectListItem() { Text = "--Select--", Value = "" });
            slectItem.AddRange(selectListItems);

            return slectItem;
        } 
    }
}