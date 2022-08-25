using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();

        public string Save(Course aCourse)
        {
            if (aCourseGateway.Save(aCourse) > 0)
            {
                return "Course Save Successfully Done";
            }
            else
            {
                return "Failed";
            }
        }

        public List<Course> GetAllCourses()
        {
            return aCourseGateway.GetAllCourses();
        }

        public string Assign(AssignTeacher assignTeacher)
        {
            if (SaveUpdate(assignTeacher.DeptId, assignTeacher.TeacherId, assignTeacher.CourseId))
            {
                return "Course Assign Successfully Done";
            }
            else
            {
                return "Course Assign Successfully Done";
            }
        }

        private bool SaveUpdate(int deptid, int tsirid, int crsid)
        {
            return aCourseGateway.SaveUpdate(deptid, tsirid, crsid);
        }

        public decimal GetCourseCredit(int Id)
        {
            int courseCredit = Convert.ToInt32(aCourseGateway.GetCourseCredit(Id));
            return courseCredit;
        }

        public List<AssignTeacher> GetAssignCourse()
        {
            return aCourseGateway.GetAssignCourse();
        }

        public List<CourseVM> GetAllCourseView()
        {
            return aCourseGateway.GetAllCourseView();
        }

    }
}