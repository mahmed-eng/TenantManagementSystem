using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class ClassRoomGateway:Gateway
    {
        public List<Room> GetAllRooms()
        {
            Query = "SELECT * FROM Room_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
           List<Room> rooms = new List<Room>();
            while (Reader.Read())
            {
                Room aRoom = new Room()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    RoomNumber = Convert.ToString(Reader["RoomNumber"])
                };
                rooms.Add(aRoom);
            }
            Connection.Close();
            Reader.Close();
            return rooms;
        }

        public int Save(ClassRoomAllocate aClassRoomAllocate)
        {
            Query = "INSERT INTO RoomAllocation_tb (DeptId, CourseId, RoomId, Day, StartTime, EndTime, Status) " +
                    "VALUES (@deptid, @courseid, @roomid, @day, @start, @end, 'True')";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("deptid", aClassRoomAllocate.DeptId);
            Command.Parameters.AddWithValue("courseid", aClassRoomAllocate.CourseId);
            Command.Parameters.AddWithValue("roomid", aClassRoomAllocate.RoomId);
            Command.Parameters.AddWithValue("day", aClassRoomAllocate.Day);
            Command.Parameters.AddWithValue("start", aClassRoomAllocate.FromTime);
            Command.Parameters.AddWithValue("end", aClassRoomAllocate.ToTime);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public int TimeIsExist(ClassRoomAllocate aClassRoomAllocate)
        {
            Query = "SELECT COUNT(Id) FROM RoomAllocation_tb WHERE Day ='" + aClassRoomAllocate.Day + "' AND RoomId = '" + aClassRoomAllocate.RoomId + "' AND Status ='True' AND (('" + aClassRoomAllocate.FromTime + "' >= StartTime AND '" + aClassRoomAllocate.ToTime + "' <= EndTime) OR ('" + aClassRoomAllocate.ToTime + "' >= StartTime AND '" + aClassRoomAllocate.ToTime + "' <= EndTime))";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            object value = Command.ExecuteScalar();
            int a = 0;
            if (value != null)
            {
                a += (int)value;

            }
            Connection.Close();
            return a;
        }

        public List<ClassRoomAllocateVM> GetAllClassRoomAllocateVms()
        {
            Query = "SELECT ct.DeptId, rat.Status, rat.Day, rat.StartTime, rat.EndTime,ct.CourseCode, ct.CourseName, rt.RoomNumber FROM Course_tb as ct LEFT JOIN RoomAllocation_tb as rat on ct.Id = rat.CourseId LEFT JOIN Room_tb as rt on rat.RoomId = rt.Id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ClassRoomAllocateVM> classRoomAllocateVms = new List<ClassRoomAllocateVM>();
            while (Reader.Read())
            {
                int flag = 0;
                ClassRoomAllocateVM aClassRoomAllocateVm = new ClassRoomAllocateVM();

                aClassRoomAllocateVm.DeptId = Convert.ToInt32(Reader["DeptId"]);
                aClassRoomAllocateVm.Status = Convert.ToString(Reader["Status"]);
                aClassRoomAllocateVm.Day = Convert.ToString(Reader["Day"]);
                aClassRoomAllocateVm.FromTime = Convert.ToString(Reader["StartTime"]);
                aClassRoomAllocateVm.ToTime = Convert.ToString(Reader["EndTime"]);

                if (aClassRoomAllocateVm.FromTime != "")
                {
                    aClassRoomAllocateVm.FromTime = Get24FormatTime(aClassRoomAllocateVm.FromTime);
                    aClassRoomAllocateVm.ToTime = Get24FormatTime(aClassRoomAllocateVm.ToTime);
                }

                aClassRoomAllocateVm.RoomNo = Convert.ToString(Reader["RoomNumber"]);
                aClassRoomAllocateVm.CourseCode = Convert.ToString(Reader["CourseCode"]);
                aClassRoomAllocateVm.CourseName = Convert.ToString(Reader["CourseName"]);

                if (aClassRoomAllocateVm.RoomNo != "")
                {
                    aClassRoomAllocateVm.FullSchedule = "R. NO: " + aClassRoomAllocateVm.RoomNo + ", " +
                                                        aClassRoomAllocateVm.Day.Substring(0, 3) + ", " +
                                                        aClassRoomAllocateVm.FromTime + " - " +
                                                        aClassRoomAllocateVm.ToTime;
                }

                foreach (var data in classRoomAllocateVms)
                {
                    if (data.CourseCode == aClassRoomAllocateVm.CourseCode)
                    {
                        data.FullSchedule += "</br>" + aClassRoomAllocateVm.FullSchedule;
                        flag = 1;
                    }
                }

                if (flag == 0)
                {
                    classRoomAllocateVms.Add(aClassRoomAllocateVm);

                }
            }
            Connection.Close();
            Reader.Close();
            return classRoomAllocateVms;
        }

        public string Get24FormatTime(string time12Format)
        {
            string str = time12Format;
            string flag = " AM";
            int hour = Convert.ToInt32(str.Substring(0, 2));
            if (hour >= 12)
            {
                flag = " PM";
                hour = hour - 12;
            }
            else if (hour == 0)
            {
                hour = hour + 12;
            }

            string shour = hour.ToString("00");
            string minute = str.Substring(2, 3);
            string time = shour + minute + flag;
            return time;
        }

    }
}