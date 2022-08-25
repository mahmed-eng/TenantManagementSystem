using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eramake;
using UniversityCourseandResultManagement.BLL;
using UniversityCourseandResultManagement.Models;
using System.Data;
using System.Web.Security;
using System.Web.Mail;
using System.Net.Mail;
using WebMatrix.WebData;

namespace UniversityCourseandResultManagement.Controllers
{
    [AllowAnonymous]
    public class Admin_tbController : Controller
    {
        AdminManager adminManager = new AdminManager();
        DashboardManager aDashboardManager = new DashboardManager();

        [HttpGet]
        public JsonResult IsUserNameExist(Admin aAdmin)
        {
            List<Admin> admins = adminManager.GetAdmin();
            bool isExist = admins.FirstOrDefault(a => a.UserName.ToLowerInvariant().Equals(aAdmin.UserName.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AdminRegister()
        {
            Admin adminn = new Admin();
            return View(adminn);
        }

        [HttpGet]
        public ActionResult AdminChangePassowrd()
        {
            AdminChangePassowrd adminn = new AdminChangePassowrd();
            return View(adminn);
        }
        [HttpPost]
        //public ActionResult Login(Admin admin)
        //{
        //    admin.Password = eCryptography.Encrypt(admin.Password);
        //    ViewBag.Message = adminManager.Save(admin);
        //    return View();
        //}

        public ActionResult Login(Admin admin)
        {
            using (var data = new SMSEntities())
            {
                bool iscontain = data.Admin_tb.Any(x => x.UserName == admin.Name && x.Password == admin.Password);
                if (iscontain)
                {
                    FormsAuthentication.SetAuthCookie(admin.Name, false);
                    return RedirectToAction("Login", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "invalid user or password");
                    return View();
                }

            }
        }



        [HttpPost]
        public ActionResult Login1(AdminChangePassowrd changepasswordd)
        {
            changepasswordd.Password = eCryptography.Encrypt(changepasswordd.Password);
            ViewBag.Message = adminManager.SaveChangePassword(changepasswordd);
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth(Admin aAdmin)
        {
            var data = adminManager.GetAdmin();
            var adminDetails = data.Where(a => a.UserName == aAdmin.UserName && eCryptography.Decrypt(a.Password) == aAdmin.Password).FirstOrDefault();
            if (adminDetails == null)
            {
                ViewBag.EMessage = "Wrong User Name or Password";
                return View("../Admin/Login");
            }
            else
            {
                Session["Id"] = adminDetails.Id;
                Session["Name"] = adminDetails.Name;

                ViewBag.Teachers = aDashboardManager.GetTotalTeacher();
                ViewBag.Students = aDashboardManager.GetTotalStudent();
                ViewBag.Departments = aDashboardManager.GetTotalDepartment();
                ViewBag.Rooms = aDashboardManager.GetTotalRoom();
                ViewBag.Chart = aDashboardManager.GetCount();
                return View("../Dashboard/Dashboard");
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}