using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace S1V5
{
    internal class DesignationDao
    {

        public static List<Designation> GetAll()
        {
            List<Designation> deslist = new List<Designation>();
            try
            {
                MySqlDataReader reader = CommonDao.GetResult("SELECT * FROM designation");

                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");

                    Designation designation = new Designation();
                    designation.Name = name;
                    designation.Id = id;
                    deslist.Add(designation);

                }
            }
            catch (Exception ex) { Console.WriteLine("Can't Connect as : " + ex.Message); }

            return deslist;
        }
        public static Designation GetDesignationById(int designationId)
        {
            Designation designation = new Designation();
            try
            {
                MySqlDataReader reader = CommonDao.GetResult("SELECT * FROM designation WHERE id =" + designationId);
                reader.Read();
                int id = reader.GetInt32("id");
                string name = reader.GetString("name");

                designation.Id = id;
                designation.Name = name;

                reader.Close();
                
            }
            catch (Exception ex) { Console.WriteLine("Can't Connect as : " + ex.Message); }

            return designation;
        }

    }
}
