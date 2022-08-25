using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class EnrollGateway:Gateway
    {
        public List<StudentVM> GetAllStudentVms() 
        {
            Query = "SELECT st.Id, st.RegisterNumber, st.StudentName, st.StudentEmail, dt.Id as deptid, dt.DeptName FROM Student_tb as st" +
                    " INNER JOIN Department_tb as dt on st.DeptId = dt.Id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentVM> studentVms = new List<StudentVM>();
            while (Reader.Read())
            {
                StudentVM aStudent = new StudentVM()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    RegNo = Convert.ToString(Reader["RegisterNumber"]),
                    StudentName = Convert.ToString(Reader["StudentName"]),
                    StudentEmail = Convert.ToString(Reader["StudentEmail"]),
                    StdDeptId = Convert.ToInt32(Reader["deptid"]),
                    StudentDepartment = Convert.ToString(Reader["DeptName"])
                };
                studentVms.Add(aStudent);
            }
            Connection.Close();
            Reader.Close();
            return studentVms;
        }

        
            public List<StudentVM> GetAllStudents()
        {
            Query = "SELECT st.Id, st.RegisterNumber, st.StudentName, st.StudentEmail, dt.Id as deptid, dt.DeptName FROM Student_tb as st" +
                    " INNER JOIN Department_tb as dt on st.DeptId = dt.Id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentVM> studentVms = new List<StudentVM>();
            while (Reader.Read())
            {
                StudentVM aStudent = new StudentVM()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    RegNo = Convert.ToString(Reader["RegisterNumber"]),
                    StudentName = Convert.ToString(Reader["StudentName"]),
                    StudentEmail = Convert.ToString(Reader["StudentEmail"]),
                    StdDeptId = Convert.ToInt32(Reader["deptid"]),
                    StudentDepartment = Convert.ToString(Reader["DeptName"])
                };
                studentVms.Add(aStudent);
            }
            Connection.Close();
            Reader.Close();
            return studentVms;
        }
        public int Save(Enroll aEnroll)
        {
            Query = "INSERT INTO Enroll_tb (StudentId, CourseId, EnrollDate) VALUES (@stdid, @crsid, @edate)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("stdid", aEnroll.StudentId);
            Command.Parameters.AddWithValue("crsid", aEnroll.CourseId);
            Command.Parameters.AddWithValue("edate", aEnroll.EnrollDate);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }


        public bool IsExist(Enroll aEnroll)
        {
            Query = "SELECT StudentId FROM Enroll_tb WHERE CourseId = @crsid AND StudentId = @stdid";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("crsid", aEnroll.CourseId);
            Command.Parameters.AddWithValue("stdid", aEnroll.StudentId);
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                return true;
            }
            Connection.Close();
            return false;
        }

        public List<EnrollVM> GetAllEnrollCourse()
        {
            Query = "SELECT st.Id as StudentId, ct.Id as CourseId, ct.CourseCode FROM Enroll_tb as et " +
                    "INNER JOIN Student_tb as st on et.StudentId = st.Id INNER JOIN Course_tb as ct on et.CourseId = ct.Id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<EnrollVM> enrollVms = new List<EnrollVM>();
            while (Reader.Read())
            {
                EnrollVM aEnroll = new EnrollVM()
                {
                    StudentId = Convert.ToInt32(Reader["StudentId"]),
                    CourseId = Convert.ToInt32(Reader["CourseId"]),
                    CourseCode = Convert.ToString(Reader["CourseCode"])
                };
                enrollVms.Add(aEnroll);
            }
            Connection.Close();
            Reader.Close();
            return enrollVms;
        }

    }
}