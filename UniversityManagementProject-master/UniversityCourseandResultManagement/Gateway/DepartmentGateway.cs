using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class DepartmentGateway:Gateway
    {
        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    DeptCode = Convert.ToString(Reader["DeptCode"]),
                    DeptName = Convert.ToString(Reader["DeptName"])
                };
                departments.Add(aDepartment);
            }
            Connection.Close();
            Reader.Close();
            return departments;
        }
        public int Save(Department aDepartment)
        {
            Query = "INSERT INTO Department_tb (DeptCode, DeptName)VALUES(@code, @name)";
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("code", aDepartment.DeptCode);
            Command.Parameters.AddWithValue("name", aDepartment.DeptName);
            
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        
    }
}