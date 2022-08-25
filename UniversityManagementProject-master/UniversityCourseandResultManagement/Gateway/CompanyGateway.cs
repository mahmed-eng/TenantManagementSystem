using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class CompanyGateway : Gateway
    {
        public int Save(Company aCompany)
        {
            Query = "INSERT INTO Company (Name, Address, Email, Phone, Fax, Cell, RegisterNumber, CreatedBy, CreatedDate, UpdatedBy,UpdatedDate) " +
                    "VALUES(@name, @address, @email, @phone, @fax, @cell, @registerNumber, @createdBy, @createdDate, @updatedBy, @updatedDate)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
           // Command.Parameters.AddWithValue("id", aCompany.CompanyId);
            Command.Parameters.AddWithValue("name", aCompany.Name);
            Command.Parameters.AddWithValue("address", aCompany.Address);
            Command.Parameters.AddWithValue("email", aCompany.Email);
            Command.Parameters.AddWithValue("phone", aCompany.Phone);
            Command.Parameters.AddWithValue("fax", aCompany.Fax);
            Command.Parameters.AddWithValue("cell", aCompany.Cell);
            Command.Parameters.AddWithValue("registerNumber", aCompany.RegisterNumber);
            Command.Parameters.AddWithValue("createdBy", aCompany.CreatedBy);
            Command.Parameters.AddWithValue("createdDate", aCompany.CreatedDate);
            Command.Parameters.AddWithValue("updatedBy", aCompany.UpdatedBy);
            Command.Parameters.AddWithValue("updatedDate", aCompany.UpdatedDate);

           
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public List<Company> GetAllCompany()
        {
            Query = "SELECT * FROM Company";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Company> Company = new List<Company>();
            while (Reader.Read())
            {
                Company aCompany = new Company()
                {
                  //  CompanyId = Convert.ToInt32(Reader["Id"]),
                    Name = Convert.ToString(Reader["Name"]),
                    Address = Convert.ToString(Reader["Address"]),
                    Email = Convert.ToString(Reader["Email"]),
                    Phone = Convert.ToString(Reader["Phone"]),
                    Fax = Convert.ToString(Reader["Fax"]),
                    Cell = Convert.ToString(Reader["Cell"]),
                    RegisterNumber = Convert.ToString(Reader["RegisterNumber"]),
                    CreatedBy = Convert.ToInt32(Reader["CreatedBy"]),
                    CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]),
                    UpdatedBy = Convert.ToInt32(Reader["UpdatedBy"]),
                    UpdatedDate = Convert.ToDateTime(Reader["UpdatedDate"])
                };
                Company.Add(aCompany);
            }
            Connection.Close();
            Reader.Close();
            return Company;
        }
    }
}