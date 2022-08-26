using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class BranchManager
    {
        BranchGateway aBranchGateway = new BranchGateway();

        public string Save(Branch aBranch)
        {
            if (aBranchGateway.Save(aBranch) > 0)
            {
                return "Branch Save Successfully!!";
            }
            else
            {
                return "Failed";
            }
        }

        public List<Branch> GetAllBranch()
        {
            return aBranchGateway.GetAllBranch();
        }
    }
}