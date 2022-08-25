using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement.BLL;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        DesignationManager aDesignationManager = new DesignationManager();
        TeacherManager aTeacherManager = new TeacherManager();

        [HttpGet]
        public ActionResult SaveTeacher()
        {
            Teacher aTeacher = new Teacher();
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View(aTeacher);
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Designations = aDesignationManager.GetAllDesignations();
            ViewBag.Message = aTeacherManager.Save(aTeacher);
            return View();
        }

        [HttpGet]
        public JsonResult IsEmailExist(Teacher aTeacher)
        {
            List<Teacher> teachers = aTeacherManager.GetAllTeachers();
            bool isExist = teachers.FirstOrDefault(t => t.TracherEmail.ToLowerInvariant().Equals(aTeacher.TracherEmail.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetTeacherById(Teacher teacher)
        //{
        //    var teachers = aTeacherManager.GetAllTeachers();
        //    var teacherlist = teachers.Where(t => t.Id == teacher.Id).ToList();
        //    return Json(teacherlist);
        //}

        [HttpGet]
        public ActionResult ViewTeacher()
        {
            List<Teacher> teachers = aTeacherManager.GetAllTeachers();
            ViewBag.Teachers = aTeacherManager.GetAllTeachers();
            return View(teachers);
        }

    }
}