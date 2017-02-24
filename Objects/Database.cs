using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace HairSalon
{
    public class DB
    {
        public static SqlConnection Connection()
        {
            SqlConnection conn = new SqlConnection(DBConfiguration.ConnectionString);
            return conn;
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

        public static void TableDeleteAll(string tableName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM " + tableName + ";", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
