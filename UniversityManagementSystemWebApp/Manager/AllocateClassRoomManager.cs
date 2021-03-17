using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class AllocateClassRoomManager
    {
        private AllocateClassRoomGateway allocateClassroomsGateway;

        public AllocateClassRoomManager()
        {
            allocateClassroomsGateway=new AllocateClassRoomGateway();
        }


          public string Save(AllocateClassroom allocateClassroom)
        {
            int rowaffect = allocateClassroomsGateway.Save(allocateClassroom);
            if (rowaffect > 0)
            {
                return "Save successful";
            }
            else
            {
               return "Save Failed";

            }       
           }

          public string UnAllocateRooms()
          {
              int rowAffect = allocateClassroomsGateway.UnAllocateRooms();
              if (rowAffect > 0)
              {
                  return "UnAllocate Rooms Successful!";
              }
              else
              {
                  return "Unallocate Rooms Failed!";
              }
          }
}
}