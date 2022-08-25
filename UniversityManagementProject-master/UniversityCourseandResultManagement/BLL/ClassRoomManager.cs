using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class ClassRoomManager
    {
        ClassRoomGateway aClassRoomGateway = new ClassRoomGateway();

        public List<Room> GetAllRooms()
        {
            return aClassRoomGateway.GetAllRooms();
        }

        public string Save(ClassRoomAllocate aClassRoomAllocate)
        {
            if (TimeIsExist(aClassRoomAllocate) >= 1)
            {
                return "This Schedule is Already Booked ";
            }
            
            if (aClassRoomGateway.Save(aClassRoomAllocate) > 0)
            {
                return "Class Room Allocation Successfully Done";
            }
            else
            {
                return "Failed";
            }
        }

        public int TimeIsExist(ClassRoomAllocate aClassRoomAllocate)
        {
            return aClassRoomGateway.TimeIsExist(aClassRoomAllocate);
        }

        public List<ClassRoomAllocateVM> GetAllClassRoomAllocateVms()
        {
            return aClassRoomGateway.GetAllClassRoomAllocateVms();
        }
    }
}