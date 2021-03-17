using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseGateway:CommonGateway
    {
        public int Save(Course course)
        {
            
            string query = "INSERT INTO Course VALUES(@code,@name,@credit,@description,@departmentId,@semesterId)";
            Command=new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@code", course.Code);
            Command.Parameters.AddWithValue("@name", course.Name);
            Command.Parameters.AddWithValue("@credit", course.Credit);
            Command.Parameters.AddWithValue("@description", course.Description);
            Command.Parameters.AddWithValue("@departmentId", course.DepartmentId);
            Command.Parameters.AddWithValue("@semesterId", course.SemesterId);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsCourseCodeExist(string code)
        {
            string qurey = "SELECT *FROM Course WHERE Code = @code";
            Command = new SqlCommand(qurey, Connection);
            Command.Parameters.AddWithValue("@code", code);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }
        public Course GetCourseId(int codeId)
        {
            string query = "SELECT Id,Name,Credit FROM Course WHERE Id='" + codeId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Course course = new Course();
            if (Reader.HasRows)
            {
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Credit = Convert.ToInt32(Reader["Credit"]);
                course.Name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return course;
        }
        public List<CourseAssignViewModel> GetCoursesByDepartmentId(int departmentId)
        {
            string query = "SELECT Course.Code,Course.Id AS CourseId FROM Department INNER JOIN Course ON Department.Id=Course.DepartmentId WHERE Department.Id=" + departmentId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseAssignViewModel> courseAssignViewModels = new List<CourseAssignViewModel>();
            while (Reader.Read())
            {
                CourseAssignViewModel courseAssignViewModel = new CourseAssignViewModel();
                courseAssignViewModel.CourseId = Convert.ToInt32(Reader["CourseId"]);
                courseAssignViewModel.CourseCode = Reader["Code"].ToString();
                courseAssignViewModels.Add(courseAssignViewModel);
            }
            Reader.Close();
            Connection.Close();
            return courseAssignViewModels;
        }
        public List<Course> GetCourseCode(int courseCode)
        {
            string query = "SELECT Id,Name,Credit FROM Course WHERE Id='" + courseCode + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            List<Course> courses = new List<Course>();
            if (Reader.HasRows)
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Name = Reader["Name"].ToString();
                course.Credit = float.Parse(Reader["Credit"].ToString());
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public bool IsCourseNameExist(string name)
        {
            string qurey = "SELECT *FROM Course WHERE NAME = @name";
            Command = new SqlCommand(qurey, Connection);
            Command.Parameters.AddWithValue("@name", name);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }

        public List<Department> GetDepartments()
        {
            string query = "SELECT * FROM Department";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            while (Reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Code = Reader["Code"].ToString();
                department.Name = Reader["Name"].ToString();

                departmentList.Add(department);
            }
            Connection.Close();
            return departmentList;
        }

        public List<Course> GetCourses()
        {
            string query = "SELECT * FROM Course";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                course.Credit = float.Parse(Reader["Credit"].ToString());

                courses.Add(course);
            }
            Connection.Close();
            return courses;
        }
        public List<CourseStaticViewModel> GetCourseInfo(int departmentId)
        {
            string query = "SELECT Course.Code,Course.Name,Semester.Name As Semester," +
                           "ISNULL(Teacher.Name,'Not Assigned Yet') AS TeacherAssign" +
                           " FROM Course LEFT JOIN CourseAssignToTeacher ON Course.Id=CourseAssignToTeacher.Id" +
                           " LEFT JOIN Teacher ON CourseAssignToTeacher.TeacherId=Teacher.Id" +
                           " LEFT JOIN Semester ON Course.SemesterId=Semester.Id WHERE" +
                           " Course.DepartmentId=" + departmentId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseStaticViewModel> courseStaticViewModels = new List<CourseStaticViewModel>();
            while (Reader.Read())
            {
                CourseStaticViewModel courseStaticViewModel = new CourseStaticViewModel();
                courseStaticViewModel.Code = Reader["Code"].ToString();
                courseStaticViewModel.Name = Reader["Name"].ToString();
                courseStaticViewModel.Semester = Reader["Semester"].ToString();
                courseStaticViewModel.Teacher = Reader["TeacherAssign"].ToString();
                courseStaticViewModels.Add(courseStaticViewModel);
            }
            Reader.Close();
            Connection.Close();
            return courseStaticViewModels;
        }

        public List<Course> GetCoursesById(int departmentId)
        {
            string query = "SELECT Id,Code,Name FROM Course WHERE DepartmentId=" + departmentId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course=new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Name = Reader["Code"].ToString();
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        
    }
}