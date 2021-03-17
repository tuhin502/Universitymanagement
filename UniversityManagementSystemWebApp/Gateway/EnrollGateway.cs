using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class EnrollGateway:CommonGateway
    {
        public List<EnrollViewModel> GetStudentNoByView(int registrationId)
        {
            string query = "SELECT Student.Name AS StudentName,Student.Email,Department.Name AS DepartmentName," +
                           "Course.Id,Course.Name AS CourseName FROM EnrollCourse INNER JOIN Student ON " +
                           "EnrollCourse.StudentId=Student.Id INNER JOIN Department ON " +
                           "Student.DepartmentId=Department.Id INNER JOIN Course ON " +
                           "EnrollCourse.CourseId=Course.Id WHERE EnrollCourse.StudentId="+registrationId+"";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<EnrollViewModel> enrollViewModels=new List<EnrollViewModel>();
            while (Reader.Read())
            {
                EnrollViewModel viewModel=new EnrollViewModel();
                viewModel.Name = Reader["StudentName"].ToString();
                viewModel.Email = Reader["Email"].ToString();
                viewModel.Department = Reader["DepartmentName"].ToString();
                viewModel.CourseName = Reader["CourseName"].ToString();
                viewModel.CourseId = Convert.ToInt32(Reader["Id"]);
                enrollViewModels.Add(viewModel);
            }
            Reader.Close();
            Connection.Close();
            return enrollViewModels;
        }

        

        public int Save(EnrollCourse enrollCourse)
        {
            string query = "INSERT INTO EnrollCourse VALUES(@registrationNo,@courseId,@date)";
            Command=new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@registrationNo", enrollCourse.StudentId);
            Command.Parameters.AddWithValue("@courseId", enrollCourse.CourseId);
            Command.Parameters.AddWithValue("@date", enrollCourse.Date);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsNameExsists(EnrollCourse enrollCourse)
        {
            string query = "SELECT * FROM EnrollCourse WHERE CourseId=" + enrollCourse.CourseId + " AND StudentId=" + enrollCourse.StudentId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public List<Student> GetAllStudentRegNo()
        {
            string query = "SELECT EnrollCourse.StudentId AS RegId,Student.RegNo AS RegName  FROM EnrollCourse INNER JOIN Student ON EnrollCourse.StudentId=Student.Id";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(Reader["RegId"]);
                student.RegNo = Reader["RegName"].ToString();
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }
    }
}