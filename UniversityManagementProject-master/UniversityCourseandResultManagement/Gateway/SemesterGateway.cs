using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class SemesterGateway:Gateway
    {
        public List<Semester> GetAllSemesters()
        {
            Query = "SELECT * FROM Semester_tb";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            while (Reader.Read())
            {
                Semester aSemester = new Semester()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    SemesterName = Convert.ToString(Reader["SemesterName"])
                };
                semesters.Add(aSemester);
            }
            Connection.Close();
            Reader.Close();
            return semesters;
        }
    }
}