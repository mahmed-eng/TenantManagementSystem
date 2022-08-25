using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseandResultManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Insert Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Insert Student Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Student Email is Not Valid")]
        [Remote("IsEmailExist", "Student", ErrorMessage = "Student Email Already Exist")]
        public string StudentEmail { get; set; }

        [Display(Name = "Contact No.")]
        [Required(ErrorMessage = "Please Insert Student Contact No")]
        [RegularExpression(@"\+?(88)?0?1[56789][0-9]{8}\b", ErrorMessage = "Student Contact No is Not Valid")]
        public string StudentContact { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please Select Registration Date")]
        public string RegDate { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Insert Student Address")]
        public string StudentAddress { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Teacher Department")]
        public int DeptId { get; set; }

        public string RegNo { get; set; }
    }
}