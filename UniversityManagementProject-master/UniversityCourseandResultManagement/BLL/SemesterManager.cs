using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class SemesterManager
    {
        SemesterGateway aSemesterGateway = new SemesterGateway();

        public List<Semester> GetAllSemesters()
        {
            return aSemesterGateway.GetAllSemesters();
        }
    }
}