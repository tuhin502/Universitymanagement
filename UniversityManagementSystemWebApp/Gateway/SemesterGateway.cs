using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class SemesterGateway:CommonGateway
    {
        public List<Semester> GetSemesters()
        {
            string query = "SELECT * FROM Semester";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> semesterList = new List<Semester>();
            while (Reader.Read())
            {
                Semester semester = new Semester();
                semester.Id = Convert.ToInt32(Reader["Id"]);
                semester.Name = Reader["Name"].ToString();

                semesterList.Add(semester);
            }
            Connection.Close();
            return semesterList;
        }
    }
}