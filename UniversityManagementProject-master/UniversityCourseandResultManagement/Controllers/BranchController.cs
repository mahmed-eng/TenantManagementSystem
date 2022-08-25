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
        // DepartmentManager aDepartmentManager = new DepartmentManager();
        // DesignationManager aDesignationManager = new DesignationManager();
        BranchManager aBranchManager = new BranchManager();

        [HttpGet]
        public ActionResult SaveBranch()
        {
            Branch aBranch = new Branch();
            //ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            //ViewBag.Designations = aDesignationManager.GetAllDesignations();
            return View(aBranch);
        }

        [HttpPost]
        public ActionResult SaveBranch(Branch aBranch)
        {
           // ViewBag.Departments = aDepartmentManager.GetAllDepartments();
           // ViewBag.Designations = aDesignationManager.GetAllDesignations();
            ViewBag.Message = aBranchManager.Save(aBranch);
            return View();
        }

        [HttpGet]
        public JsonResult IsEmailExist(Branch aBranch)
        {
            List<Branch> Branch = aBranchManager.GetAllBranch();
            bool isExist = Branch.FirstOrDefault(t => t.Email.ToLowerInvariant().Equals(aBranch.Email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBranchById(Branch Branch)
        {
            var Branch = aBranchManager.GetAllBranch();
            var BranchList = Branch.Where(t => t.BranchId == Branch.BranchId).ToList();
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