using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace S1V5
{
    internal class CommonDao
    {
        public static MySqlConnection GetDbConn()
        {
            string connectionString = "server=localhost; uid=us2; pwd=abcd1234; database=harvest";
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't Connect as : " + ex.Message);
                throw;
            }
        }

        public static MySqlDataReader GetResult(string query)
        {
            MySqlConnection conn = GetDbConn();
            try
            {
                MySqlCommand cmmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
                throw;
            }
        }

        public static string Modify(string query)
        {
            string msg = "0";
            MySqlConnection conn = GetDbConn();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows != 0)
                {
                    msg = "1";
                }
                return msg;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
                throw;
            }
        }
    }

}
