using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class TeacherGateway:Gateway
    {
        public int Save(Teacher aTeacher)
        {
            Query = "INSERT INTO Teacher_tb (TeacherName, TeacherAddress, TracherEmail, TracherContact, DesignationId, DeptId, Credit)" +
                    " VALUES (@name, @address, @email, @contact, @desid, @deptid, @credit)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", aTeacher.TeacherName);
            Command.Parameters.AddWithValue("address", aTeacher.TeacherAddress);
            Command.Parameters.AddWithValue("email", aTeacher.TracherEmail);
            Command.Parameters.AddWithValue("contact", aTeacher.TracherContact);
            Command.Parameters.AddWithValue("desid", aTeacher.DesignationId);
            Command.Parameters.AddWithValue("deptid", aTeacher.DeptId);
            Command.Parameters.AddWithValue("credit", aTeacher.Credit);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public List<Teacher> GetAllTeachers()
        {
            Query = "SELECT * FROM Teacher_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    TeacherName = Convert.ToString(Reader["TeacherName"]),
                    TeacherAddress = Convert.ToString(Reader["TeacherAddress"]),
                    TracherEmail = Convert.ToString(Reader["TracherEmail"]),
                    TracherContact = Convert.ToString(Reader["TracherContact"]),
                    DeptId = Convert.ToInt32(Reader["DeptId"]),
                    DesignationId = Convert.ToInt32(Reader["DesignationId"]),
                    Credit = Convert.ToDecimal(Reader["Credit"])
                };
                teachers.Add(aTeacher);
            }
            Connection.Close();
            Reader.Close();
            return teachers;
        }
   }
}