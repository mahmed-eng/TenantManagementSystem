using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement.BLL;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Controllers
{
    public class StudentController : Controller
    {
        StudentManager aStudentManager = new StudentManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        EnrollManager aEnrollManager = new EnrollManager();
        ResultManager aResultManager = new ResultManager();

        [HttpGet]
        public ActionResult RegisterStudent()
        {
            Student std = new Student(); 
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View(std);
        }

        [HttpPost]
        public ActionResult ShowRegisteredStudent(Student aStudent)
        {
            string deptCode = aStudentManager.GetDepartmentCode(aStudent.DeptId);
            string year = aStudent.RegDate.Substring(0, 4);
            string count = aStudentManager.GetNumberOfStudent(aStudent.DeptId, year).ToString("000");
            aStudent.RegNo = deptCode + "-" + year + "-" + count;
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Student = aStudent;
            ViewBag.Message = aStudentManager.Save(aStudent);
            return View();
        }

        [HttpGet]
        public JsonResult IsEmailExist(Student aStudent)
        {
            List<Student> students = aStudentManager.GetAllStudents();
            bool isExist = students.FirstOrDefault(s => s.StudentEmail.ToLowerInvariant().Equals(aStudent.StudentEmail.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEnrollCourseByStudentId(Result result)
        {
            var courses = aEnrollManager.GetAllEnrollCourse();
            var courseList = courses.FindAll(r => r.StudentId == result.Id);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SaveResult()
        {
            Result res = new Result();
            ViewBag.Students = aEnrollManager.GetAllStudentVms();
            ViewBag.Grades = aResultManager.GetAllGradeLetters();
            return View(res);
        }

        [HttpPost]
        public ActionResult SaveResult(Result aResult)
        {
            ViewBag.Students = aEnrollManager.GetAllStudentVms();
            ViewBag.Grades = aResultManager.GetAllGradeLetters();
            ViewBag.Message = aResultManager.Save(aResult);
            return View(aResult);
        }

        public JsonResult GetResultByStudentId(ResultVM aResultVm)
        {
            var result = aResultManager.GetAllResult();
            var resultList = result.Where(r => r.StudentId == aResultVm.Id).ToList();
            return Json(resultList);
        }

        public ActionResult ViewResult()
        {
            ResultVM aResult = new ResultVM();
            ViewBag.Students = aEnrollManager.GetAllStudentVms();
            return View(aResult);
        }

        //public ActionResult GenrateCard()
        //{
        //    Student std = new Student();
        //    ViewBag.Students = aEnrollManager.GetAllStudents();
        //    return View(std);
        //}
    }
}