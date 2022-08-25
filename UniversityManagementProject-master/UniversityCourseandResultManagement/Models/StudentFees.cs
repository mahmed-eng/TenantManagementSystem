using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UniversityCourseandResultManagement.Models
{
    public class StudentFees
    {
        public int Id { get; set; }
        public string StudentId { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Please Insert Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Fees Submission Date")]
        [Required(ErrorMessage = "Please Insert Fees Submission Date")]
        public string FeeSubmissionDate { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Insert Department No")]
        public string DeptId { get; set; }

        [Display(Name = "Student Register Number.")]
        [Required(ErrorMessage = "Please Insert Student Register Number")]
        public string StudentRegisterNumber { get; set; }

        [Display(Name = "Month")]
        [Required(ErrorMessage = "Please Insert Month")]
        public string Month { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Insert Student Address")]
        public string StudentAddress { get; set; }

        [Display(Name = "ParentC ontact")]
        [Required(ErrorMessage = "Please insert Parent Contact")]
        public int ParentContact { get; set; }

        [Display(Name = "Enter Amount")]
        [Required(ErrorMessage = "Please insert Amount")]
        public string FeeRecieved { get; set; }
    }
}