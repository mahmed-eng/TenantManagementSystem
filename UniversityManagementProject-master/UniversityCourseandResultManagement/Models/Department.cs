using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseandResultManagement.Models
{
    public class Department
    {
        public int Id { get; set; } 

        [DefaultValue(true)]
        [Display(Name = "Department Code")]
        [Required(ErrorMessage = "Please Insert Department Code")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Department Code Should be 2 to 7 Characters Long")]
        [Remote("IsCodeExist", "Department", ErrorMessage = "Department Code Already Exist")]
        public string DeptCode { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Please Insert Department Name")]
        [Remote("IsNameExist", "Department", ErrorMessage = "Department Name Already Exist")]
        public string DeptName { get; set; }
    }
}