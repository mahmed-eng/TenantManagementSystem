using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement.Models;


namespace UniversityCourseandResultManagement.Controllers
{
    public class AdminsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admins
        public ActionResult Changepassword()
        {
            return View(db.Admins.ToList());
        }

        public ActionResult Changepassword(Admin login)
        {
            using (SMSEntities db = new SMSEntities())
            {
                var detail = db.Admin_tb.Where(log => log.Password == login.Password
                && log.UserName == login.UserName).FirstOrDefault();
                if (detail != null)
                {
                   detail.NewPassword = login.NewPassword;

                  // userDetail.Password = login.NewPassword;

                    db.SaveChanges();
                    ViewBag.Message = "Password updated Successfully!";

                }
                else
                {
                    ViewBag.Message = "Password not Updated!";
                }
            }
            return View(login);
        }
       
    }
}
