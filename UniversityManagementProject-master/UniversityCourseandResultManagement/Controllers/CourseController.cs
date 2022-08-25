using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UniversityCourseandResultManagement.BLL;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        SemesterManager aSemesterManager = new SemesterManager();
        CourseManager aCourseManager = new CourseManager();
        TeacherManager aTeacherManager = new TeacherManager();
        EnrollManager aEnrollManager = new EnrollManager();
        

        [HttpGet]
        public ActionResult SaveCourse()
        {
            Course getcourse = new Course();
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Semesters = aSemesterManager.GetAllSemesters();
            return View(getcourse);
        }

        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Semesters = aSemesterManager.GetAllSemesters();
            ViewBag.Message = aCourseManager.Save(aCourse);
            return View(aCourse);
        }

        [HttpGet]
        public JsonResult IsCodeExist(Course aCourse)
        {
            List<Course> courses = aCourseManager.GetAllCourses();
            bool isExist = courses.FirstOrDefault(c => c.CourseCode.ToLowerInvariant().Equals(aCourse.CourseCode.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult IsNameExist(Course aCourse)
        {
            List<Course> courses = aCourseManager.GetAllCourses();
            bool isExist = courses.FirstOrDefault(c => c.CourseName.ToLowerInvariant().Equals(aCourse.CourseName.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherByDeptId(Department department)
        {
            var teachers = aTeacherManager.GetAllTeachers();
            var teacherList = teachers.Where(t => t.DeptId == department.Id).ToList();
            return Json(teacherList);
        }

        public JsonResult GetCreditByTsirId(int Id)
        {
            var teachers = aTeacherManager.GetAllTeachers();
            Teacher teacher = teachers.FirstOrDefault(t => t.Id == Id);
            teacher.RemainingCredit = teacher.Credit - GetCourseCredit(Id);
            return Json(teacher);
        }

        public decimal GetCourseCredit(int Id)
        {
            return aCourseManager.GetCourseCredit(Id);
        }

        public JsonResult GetCourseByDeptId(Department department)
        {
            var courses = aCourseManager.GetAllCourses();
            var coursesList = courses.Where(c => c.DeptId == department.Id).ToList();
            return Json(coursesList);
        }

        public JsonResult GetCourseByCourseId(Course course)
        {
            var courses = aCourseManager.GetAllCourses();
            var coursesList = courses.FirstOrDefault(c => c.Id == course.Id);
            return Json(coursesList);
        }

        public JsonResult IsCourseCodeExist(AssignTeacher assignTeacher)
        {
            List<AssignTeacher> courses = aCourseManager.GetAssignCourse();
            bool isExist = courses.FirstOrDefault(c => c.CourseId.ToStringInvariant().Equals(assignTeacher.CourseId.ToStringInvariant())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AssigntoTeacher()
        {
            AssignTeacher aAssignTeacher = new AssignTeacher();
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View(aAssignTeacher);
        }

        [HttpPost]
        public ActionResult AssigntoTeacher(AssignTeacher assignTeacher)
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Message = aCourseManager.Assign(assignTeacher);
            return View();
        }

        public JsonResult GetCourseByDepartmentId(Department department)
        {
            var courses = aCourseManager.GetAllCourseView();
            var coursesList = courses.Where(c => c.DeptId == department.Id).ToList();
            return Json(coursesList);
        }

        public ActionResult ViewCourse()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        public JsonResult GetStudentById(StudentVM student)
        {
            var students = aEnrollManager.GetAllStudentVms();
            var studentList = students.FirstOrDefault(s => s.Id == student.Id);
            return Json(studentList);
        }


        [HttpGet]
        public ActionResult Enroll()
        {
            Enroll aEnroll = new Enroll();
            ViewBag.StudentsVM = aEnrollManager.GetAllStudentVms();
            return View(aEnroll);
        }

        [HttpPost]
        public ActionResult Enroll(Enroll aEnroll)
        {
            ViewBag.StudentsVM = aEnrollManager.GetAllStudentVms();
            ViewBag.Message = aEnrollManager.Save(aEnroll);
            return View();
        }
	}
}