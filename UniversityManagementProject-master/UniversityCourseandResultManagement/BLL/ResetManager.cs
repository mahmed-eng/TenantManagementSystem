using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;

namespace UniversityCourseandResultManagement.BLL
{
    public class ResetManager
    {
        ResetGateway aResetGateway = new ResetGateway();

        public int UnassignTeacher()
        {
            return aResetGateway.UnassignTeacher();
        }

        public int Unallocate()
        {
            return aResetGateway.Unallocate();
        }
    }
}