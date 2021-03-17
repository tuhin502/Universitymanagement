using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class GradeGateway:CommonGateway
    {
        public List<Grade> GetAllGrade()
        {
            string query = "SELECT * FROM Grade";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Grade> gradeLetters=new List<Grade>();
            while (Reader.Read())
            {
                Grade grade=new Grade();
                grade.Id = Convert.ToInt32(Reader["Id"]);
                grade.Name = Reader["Name"].ToString();
                gradeLetters.Add(grade);
            }
            Reader.Close();
            Connection.Close();
            return gradeLetters;
        } 
    }
}