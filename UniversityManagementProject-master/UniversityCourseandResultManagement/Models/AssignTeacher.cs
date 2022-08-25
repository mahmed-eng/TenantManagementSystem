using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseandResultManagement.Models
{
    public class AssignTeacher
    {
        public int Id { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DeptId { get; set; }

        [Display(Name = "Teacher")]
        [Required(ErrorMessage = "Please Select Teacher")]
        public int TeacherId { get; set; }

        [Display(Name = "Credit to be Taken")]
        public decimal CreditTobeTaken { get; set; }

        [Display(Name = "Remaining Credit")]
        public decimal RemainingCredit { get; set; }

        [Display(Name = "Course Code")]
        [Required(ErrorMessage = "Please Select Course Code")]
        [Remote("IsCourseCodeExist", "Course", ErrorMessage = "Course Already Assigned")]
        public int CourseId { get; set; }

        [Display(Name = "Name")]
        public string CourseName { get; set; }

        [Display(Name = "Credit")]
        public decimal CourseCredit { get; set; }
    }
}