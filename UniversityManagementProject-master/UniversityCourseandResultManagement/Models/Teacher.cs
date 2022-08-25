using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseandResultManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Insert Teacher Name")]
        public string TeacherName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Insert Teacher Address")]
        public string TeacherAddress { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Insert Teacher Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Teacher Email is Not Valid")]
        [Remote("IsEmailExist", "Teacher", ErrorMessage = "Teacher Email Already Exist")]
        public string TracherEmail { get; set; }

        [Display(Name = "Contact No.")]
        [Required(ErrorMessage = "Please Insert Teacher Contact No")]
        [RegularExpression(@"\+?(88)?0?1[56789][0-9]{8}\b", ErrorMessage = "Teacher Contact No is Not Valid")]
        public string TracherContact { get; set; }

        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Please Select Teacher Designation")]
        public int DesignationId { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Teacher Department")]
        public int DeptId { get; set; }

        [Display(Name = "Credit to be taken")]
        [Required(ErrorMessage = "Please Insert Credit")]
        [Range(typeof(decimal), "0.1", "79228162514264337593543950335", ErrorMessage = "Credit Must be a Positive Value")]
        public decimal Credit { get; set; }
        public decimal RemainingCredit { get; set; }
    }
}