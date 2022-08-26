using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagement.BLL;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Controllers
{
    public class BranchController : Controller
    {
        //DepartmentManager aDepartmentManager = new DepartmentManager();
        CompanyManager aCompanyManager = new CompanyManager();
           BranchManager aBranchManager = new BranchManager();

        [HttpGet]
        public ActionResult SaveBranch()
        {
            Branch aBranch = new Branch();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            //ViewBag.Branch = aBranchManager.GetAllBranch();
            return View(aBranch);
        }

        [HttpPost]
        public ActionResult SaveBranch(Branch aBranch)
        {
             //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
             ViewBag.Company = aCompanyManager.GetAllCompany();
            // ViewBag.Designations = aDesignationManager.GetAllDesignations();

            aBranch.CreatedBy = Convert.ToInt16(Session["Id"]);
            aBranch.CreatedDate = DateTime.Now;
            ViewBag.Message = aBranchManager.Save(aBranch);
            return View(aBranch);
        }

        [HttpGet]
        public JsonResult IsEmailExist(Branch aBranch)
        {
            List<Branch> Branch = aBranchManager.GetAllBranch();
            bool isExist = Branch.FirstOrDefault(t => t.Email.ToLowerInvariant().Equals(aBranch.Email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBranchById(Branch branch)
        {
            var Branches = aBranchManager.GetAllBranch();
            var BranchList = Branches.Where(t => t.BranchId == branch.BranchId).ToList();
            return Json(BranchList);
        }

        [HttpGet]
        public ActionResult ViewBranch()
        {
            List<Branch> Branch = aBranchManager.GetAllBranch();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            return View(Branch);
        }

    }
}