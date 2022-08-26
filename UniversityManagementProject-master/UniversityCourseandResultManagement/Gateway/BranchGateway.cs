using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class BranchGateway : Gateway
    {
        public int Save(Branch aBranch)
        {
            Query = "INSERT INTO Branch_tb (Name, CompanyId, Address, Email, Phone, Fax, Cell, RegisterNumber, CreatedBy, CreatedDate) " +
                    "VALUES(@name, @companyid, @address, @email, @phone, @fax, @cell, @registerNumber, @createdBy, @createdDate)";
            Command = new SqlCommand(Query, Connection);
            // Command.Parameters.AddWithValue("id", aBranch.BranchId);
            Command.Parameters.AddWithValue("name", aBranch.Name);
            Command.Parameters.AddWithValue("CompanyId", Convert.ToString(aBranch.CompanyId));
            Command.Parameters.AddWithValue("address",Convert.ToString (aBranch.Address));
            Command.Parameters.AddWithValue("email", Convert.ToString (aBranch.Email));
            Command.Parameters.AddWithValue("phone", Convert.ToString (aBranch.Phone));
            Command.Parameters.AddWithValue("fax", Convert.ToString (aBranch.Fax));
            Command.Parameters.AddWithValue("cell", Convert.ToString (aBranch.Cell));
            Command.Parameters.AddWithValue("registerNumber", Convert.ToString (aBranch.RegisterNumber));
            Command.Parameters.AddWithValue("createdBy", aBranch.CreatedBy);
            Command.Parameters.AddWithValue("createdDate", aBranch.CreatedDate);
            //Command.Parameters.AddWithValue("updatedBy", aBranch.UpdatedBy);
            //Command.Parameters.AddWithValue("updatedDate", aBranch.UpdatedDate);

           
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public List<Branch> GetAllBranch()
        {
            Query = "SELECT * FROM Branch_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Branch> Branch = new List<Branch>();
            while (Reader.Read())
            {
                Branch aBranch = new Branch()
                {
                    //BranchId = Convert.ToInt32(Reader["Id"]),
                    Name = Convert.ToString(Reader["Name"]),
                    //CompanyId = Convert.ToString(Reader["CompanyId"]),
                    Address = Convert.ToString(Reader["Address"]),
                    Email = Convert.ToString(Reader["Email"]),
                    Phone = Convert.ToString(Reader["Phone"]),
                    Fax = Convert.ToString(Reader["Fax"]),
                    Cell = Convert.ToString(Reader["Cell"]),
                    RegisterNumber = Convert.ToString(Reader["RegisterNumber"]),
                    //CreatedBy = Convert.ToInt32(Reader["CreatedBy"]),
                    //CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]),
                   //UpdatedBy = Convert.ToInt32(Reader["UpdatedBy"]),
                    //UpdatedDate = Convert.ToDateTime(Reader["UpdatedDate"])
                };
                Branch.Add(aBranch);
            }
            Connection.Close();
            Reader.Close();
            return Branch;
        }
    }
}