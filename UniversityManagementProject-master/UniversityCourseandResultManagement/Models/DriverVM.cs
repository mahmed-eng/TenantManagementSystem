using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Models
{
    public class DriverVM
    {
        [Display(Name = "Driver")]
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverAddress { get; set; }
        public string DriverVehicle { get; set; }
        public string DriverRoute { get; set; }
        public string DriverCNIC { get; set; }
        public string DriverLicense { get; set; }
    }
}