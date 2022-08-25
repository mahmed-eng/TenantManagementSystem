using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class DesignationManager
    {
        DesignationGateway aDesignationGateway = new DesignationGateway();

        public List<Designation> GetAllDesignations()
        {
            return aDesignationGateway.GetAllDesignations();
        }
    }
}