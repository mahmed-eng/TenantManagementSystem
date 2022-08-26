using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement.BLL;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Controllers
{
    public class CompanyController : Controller
    {
        // DepartmentManager aDepartmentManager = new DepartmentManager();
        // DesignationManager aDesignationManager = new DesignationManager();
        CompanyManager aCompanyManager = new CompanyManager();

        [HttpGet]
        public ActionResult SaveCompany()
        {
            Company aCompany = new Company();
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View(aCompany);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        public ActionResult SaveCompany(Company aCompany)
        {
            aCompany.CreatedBy = Convert.ToInt16(Session["Id"]);
            aCompany.CreatedDate = DateTime.Now;
            ViewBag.Message = aCompanyManager.Save(aCompany);
            return View();
        }

        [HttpGet]
        public JsonResult IsEmailExist(Company aCompany)
        {
            List<Company> Company = aCompanyManager.GetAllCompany();
            bool isExist = Company.FirstOrDefault(t => t.Email.ToLowerInvariant().Equals(aCompany.Email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanyById(Company company)
        {
            var Companies = aCompanyManager.GetAllCompany();
            var CompanyList = Companies.Where(t => t.CompanyId == company.CompanyId).ToList();
            return Json(CompanyList);
        }

        [HttpGet]
        public ActionResult ViewCompany()
        {
            List<Company> Company = aCompanyManager.GetAllCompany();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            return View(Company);
        }

    }
}