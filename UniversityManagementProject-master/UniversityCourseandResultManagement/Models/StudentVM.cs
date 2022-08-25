using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseandResultManagement.Models
{
    public class StudentVM
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public int StdDeptId { get; set; }
        public string StudentDepartment { get; set; }
    }
}