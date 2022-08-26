using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class AgentGateway : Gateway
    {
        public int Save(Agent aAgent)
        {
            Query = "INSERT INTO Agent_tb (Name, companyid, branchid, Address, Email, Phone, Fax, Cell, createdBy, createdDate) " +
                    "VALUES(@name, @companyid, @branchid, @address, @email, @phone, @fax, @cell, @createdBy, @createdDate)";
            Command = new SqlCommand(Query, Connection);
            //Command.Parameters.AddWithValue("id", aAgent.Id);
            Command.Parameters.AddWithValue("name", aAgent.Name);
            Command.Parameters.AddWithValue("companyid", Convert.ToString(aAgent.CompanyId));
            Command.Parameters.AddWithValue("branchid", Convert.ToString(aAgent.BranchId));
            Command.Parameters.AddWithValue("address", Convert.ToString(aAgent.Address));
            Command.Parameters.AddWithValue("email", Convert.ToString(aAgent.Email));
            Command.Parameters.AddWithValue("phone", Convert.ToString(aAgent.Phone));
            Command.Parameters.AddWithValue("fax", Convert.ToString(aAgent.Fax));
            Command.Parameters.AddWithValue("cell", Convert.ToString(aAgent.Cell));
            Command.Parameters.AddWithValue("createdBy", aAgent.CreatedBy);
            Command.Parameters.AddWithValue("createdDate", aAgent.CreatedDate);
            //Command.Parameters.AddWithValue("updatedBy", aAgent.UpdatedBy);
            //Command.Parameters.AddWithValue("updatedDate", aAgent.UpdatedDate);


            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public List<Agent> GetAllAgent()
        {
            List<Agent> Agent = new List<Agent>();
            try
            {
                Query = "SELECT * FROM Agent_tb";
                Command = new SqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();
              
                while (Reader.Read())
                {
                    Agent aAgent = new Agent()
                    {
                        Id = Convert.ToInt32(Reader["Id"]),
                        Name = Convert.ToString(Reader["Name"]),
                        CompanyId = Convert.ToInt32(Reader["CompanyId"]),
                        BranchId = Convert.ToInt32(Reader["BranchId"]),
                        Address = Convert.ToString(Reader["Address"]),
                        Email = Convert.ToString(Reader["Email"]),
                        Phone = Convert.ToString(Reader["Phone"]),
                        Fax = Convert.ToString(Reader["Fax"]),
                        Cell = Convert.ToString(Reader["Cell"]),
                        CreatedBy = Convert.ToInt32(Reader["CreatedBy"]),
                        CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]),
                        UpdatedBy = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedBy"])) ? 0 : Convert.ToInt32(Reader["UpdatedBy"]),
                        UpdatedDate = string.IsNullOrEmpty(Convert.ToString(Reader["UpdatedDate"])) ? DateTime.Now : Convert.ToDateTime(Reader["UpdatedDate"])
                    };
                    Agent.Add(aAgent);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Connection.Close();
            Reader.Close();
            return Agent;
        }
    }
}