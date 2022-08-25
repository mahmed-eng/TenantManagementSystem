using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class DashboardManager
    {
        DashboardGateway aDashboardGateway = new DashboardGateway();

        public int GetTotalTeacher()
        {
            return aDashboardGateway.GetTotalTeacher();
        }

        public int GetTotalStudent()
        {
            return aDashboardGateway.GetTotalStudent();
        }

        public int GetTotalDepartment()
        {
            return aDashboardGateway.GetTotalDepartment();
        }

        public int GetTotalRoom()
        {
            return aDashboardGateway.GetTotalRoom();
        }

        public List<ChartVM> GetCount()
        {
            return aDashboardGateway.GetCount();
        }
    }
}