using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Utility
{
    internal class DBConnection
    {
        public static String getConnectionString()
        {
            return "Server = DESKTOP-6CA5ALC; Database=Order_Management_System_DB; Trusted_Connection=True";
        }

        public static SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
            return conn;
        }

    }
}
