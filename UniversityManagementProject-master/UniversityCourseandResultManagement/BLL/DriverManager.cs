using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class DriverManager
    {
        DriverGateway aDriverGateway = new DriverGateway();
             
        public string Save(Driver aDriver)
        {
            if (aDriverGateway.Save(aDriver) > 0)
            {
                return "Driver Save Successfully Done";
            }
            else
            {
                return "Failed";
            }
        }

        public List<Driver> GetAllDriver()
        {
            DriverGateway aDriverGateway = new DriverGateway();
            return aDriverGateway.GetAllDriver();
        }


    }
}