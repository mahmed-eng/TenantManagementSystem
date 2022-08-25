using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement.BLL;

namespace UniversityCourseandResultManagement.Controllers
{
    public class ResetController : Controller
    {
        ResetManager aResetManager = new ResetManager();

        [HttpGet]
        public ActionResult Unassign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unassign(int id)
        {
            aResetManager.UnassignTeacher();
            return View();
        }

        [HttpGet]
        public ActionResult Unallocate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unallocate(int id)
        {
            aResetManager.Unallocate();
            return View();
        }
	}
}