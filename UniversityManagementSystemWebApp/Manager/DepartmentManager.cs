using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway;

        public DepartmentManager()
        {
            departmentGateway=new DepartmentGateway();
        }

        public string Save(Department department)
        {
            if (IsDepartmentCodeExist(department.Code) && IsDepartmentNameExist(department.Name))
            {
                return "Department Code & Name already Exist";
            }
            else if (IsDepartmentCodeExist(department.Code))
            {
                return "Department Code already Exist";
            }
            else if (IsDepartmentNameExist(department.Name))
            {
                return "Department Name already Exist";
            }
            else
            {
                int rowAffect = departmentGateway.Save(department);
                if (rowAffect > 0)
                {
                    return "Save successful";
                }
                else
                {
                    return "Save Failed";
                }
            }

        }
        public bool IsDepartmentCodeExist(string code)
        {
            return departmentGateway.IsDepartmentCodeExist(code);
        }
        public bool IsDepartmentNameExist(string name)
        {
            return departmentGateway.IsDepartmentNameExist(name);
        }




        public List<Department> GetAllDepartment()
        {
            return departmentGateway.GetAllDepartment();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return departmentGateway.GetDepartmentById(departmentId);
        }
        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartment();
        }

        public List<SelectListItem> GetAllDepartmentsForDropdown()
        {
            List<Department> departments = GetAllDepartment();
            List<SelectListItem> selectListItems = departments.ConvertAll(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() });

            List<SelectListItem> slectItem = new List<SelectListItem>();
            slectItem.Add(new SelectListItem() { Text = "--Select--", Value = "" });
            slectItem.AddRange(selectListItems);

            return slectItem;
        }

        public string GetDepartmentNameById(int id)
        {
            return departmentGateway.GetDepartmentNameById(id);
        }
    }
}