using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class DesignationGateway:Gateway
    {
        public List<Designation> GetAllDesignations()
        {
            Query = "SELECT * FROM Designation_tb";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            while (Reader.Read())
            {
                Designation aDesignation = new Designation()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    DesignationName = Convert.ToString(Reader["DesignationName"])
                };
                designations.Add(aDesignation);
            }
            Connection.Close();
            Reader.Close();
            return designations;
        }
    }
}