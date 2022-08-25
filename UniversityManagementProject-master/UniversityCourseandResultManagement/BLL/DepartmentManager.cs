using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class DepartmentManager
    {
     
        public string Save(Department aDepartment)
        {
            DepartmentGateway aDepartmentGateway = new DepartmentGateway();
            if (aDepartmentGateway.Save(aDepartment) > 0)
            {
                return "Department Save Successfully Done";
            }
            else
            {
                return "Failed";
            }
        }
        public List<Department> GetAllDepartments()
        {
            DepartmentGateway aDepartmentGateway = new DepartmentGateway();

            return aDepartmentGateway.GetAllDepartments();
        }
    }
}