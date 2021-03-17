using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseAssignToTeacherGateway:CommonGateway
    {
        public int Save(CourseAssignToTeacher courseAssign)
        {
            courseAssign.Status = "Yes";
            string query = "INSERT INTO CourseAssignToTeacher VALUES(@departmentId,@teacherId,@courseCode,@status)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@departmentId", courseAssign.DepartmentId);
            Command.Parameters.AddWithValue("@teacherId", courseAssign.TeacherId);
            Command.Parameters.AddWithValue("@status", courseAssign.Status);

            Command.Parameters.AddWithValue("@courseCode", courseAssign.CourseCode);


            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        

       

        
        public bool IsSubjectAssigned(CourseAssignToTeacher courseAssign)
        {

            string query = "SELECT * FROM CourseAssignToTeacher WHERE CourseCode='" + courseAssign.CourseCode + "' AND TeacherId='" + courseAssign.TeacherId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public int UnAssignCourse()
        {
            string query = "UPDATE CourseAssignToTeacher SET Status = 'NO'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;

        }
        
        

        
    }
}