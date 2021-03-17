using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DepartmentGateway:CommonGateway
    {
        public int Save(Department department)
        {
            string query = "INSERT INTO Department VALUES(@code,@name)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", department.Code);
            Command.Parameters.AddWithValue("@name", department.Name);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public string GetDepartmentCodeByDepartmentId(int id)
        {
            string query = "SELECT * FROM Department WHERE Id =@id ";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            string code = null;
            if (Reader.HasRows)
            {

                code = Reader["Code"].ToString();


            }
            Reader.Close();
            Connection.Close();
            return code;
        }

        public bool IsDepartmentCodeExist(string code)
        {
            string qurey = "SELECT *FROM Department WHERE Code = @code";
            Command = new SqlCommand(qurey, Connection);
            Command.Parameters.AddWithValue("@code", code);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }
        public bool IsDepartmentNameExist(string name)
        {
            string qurey = "SELECT *FROM Department WHERE NAME = @name";
            Command = new SqlCommand(qurey, Connection);
            Command.Parameters.AddWithValue("@name", name);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }
        public Department GetDepartmentById(int departmentId)
        {
            string query = "SELECT * FROM Department WHERE Id = " + departmentId;
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Department department = null;
            if (Reader.HasRows)
            {
                department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Code = Reader["Code"].ToString();
                department.Name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return department;
        }
        public List<Department> GetAllDepartment()
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

        public string GetDepartmentNameById(int id)
        {
            string query = "SELECT * FROM Department WHERE Id =@id ";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            string name = null;
            if (Reader.HasRows)
            {

                name = Reader["Name"].ToString();


            }
            Reader.Close();
            Connection.Close();
            return name;
        }
       
    }
}