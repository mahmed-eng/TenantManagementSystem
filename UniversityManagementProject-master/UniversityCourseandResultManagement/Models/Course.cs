using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseandResultManagement.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Please Insert Course Code")]
        [StringLength(Int32.MaxValue, MinimumLength = 5, ErrorMessage = "Course Code Must be at Least 5 Characters Long")]
        [Remote("IsCodeExist", "Course", ErrorMessage = "Course Code Already Exist")]
        public string CourseCode { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Insert Course Name")]
        [Remote("IsNameExist", "Course", ErrorMessage = "Course Name Already Exist")]
        public string CourseName { get; set; }

        [Display(Name = "Credit")]
        [Required(ErrorMessage = "Please Insert Course Credit")]
        [Range(0.5, 5.00, ErrorMessage = "Credit Must be 0.5 to 5")]
        public decimal CourseCredit { get; set; }

        [Display(Name = "Description")]
        public string CourseDescription { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DeptId { get; set; }

        [Display(Name = "Semester")]
        [Required(ErrorMessage = "Please Select Semester")]
        public int SemesterId { get; set; }
    }
}