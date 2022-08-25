using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Models
{
    public class ClassRoomAllocateVM
    {
        public int Id { get; set; }

        [Display(Name = "Department")]
        public int DeptId{ get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string RoomNo { get; set; }
        public string Day { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Status { get; set; }
        public string FullSchedule { get; set; }
    }
}