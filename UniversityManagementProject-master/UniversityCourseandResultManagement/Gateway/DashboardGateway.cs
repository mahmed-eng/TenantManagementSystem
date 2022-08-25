using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class DashboardGateway:Gateway
    {
        public int GetTotalTeacher()
        {
            Query = "SELECT COUNT(Id) FROM Teacher_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int value = (Int32)Command.ExecuteScalar();
            Connection.Close();
            return value;
        }

        public int GetTotalStudent()
        {
            Query = "SELECT COUNT(Id) FROM Student_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int value = (Int32)Command.ExecuteScalar();
            Connection.Close();
            return value;
        }

        public int GetTotalDepartment()
        {
            Query = "SELECT COUNT(Id) FROM Department_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int value = (Int32)Command.ExecuteScalar();
            Connection.Close();
            return value;
        }

        public int GetTotalRoom()
        {
            Query = "SELECT COUNT(Id) FROM Room_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int value = (Int32)Command.ExecuteScalar();
            Connection.Close();
            return value;
        }

        public List<ChartVM> GetCount()
        {
            Query = "SELECT DISTINCT Department_tb.DeptCode as Code, Department_tb.Id as Did, COUNT(Student_tb.Id) over " +
                    "(partition by Student_tb.DeptId) as Student FROM Department_tb INNER JOIN Student_tb on " +
                    "Department_tb.Id = Student_tb.DeptId ORDER BY Did ASC";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ChartVM> aChart = new List<ChartVM>();
            while (Reader.Read())
            {
                ChartVM aChartVm = new ChartVM()
                {
                    DeptCode = Convert.ToString(Reader["Code"]),
                    TotalStudent = Convert.ToInt32(Reader["Student"])
                };
                aChart.Add(aChartVm);
            }

            return aChart;
        }
    }
}