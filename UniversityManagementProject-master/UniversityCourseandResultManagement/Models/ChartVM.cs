using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Models
{
    public class ChartVM
    {
        public int Id { get; set; }
        public int TotalStudent { get; set; }
        public string DeptCode { get; set; }
    }
}