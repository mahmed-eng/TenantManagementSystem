using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement.BLL;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();

        [HttpGet]
        public ActionResult SaveDepartment()
        {
            Department d = new Department();
            return View(d);
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department aDepartment)
        {
            ViewBag.Message = aDepartmentManager.Save(aDepartment);
            return View(aDepartment);
        }
        [HttpGet]
        public JsonResult IsCodeExist(Department aDepartment)
        {
            List<Department> departments = aDepartmentManager.GetAllDepartments();
            bool isExist = departments.FirstOrDefault(d => d.DeptCode.ToLowerInvariant().Equals(aDepartment.DeptCode.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult IsNameExist(Department aDepartment)
        {
            List<Department> departments = aDepartmentManager.GetAllDepartments();
            bool isExist = departments.FirstOrDefault(d => d.DeptName.ToLowerInvariant().Equals(aDepartment.DeptName.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewDepartment()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }
	}
}