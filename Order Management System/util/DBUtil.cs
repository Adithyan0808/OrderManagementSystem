using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Util
{
    internal class DBUtil
    {
        public static String getConnectionString()
        {
            return "Server = DESKTOP - 6CA5ALC; Database=Transport Management System; Trusted_Connection=True";
        }
        
        public static SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            return conn;
        }


    }
}
