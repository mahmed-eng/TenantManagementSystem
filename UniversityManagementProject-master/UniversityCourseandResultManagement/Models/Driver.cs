using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityCourseandResultManagement.Models
{
    public class Driver
    {
        //public int Id { get; set; }

        //[Display(Name = "Driver Id")]
        //[Required(ErrorMessage = "Please Insert Driver Id")]
        //[StringLength(Int32.MaxValue, MinimumLength = 5, ErrorMessage = "Course Code Must be at Least 5 Characters Long")]
        //[Remote("IsCodeExist", "Course", ErrorMessage = "Driver Id Already Exist")]
        
        public int DriverId { get; set; }

        [Display(Name = "Driver Name")]
        [Required(ErrorMessage = "Please Insert Driver Name")]
        public string DriverName { get; set; }

        [Display(Name = "Adrdess")]
        [Required(ErrorMessage = "Please Insert Driver Address")]
        public string DriverAddress { get; set; }

        [Display(Name = "Vehicle Description")]
        public string DriverVehicle { get; set; }

        [Display(Name = "Route")]
        [Required(ErrorMessage = "Please Select Route")]
        public string DriverRoute { get; set; }

        [Display(Name = "Driver CNIC")]
        [Required(ErrorMessage = "Please insert Driver CNIC")]
        public string DriverCNIC { get; set; }

        [Display(Name = "Driver License")]
        [Required(ErrorMessage = "Please insert Driver License")]
        public string DriverLicense { get; set; }
    }
}