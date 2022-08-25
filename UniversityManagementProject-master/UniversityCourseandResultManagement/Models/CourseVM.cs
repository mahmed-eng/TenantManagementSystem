using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Models
{
    public class CourseVM
    {
        [Display(Name = "Department")]
        public int DeptId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string SemesterName { get; set; }
        public string TeacherName { get; set; }
        public string Status { get; set; }
    }
}