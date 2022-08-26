using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class AgentManager
    {
        AgentGateway aAgentGateway = new AgentGateway();

        public string Save(Agent aAgent)
        {
            if (aAgentGateway.Save(aAgent) > 0)
            {
                return "Agent Save Successfully!!";
            }
            else
            {
                return "Failed";
            }
        }

        public List<Agent> GetAllAgent()
        {
            return aAgentGateway.GetAllAgent();
        }
    }
}