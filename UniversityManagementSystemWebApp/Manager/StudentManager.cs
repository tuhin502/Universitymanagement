using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Manager
{
    public class StudentManager
    {
        private StudentGateway studentGateway;
        DepartmentGateway departmentGateway = new DepartmentGateway();

        public StudentManager()
        {
            studentGateway = new StudentGateway();
        }

        public string Save(Student student)
        {
            bool isEmailExist = studentGateway.IsEmailExist(student.Email);
            if (isEmailExist == false)
            {
                student.Year = student.Date.Year;
                int counter = studentGateway.StudentCounter(student.DepartmentId, student.Year);
                if (counter < 10)
                {
                    student.RegNo = departmentGateway.GetDepartmentCodeByDepartmentId(student.DepartmentId) + "-" + student.Date.Year + "-00" + counter;

                }
                else if (counter < 100)
                {
                    student.RegNo = departmentGateway.GetDepartmentCodeByDepartmentId(student.DepartmentId) + "-" + student.Date.Year + "-0" + counter;

                }
                else
                {
                    student.RegNo = departmentGateway.GetDepartmentCodeByDepartmentId(student.DepartmentId) + "-" + student.Date.Year + "-" + counter;

                }
                int rowAffect = studentGateway.Save(student);
                if (rowAffect > 0)
                {
                    return "Save Successful";
                    //return "Save Successful    Name: " + student.Name + "    Email: " + student.Email + "     ContactNo: " + student.ContactNo + "     Date: " + student.Date + "    Address:" +student.Address+
                    //    "    Department= "+departmentGateway.GetDepartmentById(student.DepartmentId)+"     RegNo: " +student.RegNo;
                }
                else
                {
                    return "Save Failed";
                }
            }
            else
            {
                return "Email Already Exist";
            }

        }
        //private StudentGateway studentGateway;

        //public StudentManager()
        //{
        //    studentGateway=new StudentGateway();
        //}

        //public List<Department> GetAllDepartments()
        //{
        //    return studentGateway.GetAllDepaertments();
        //}

        //public List<SelectListItem> GetSelectDropdownList()
        //{
        //    List<Department> departments = GetAllDepartments();
        //    List<SelectListItem> selectListItems=new List<SelectListItem>();
        //    selectListItems.Add(new SelectListItem()
        //    {
        //        Text = "--Select--",
        //        Value = ""
        //    });
        //    foreach (var department in departments)
        //    {
        //        SelectListItem selectListItem=new SelectListItem();
        //        selectListItem.Value = department.Id.ToString();
        //        selectListItem.Text = department.Code;
        //        selectListItems.Add(selectListItem);
        //    }
        //    return selectListItems;
        //}

        ////public int GetStudentCountByYearAndDepartment(int departmentId, int year)
        ////{
        ////    return studentGateway.GetStudentCountByYearAndDepartment(departmentId, year);
        ////}

        //public StudentViewModel GetStudentInfoByRagNo(string RegistrationNo)
        //{
        //    return studentGateway.GetStudentInfoByRagNo(RegistrationNo);
        //}

        //public int GetAllStudent(int departmentId)
        //{
        //    return studentGateway.GetAllStudent(departmentId);
        //}

        //public string Save(Student student)
        //{
        //    if (studentGateway.IsNameExsists(student))
        //    {
        //        return "This Email Already Exist";
        //    }
        //    else
        //    {
        //        int rowAffect = studentGateway.Save(student);
        //        if (rowAffect > 0)
        //        {
        //            return "Save Success";
        //        }
        //        else
        //        {
        //            return "Failed";
        //        }
        //    }
        //}

        public List<Student> GetAllStudentRegNo()
        {
            return studentGateway.GetAllStudentRegNo();
        }

        public List<SelectListItem> GetSelectListItemsForDropdown()
        {
            List<Student> students = GetAllStudentRegNo();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Text = "--Select--",
                Value = ""
            });
            foreach (Student student in students)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = student.RegNo;
                selectListItem.Value = student.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

        public List<StudentResultViewModel> GetRegNoByStudentInfo(int RegistrationNo)
        {
            return studentGateway.GetRegNoByStudentInfo(RegistrationNo);
        }

        
    }
}