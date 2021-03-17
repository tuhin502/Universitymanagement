using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class AllocateClassRoomGateway:CommonGateway
    {

        public int Save(AllocateClassroom allocateClassroom)
        {
            string query = "INSERT INTO AllocateRoom VALUES(@departmentId,@courseId,@roomId,@dayId,@fromTime,@toTime)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@departmentId", allocateClassroom.DepartmentId);
            Command.Parameters.AddWithValue("@courseId", allocateClassroom.CourseId);
            Command.Parameters.AddWithValue("@roomId", allocateClassroom.RoomId);
            Command.Parameters.AddWithValue("@dayId", allocateClassroom.DayId);
            Command.Parameters.AddWithValue("@fromTime", allocateClassroom.FromTime);
            Command.Parameters.AddWithValue("@toTime", allocateClassroom.ToTime);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }





        public int UnAllocateRooms()
        {
            string query = "UPDATE AllocateRoom SET Status = 'NO'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;

        }   
    }
}