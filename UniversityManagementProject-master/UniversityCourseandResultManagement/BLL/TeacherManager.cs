using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway = new TeacherGateway();

        public string Save(Teacher aTeacher)
        {
            if (aTeacherGateway.Save(aTeacher) > 0)
            {
                return "Teacher Save Successfully Done";
            }
            else
            {
                return "Failed";
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            return aTeacherGateway.GetAllTeachers();
        }
    }
}