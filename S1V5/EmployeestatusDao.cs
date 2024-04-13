using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace S1V5
{
    internal class EmployeestatusDao
    {
        public static List<Employeestatus> GetAll()
        {
            List<Employeestatus> stslist = new List<Employeestatus>();
            try
            {
                MySqlDataReader reader = CommonDao.GetResult("SELECT * FROM statusemployee");

                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");

                    Employeestatus statusemployee = new Employeestatus();
                    statusemployee.Name = name;
                    statusemployee.Id = id;
                    stslist.Add(statusemployee);

                }
            }
            catch (Exception ex) { Console.WriteLine("Can't Connect as : " + ex.Message); }

            return stslist;
        }
        public static Employeestatus GetEmployeestatusById(int statusId)
        {
            Employeestatus employeestatus = new Employeestatus();
            try
            {

                MySqlDataReader reader = CommonDao.GetResult("SELECT * FROM statusemployee WHERE id = " + statusId);
               
                reader.Read();
                int id = reader.GetInt32("id");
                string name = reader.GetString("name");

                employeestatus.Id = id;
                employeestatus.Name = name;
                
                reader.Close();
    
            }
            catch (Exception ex) { Console.WriteLine("Can't Connect as : " + ex.Message); }

            return employeestatus;
        }

    }
}
