//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversityCourseandResultManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentAttendance_tb
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string AttendanceStatus { get; set; }
        public Nullable<int> Std_id { get; set; }
    
        public virtual Student_tb Student_tb { get; set; }
    }
}
