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
    
    public partial class RoomAllocation_tb
    {
        public int Id { get; set; }
        public int DeptId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public string Day { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public bool Status { get; set; }
    }
}
