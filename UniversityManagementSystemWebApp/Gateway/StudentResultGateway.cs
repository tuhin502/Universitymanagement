using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class StudentResultGateway:CommonGateway
    {
        public int Save(StudentResult studentResult)
        {
            string query = "INSERT INTO StudentResult VALUES(@registrationNo,@courseId,@gradeId)";
            Command=new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@registrationNo", studentResult.RegistrationNo);
            Command.Parameters.AddWithValue("@courseId", studentResult.CourseId);
            Command.Parameters.AddWithValue("@gradeId", studentResult.GradeLetterId);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsResultExist(int regNo, int courseId)
        {
            string query = "SELECT * FROM StudentResult WHERE RegistrationNo='" + regNo + "'AND CourseId = "+courseId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExsists = Reader.HasRows;
            Connection.Close();
            return isExsists;
        }
        public List<StudentResultViewModel> GetStudentResultInfoByRegNo(int registrationNo)
        {
            string query = "SELECT Student.Name AS StudentName,Student.Email,Department.Name AS DepartmentName,Course.Code,Course.Name AS CourseName,Grade.Name FROM StudentResult INNER JOIN Student ON StudentResult.RegistrationNo=Student.Id INNER JOIN Course ON StudentResult.CourseId=Course.Id INNER JOIN Grade ON StudentResult.GradeId=Grade.Id INNER JOIN Department ON Course.DepartmentId=Department.Id WHERE StudentResult.RegistrationNo=" + registrationNo + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentResultViewModel> studentResultViews = new List<StudentResultViewModel>();
            while (Reader.Read())
            {
                StudentResultViewModel studentResultView = new StudentResultViewModel();
                studentResultView.Name = Reader["StudentName"].ToString();
                studentResultView.Email = Reader["Email"].ToString();
                studentResultView.DepartmentName = Reader["DepartmentName"].ToString();
                studentResultView.CourseCode = Reader["Code"].ToString();
                studentResultView.CourseName = Reader["CourseName"].ToString();
                studentResultView.GradeLetter = Reader["Name"].ToString();
                studentResultViews.Add(studentResultView);
            }
            Connection.Close();
            return studentResultViews;
        }
    }
}