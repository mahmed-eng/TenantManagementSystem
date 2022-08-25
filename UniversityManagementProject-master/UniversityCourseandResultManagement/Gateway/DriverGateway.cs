using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class DriverGateway:Gateway
    {
        public int Save(Driver aDriver)
        {
            Query = "INSERT INTO Driver_tb ( Driver_Name,Driver_Address, Driver_Vehicle, Drver_Route,Driver_CNIC,Driver_License)" +
                   " VALUES ( @driveName, @driverAddress, @driverVehicle, @driverRoute, @driverCnic, @driverLicense)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("driveName", aDriver.DriverName);
            Command.Parameters.AddWithValue("driverAddress", aDriver.DriverAddress);
            Command.Parameters.AddWithValue("driverVehicle", aDriver.DriverVehicle);
            Command.Parameters.AddWithValue("driverRoute", aDriver.DriverRoute);
            Command.Parameters.AddWithValue("driverCnic", aDriver.DriverCNIC);
            Command.Parameters.AddWithValue("driverLicense", aDriver.DriverLicense);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public List<Driver> GetAllDriver()
        {
            Query = "SELECT * FROM Driver_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Driver> driver = new List<Driver>();
            while (Reader.Read())
            {
                Driver aDriver = new Driver()
                {
                    DriverId = Convert.ToInt32(Reader["DriverId"]),
                    DriverName = Convert.ToString(Reader["DriverName"]),
                    DriverAddress = Convert.ToString(Reader["DriverAddress"]),
                    DriverVehicle = Convert.ToString(Reader["DriverVehicle"]),
                    DriverRoute = Convert.ToString(Reader["DriverRoute"]),
                    DriverCNIC = Convert.ToString(Reader["DriverCNIC"]),
                    DriverLicense = Convert.ToString(Reader["DriverLicense"])
                };
                driver.Add(aDriver);
            }
            Connection.Close();
            Reader.Close();
            return driver;
        }

    }
}