using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagement.Gateway
{
    public class ResetGateway:Gateway
    {
        public int UnassignTeacher()
        {
            Query = "UPDATE AssignTeacher_tb SET Status = 'False' WHERE Status ='True'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }

        public int Unallocate()
        {
            Query = "DELETE FROM RoomAllocation_tb";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowCount = Command.ExecuteNonQuery();
            Connection.Close();
            return rowCount;
        }
    }
}