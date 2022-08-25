using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class StudentManager
    {
        StudentGateway aStudentGateway = new StudentGateway();

        public string GetDepartmentCode(int id)
        {
            return aStudentGateway.GetDepartmentCode(id);
        }

        public int GetNumberOfStudent(int id, string year)
        {
            return aStudentGateway.GetNumberOfStudent(id, year);
        }

        public string Save(Student aStudent)
        {
            if (aStudentGateway.Save(aStudent) > 0)
            {
                return "Student Register Successfully Done";
            }
            else
            {
                return "Failed";
            }
        }

        public List<Student> GetAllStudents()
        {
            return aStudentGateway.GetAllStudents();
        }
    }
}