using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class EnrollManager
    {
        EnrollGateway aEnrollGateway = new EnrollGateway();

        public List<StudentVM> GetAllStudentVms()
        {
            return aEnrollGateway.GetAllStudentVms();
        }
        //public List<Student> GetAllStudents()
        //{
        //    return aEnrollGateway.GetAllStudents();
        //}

        public string Save(Enroll aEnroll)
        {
            if (aEnrollGateway.IsExist(aEnroll))
            {
                return "This Course Already Enrolled";
            }
            
            if (aEnrollGateway.Save(aEnroll) > 0)
            {
                return "Enrollment Successfully Done";
            }
            else
            {
                return "Failed";
            }
        }

        public List<EnrollVM> GetAllEnrollCourse()
        {
            return aEnrollGateway.GetAllEnrollCourse();
        }
    }
}