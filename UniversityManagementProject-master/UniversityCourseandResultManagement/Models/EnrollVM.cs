using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Models
{
    public class EnrollVM
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
    }
}