using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Models
{
    public class ResultVM
    {
        public int Id { get; set; }

        [Display(Name = "Student Reg. No.")]
        public int StudentId { get; set; }

        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Display(Name = "Email")]
        public string StudentEmail { get; set; }

        [Display(Name = "Department")]
        public string StudentDept { get; set; }

        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Display(Name = "Name")]
        public string CourseName { get; set; }

        [Display(Name = "Grade")]
        public string Grade { get; set; }
    }
}