using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class CourseGateway:Gateway
    {
        public int Save(Course aCourse)
        {
            Query ="INSERT INTO Course_tb (CourseCode, CourseName, CourseCredit, Description, DeptId, SemesterId)" +
                   " VALUES (@code, @name, @credit, @description, @deptid, @semesterid)";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("code", aCourse.CourseCode);
            Command.Parameters.AddWithValue("name", aCourse.CourseName);
            Command.Parameters.AddWithValue("credit", aCourse.CourseCredit);
            if (aCourse.CourseDescription != null)
            {
                Command.Parameters.AddWithValue("description", aCourse.CourseDescription);
            }
            else
            {
                Command.Parameters.AddWithValue("description", DBNull.Value);
            }
            Command.Parameters.AddWithValue("deptid", aCourse.DeptId);
            Command.Parameters.AddWithValue("semesterid", aCourse.SemesterId);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public List<Course> GetAllCourses()
        {
            Query = "SELECT * FROM Course_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    CourseCode = Convert.ToString(Reader["CourseCode"]),
                    CourseName = Convert.ToString(Reader["CourseName"]),
                    CourseCredit = Convert.ToDecimal(Reader["CourseCredit"]),
                    CourseDescription = Convert.ToString(Reader["Description"]),
                    DeptId = Convert.ToInt32(Reader["DeptId"]),
                    SemesterId = Convert.ToInt32(Reader["SemesterId"])
                };
                courses.Add(aCourse);
            }
            Connection.Close();
            Reader.Close();
            return courses;
        }

        public List<AssignTeacher> GetAssignCourse()
        {
            Query = "SELECT * FROM AssignTeacher_tb WHERE Status = 'True'";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AssignTeacher> courses = new List<AssignTeacher>();
            while (Reader.Read())
            {
                AssignTeacher aCourse = new AssignTeacher()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    CourseId = Convert.ToInt32(Reader["CourseId"])
                };
                courses.Add(aCourse);
            }
            Connection.Close();
            Reader.Close();
            return courses;
        }


        public bool SaveUpdate(int deptid, int tsirid, int crsid)
        {
            Connection.Open();
            Query = "SELECT COUNT(*) FROM AssignTeacher_tb WHERE DeptId = '" + deptid + "' AND CourseId = '" + crsid + "' ";
            Command = new SqlCommand(Query, Connection);
            int count = (int)Command.ExecuteScalar();

            if (count > 0)
            {
                Query = "UPDATE AssignTeacher_tb SET TeacherId = '"+ tsirid +"', Status = 'True' WHERE DeptId = '" + deptid + "' AND CourseId = '" + crsid + "' ";
                Command = new SqlCommand(Query, Connection);
                int rowCount = Command.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            else
            {
                Query = "INSERT INTO AssignTeacher_tb (DeptId, TeacherId, CourseId, Status)" +
                        " VALUES (@deptid, @tsirid, @crsid, 'True')";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("deptid", deptid);
                Command.Parameters.AddWithValue("tsirid", tsirid);
                Command.Parameters.AddWithValue("crsid", crsid);
                int rowCount = Command.ExecuteNonQuery();
                Connection.Close();
                return false;
            }

        }

       
        public decimal GetCourseCredit(int Id)
        {
            Query = "SELECT at.TeacherId, isnull(sum(c.CourseCredit),0) as TotalCourseCredit FROM AssignTeacher_tb as at INNER JOIN" +
                    " Course_tb as c on at.CourseId = c.Id WHERE at.TeacherId = '" + Id + "' AND at.Status = 'True' GROUP BY at.TeacherId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Course course = new Course();
            if (Reader.Read())
            {
                course.CourseCredit = (decimal)(Reader["TotalCourseCredit"]);
            }
            else
            {
                course.CourseCredit = 0;
            }
            Connection.Close();
            Reader.Close();
            return course.CourseCredit;
        }

        public List<CourseVM> GetAllCourseView()
        {
            Query = "SELECT dt.Id, ct.CourseCode, ct.CourseName, st.SemesterName, tet.TeacherName, ast.Status FROM Department_tb as dt " +
                    "INNER JOIN Course_tb as ct on dt.Id = ct.DeptId INNER JOIN Semester_tb as st on ct.SemesterId = st.Id LEFT JOIN " +
                    "AssignTeacher_tb as ast on ct.Id = ast.CourseId LEFT JOIN Teacher_tb as tet on ast.TeacherId = tet.Id";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseVM> courseVms = new List<CourseVM>();
            while (Reader.Read())
            {
                CourseVM aCourseVm = new CourseVM()
                {
                    DeptId = Convert.ToInt32(Reader["Id"]),
                    CourseCode = Convert.ToString(Reader["CourseCode"]),
                    CourseName = Convert.ToString(Reader["CourseName"]),
                    SemesterName = Convert.ToString(Reader["SemesterName"]),
                    TeacherName = Convert.ToString(Reader["TeacherName"]),
                    Status = Convert.ToString(Reader["Status"])
                };
                courseVms.Add(aCourseVm);
            }
            Connection.Close();
            Reader.Close();
            return courseVms;
        }

    }
}