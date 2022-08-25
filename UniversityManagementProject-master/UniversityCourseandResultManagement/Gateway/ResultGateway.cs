using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagement.Models;

namespace UniversityCourseandResultManagement.Gateway
{
    public class ResultGateway:Gateway
    {
        public List<GradeLetter> GetAllGradeLetters()
        {
            Query = "SELECT * FROM Grade_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<GradeLetter> gradeLetters = new List<GradeLetter>();
            while (Reader.Read())
            {
                GradeLetter aGradeLetter = new GradeLetter()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    Grade = Convert.ToString(Reader["Grade"])
                };
                gradeLetters.Add(aGradeLetter);
            }
            Connection.Close();
            Reader.Close();
            return gradeLetters;
        }

        public bool SaveUpdate(int stdid, int crsid, int grdid)
        {
            Connection.Open();
            Query = "SELECT COUNT(*) FROM Result_tb WHERE StudentId = '" + stdid + "' AND CourseId = '" + crsid + "' ";
            Command = new SqlCommand(Query, Connection);
            int count = (int)Command.ExecuteScalar();

            if (count > 0)
            {
                Query = "UPDATE Result_tb SET GradeId = '" + grdid + "' WHERE StudentId = '" + stdid + "' AND CourseId = '" + crsid + "' ";
                Command = new SqlCommand(Query, Connection);
                int rowCount = Command.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            else
            {
                Query = "INSERT INTO Result_tb(StudentId, CourseId, GradeId) VALUES (@stdid, @crsid, @grade)";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("stdid", stdid);
                Command.Parameters.AddWithValue("crsid", crsid);
                Command.Parameters.AddWithValue("grade", grdid);
                int rowCount = Command.ExecuteNonQuery();
                Connection.Close();
                return false;
            }

        }

        public List<ResultVM> GetAllResult()
        {
            Connection.Open();
            Query = "SELECT et.StudentId as stdid, ct.CourseCode, ct.CourseName, gt.Grade FROM Enroll_tb as et INNER JOIN Course_tb" +
                    " as ct on et.CourseId = ct.Id LEFT JOIN Result_tb as rt on et.CourseId = rt.CourseId AND et.StudentId = rt.StudentId " +
                    "LEFT JOIN Grade_tb as gt on rt.GradeId = gt.Id";
            Command = new SqlCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            List<ResultVM> resultVms = new List<ResultVM>();
            while (Reader.Read())
            {
                ResultVM aResultVm = new ResultVM()
                {
                    StudentId = Convert.ToInt32(Reader["stdid"]),
                    CourseCode = Convert.ToString(Reader["CourseCode"]),
                    CourseName = Convert.ToString(Reader["CourseName"]),
                    Grade = Convert.ToString(Reader["Grade"])
                };
                resultVms.Add(aResultVm);
            }
            Reader.Close();
            Connection.Close();
            return resultVms;
        }
    }
}