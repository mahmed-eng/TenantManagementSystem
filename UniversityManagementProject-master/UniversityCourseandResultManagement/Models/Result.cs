using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Models
{
    public class Result
    {
        public int Id { get; set; }

        [Display(Name = "Student Reg. No.")]
        [Required(ErrorMessage = "Please Select Student")]
        public int StudentId { get; set; }

        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Display(Name = "Email")]
        public string StudentEmail { get; set; }

        [Display(Name = "Department")]
        public string StudentDept { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }

        [Display(Name = "Grade Letter")]
        [Required(ErrorMessage = "Please Select Grade")]
        public int GradeId { get; set; }
    }
}