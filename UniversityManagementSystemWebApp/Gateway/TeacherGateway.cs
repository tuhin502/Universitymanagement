using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class TeacherGateway:CommonGateway
    {
        public int Save(Teacher teacher)
        {
            string query = "INSERT INTO Teacher VALUES(@name,@address,@email,@contact,@designationId,@departmentId,@creditTaken,@remainingCredit)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", teacher.Name);
            Command.Parameters.AddWithValue("@address", teacher.Address);
            Command.Parameters.AddWithValue("@email", teacher.Email);
            Command.Parameters.AddWithValue("@contact", teacher.Contact);
            Command.Parameters.AddWithValue("@designationId", teacher.DesignationId);
            Command.Parameters.AddWithValue("@departmentId", teacher.DepartmentId);
            Command.Parameters.AddWithValue("@creditTaken", teacher.CreditTaken);
            Command.Parameters.AddWithValue("@remainingCredit", teacher.CreditTaken);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsEmailExsists(string email)
        {

            string query = "SELECT * FROM Teacher WHERE Email='" + email + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExsists = Reader.HasRows;
            Connection.Close();
            return isExsists;
        }
       

        public List<Teacher> GetTeacherId(int teacherId)
        {
            string query = "SELECT Id,Name,CreditTaken,RemainingCredit FROM Teacher WHERE Id='" + teacherId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            List<Teacher> teachers = new List<Teacher>();
            if (Reader.HasRows)
            {
                Teacher aTeacher=new Teacher();
                aTeacher.Id = Convert.ToInt32(Reader["Id"]);
                aTeacher.Name = Reader["Name"].ToString();
                aTeacher.CreditTaken = Convert.ToSingle(Reader["CreditTaken"]);
                aTeacher.RemainingCredit = Convert.ToSingle(Reader["RemainingCredit"]);
                teachers.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }
        public Teacher GetAvailableCreditByTeacherId(int teacherId)
        {
            string query = "SELECT RemainingCredit FROM Teacher WHERE Id=" + teacherId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Teacher teacher = new Teacher();
            if (Reader.HasRows)
            {
                teacher.RemainingCredit = Convert.ToSingle(Reader["RemainingCredit"]);
            }
            Reader.Close();
            Connection.Close();
            return teacher;
        }
        public int UpdateTeacher(int Id, float remainingCredit)
        {

            string query = "UPDATE Teacher SET RemainingCredit='" + remainingCredit + "' WHERE Id=" + Id + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public List<CourseAssignViewModel> GetTeachersByDepartmentId(int departmentId)
        {
            string query = "SELECT Teacher.Name AS TeacherName,Teacher.Id AS TeacherId,Teacher.CreditTaken FROM Department INNER JOIN Teacher ON Teacher.DepartmentId=Department.Id WHERE Department.Id=" + departmentId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseAssignViewModel> courseAssignViewModels = new List<CourseAssignViewModel>();
            while (Reader.Read())
            {
                CourseAssignViewModel courseAssignViewModel = new CourseAssignViewModel();
                courseAssignViewModel.Id = Convert.ToInt32(Reader["TeacherId"]);
                courseAssignViewModel.Name = Reader["TeacherName"].ToString();
                courseAssignViewModel.CreditTaken = Convert.ToSingle(Reader["CreditTaken"]);
                courseAssignViewModels.Add(courseAssignViewModel);
            }
            Reader.Close();
            Connection.Close();
            return courseAssignViewModels;
        }


    }
}