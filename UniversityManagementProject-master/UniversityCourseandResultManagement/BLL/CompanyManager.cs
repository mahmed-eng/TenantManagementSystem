using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class CompanyManager
    {
        CompanyGateway aCompanyGateway = new CompanyGateway();

        public string Save(Company aCompany)
        {
            if (aCompanyGateway.Save(aCompany) > 0)
            {
                return "Company Save Successfully!!";
            }
            else
            {
                return "Failed";
            }
        }

        public List<Company> GetAllCompany()
        {
            CompanyGateway aCompanyGateway = new CompanyGateway();
            return aCompanyGateway.GetAllCompany();
        }
    }
}