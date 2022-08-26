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
    public class AgentController : Controller
    {
        CompanyManager aCompanyManager = new CompanyManager();
        BranchManager aBranchManager = new BranchManager();
        AgentManager aAgentManager = new AgentManager();

        [HttpGet]
        public ActionResult SaveAgent()
        {
            Agent aAgent = new Agent();
            ViewBag.Company = aCompanyManager.GetAllCompany();
            ViewBag.Branch = aBranchManager.GetAllBranch();
            return View(aAgent);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        public ActionResult SaveAgent(Agent aAgent)
        {
            ViewBag.Company = aCompanyManager.GetAllCompany();

            ViewBag.Branch = aBranchManager.GetAllBranch();
            aAgent.CreatedBy = Convert.ToInt16(Session["Id"]);
            aAgent.CreatedDate = DateTime.Now;
            ViewBag.Message = aAgentManager.Save(aAgent);
            return View();
        }

        [HttpGet]
        public JsonResult IsEmailExist(Agent aAgent)
        {
            List<Agent> Agent = aAgentManager.GetAllAgent();
            bool isExist = Agent.FirstOrDefault(t => t.Email.ToLowerInvariant().Equals(aAgent.Email.ToLower())) != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgentById(Agent Agent)
        {
            var Companies = aAgentManager.GetAllAgent();
            var AgentList = Companies.Where(t => t.Id == Agent.Id).ToList();
            return Json(AgentList);
        }

        [HttpGet]
        public ActionResult ViewAgent()
        {
            List<Agent> Agent = aAgentManager.GetAllAgent();
            ViewBag.Agent = aAgentManager.GetAllAgent();
            return View(Agent);
        }

    }
}