using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement.BLL;

namespace UniversityCourseandResultManagement.Controllers
{
    public class DashboardController : Controller
    {
        DashboardManager aDashboardManager = new DashboardManager();

        public ActionResult Dashboard()
        {
            ViewBag.Teachers = aDashboardManager.GetTotalTeacher();
            ViewBag.Students = aDashboardManager.GetTotalStudent();
            ViewBag.Departments = aDashboardManager.GetTotalDepartment();
            ViewBag.Rooms = aDashboardManager.GetTotalRoom();
            ViewBag.Chart = aDashboardManager.GetCount();
            return View();
        }
	}
}