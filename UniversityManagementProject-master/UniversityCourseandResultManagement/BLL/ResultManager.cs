using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Gateway;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.BLL
{
    public class ResultManager
    {
        ResultGateway aResultGateway = new ResultGateway();

        public List<GradeLetter> GetAllGradeLetters()
        {
            return aResultGateway.GetAllGradeLetters();
        }

        public string Save(Result aResult)
        {
            if (SaveUpdate(aResult.StudentId, aResult.CourseId, aResult.GradeId))
            {
                return "Result Update Successfully Done";
            }
            else
            {
                return "Result Save Successfully Done";
            }
        }

        private bool SaveUpdate(int stdid, int crsid, int grdid)
        {
            return aResultGateway.SaveUpdate(stdid, crsid, grdid);
        }

        public List<ResultVM> GetAllResult()
        {
            return aResultGateway.GetAllResult();
        }
    }
}