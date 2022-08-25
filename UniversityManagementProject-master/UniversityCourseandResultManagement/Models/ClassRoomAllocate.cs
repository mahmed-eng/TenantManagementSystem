using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Models
{
    public class ClassRoomAllocate
    {
        public int Id { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select Department")]
        public int DeptId { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Please Select Course")]
        public int CourseId { get; set; }

        [Display(Name = "Room No.")]
        [Required(ErrorMessage = "Please Select Room Number")]
        public int RoomId { get; set; }

        [Display(Name = "Day")]
        [Required(ErrorMessage = "Please Select Day")]
        public string Day { get; set; }

        [Display(Name = "From")]
        [Required(ErrorMessage = "Please Select Start Time")]
        public string FromTime { get; set; }

        [Display(Name = "To")]
        [Required(ErrorMessage = "Please Select End Time")]
        public string ToTime { get; set; }
    }
}