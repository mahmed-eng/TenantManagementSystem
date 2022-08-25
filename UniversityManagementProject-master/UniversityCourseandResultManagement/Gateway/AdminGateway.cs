using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class AdminGateway:Gateway
    {
        public int Save(Admin admin)
        {
            Query = "INSERT INTO Admin_tb (Name, UserName, Password) VALUES (@n, @un, @pw)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("n", admin.Name);
            Command.Parameters.AddWithValue("un", admin.UserName);
            Command.Parameters.AddWithValue("pw", admin.Password);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }
        public int SaveChangePassword(AdminChangePassowrd admin)
        {
            Query = "INSERT INTO Admin_tb (Name,UserName, Password) VALUES (@n,@un, @pw)";
           
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("n", admin.UserName);
            Command.Parameters.AddWithValue("un", admin.UserName);
            Command.Parameters.AddWithValue("pw", admin.Password);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public List<Admin> GetAdmin()
        {
            Query = "SELECT * FROM Admin_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Admin> admins = new List<Admin>();
            while (Reader.Read())
            {
                Admin aAdmin = new Admin();

                aAdmin.Id = Convert.ToInt32(Reader["Id"]);
                aAdmin.Name = Convert.ToString(Reader["Name"]);
                aAdmin.UserName = Convert.ToString(Reader["UserName"]);
                aAdmin.Password = Convert.ToString(Reader["Password"]);
                admins.Add(aAdmin);
            }
            Connection.Close();
            Reader.Close();
            return admins;
        }
    }
}