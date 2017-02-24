using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace HairSalon
{
    public class DB
    {
        public static SqlConection Connection()
        {
            SqlConnection conn = new SqlConnection(DBConfiguration.ConnectionString);
        }

        public static void CloseSqlConnections(SqlDataReader reader, SqlConnection connection)
        {
            if(reader != null)
            {
                reader.Close();
            }
            if(connection != null)
            {
                connection.Close();
            }
        }

    }
}
