using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement.BLL;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Controllers
{
    public class ClassRoomController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();
        ClassRoomManager aClassRoomManager = new ClassRoomManager();

        public JsonResult GetCourseByDeptId(Department department)
        {
            var courses = aCourseManager.GetAllCourses();
            var coursesList = courses.Where(c => c.DeptId == department.Id).ToList();
            return Json(coursesList);
        }

        public List<Week> Weeks()
        {
            List<Week> weeks = new List<Week>()
            {
                new Week {Name = "Saturday"},
                new Week {Name = "Sunday"},
                new Week {Name = "Monday"},
                new Week {Name = "Tuesday"},
                new Week {Name = "Wednesday"},
                new Week {Name = "Thrusday"},
                new Week {Name = "Friday"}
            };
            return weeks;
        }

        [HttpGet]
        public ActionResult RoomAllocation()
        {
            ClassRoomAllocate aClassRoomAllocate = new ClassRoomAllocate();
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Days = Weeks();
            ViewBag.Rooms = aClassRoomManager.GetAllRooms();
            return View(aClassRoomAllocate);
        }

        [HttpPost]
        public ActionResult RoomAllocation(ClassRoomAllocate aClassRoomAllocate)
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Days = Weeks();
            ViewBag.Rooms = aClassRoomManager.GetAllRooms();
            ViewBag.Message = aClassRoomManager.Save(aClassRoomAllocate);
            return View(aClassRoomAllocate);
        }

        [HttpPost]
        public ActionResult RoomDeAllocation(ClassRoomAllocate aClassRoomAllocate)
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Days = Weeks();
            ViewBag.Rooms = aClassRoomManager.GetAllRooms();
            ViewBag.Message = aClassRoomManager.Save(aClassRoomAllocate);
            return View(aClassRoomAllocate);
        }

        public JsonResult GetRoomScheduleByDepartmentId(Department department)
        {
            var rooms = aClassRoomManager.GetAllClassRoomAllocateVms();
            var roomsList = rooms.Where(r => r.DeptId == department.Id).ToList();
            return Json(roomsList);
        }

        public ActionResult RoomSchedule()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }
	}
}