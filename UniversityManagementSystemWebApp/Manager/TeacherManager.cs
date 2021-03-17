using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway;
        private DepartmentManager departmentManager;

        public TeacherManager()
        {
            teacherGateway=new TeacherGateway();
            departmentManager=new DepartmentManager();
        }

       
        public string Save(Teacher teacher)
        {
            if (teacher.Address == null)
            {
                teacher.Address = " ";
            }
            if (teacherGateway.IsEmailExsists(teacher.Email))
            {
                return "This Email Already Added";
            }
            else
            {
                int rowAffect = teacherGateway.Save(teacher);
                if (rowAffect > 0)
                {
                    return "Save Successfully";
                }
                else
                {
                    return "Save Failed";
                }
            }
        }

        public List<Department> GetDepartments()
        {
            return departmentManager.GetAllDepartments();
        }

        public List<Teacher> GetTeacherId(int teacherId)
        {
            return teacherGateway.GetTeacherId(teacherId);
        }
    }
}