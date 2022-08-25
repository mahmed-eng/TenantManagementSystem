using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class StudentGateway:Gateway
    {
        public string GetDepartmentCode(int id)
        {
            Query = "SELECT * FROM Department_tb WHERE Id = '"+ id +"' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            string deptCode = null;
            while (Reader.Read())
            {
                deptCode = Convert.ToString(Reader["DeptCode"]);
            }
            Connection.Close();
            Reader.Close();
            return deptCode;
        }

        public int GetNumberOfStudent(int id, string year)
        {
            Query = "SELECT COUNT(Id) FROM Student_tb WHERE DeptId = '" + id + "' AND RegDate BETWEEN '" + year + "-01-01' AND '" + year + "-12-31' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            object value = Command.ExecuteScalar();
            int a = 1;
            if (value != null)
            {
                a += (int)value;

            }
            Connection.Close();
            return a;
        }

        public int Save(Student aStudent)
        {
            Query = "INSERT INTO Student_tb (StudentName, StudentEmail, StudentContact, RegDate, StudentAddress, DeptId, RegisterNumber) " +
                    "VALUES(@name, @email, @contact, @date, @address, @dept, @reg)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", aStudent.StudentName);
            Command.Parameters.AddWithValue("email", aStudent.StudentEmail);
            Command.Parameters.AddWithValue("contact", aStudent.StudentContact);
            Command.Parameters.AddWithValue("date", aStudent.RegDate);
            Command.Parameters.AddWithValue("address", aStudent.StudentAddress);
            Command.Parameters.AddWithValue("dept", aStudent.DeptId);
            Command.Parameters.AddWithValue("reg", aStudent.RegNo);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public List<Student> GetAllStudents()
        {
            Query = "SELECT * FROM Student_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student aStudent = new Student()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    StudentEmail = Convert.ToString(Reader["StudentEmail"])
                };
                students.Add(aStudent);
            }
            Connection.Close();
            Reader.Close();
            return students;
        }
    }
}