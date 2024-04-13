using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace S1V5
{
    internal class GenderDao
    {
        public static List<Gender> GetAll()
        {
            List<Gender> genlist = new List<Gender>();
            try
            {
                MySqlDataReader reader = CommonDao.GetResult("SELECT * FROM gender");

                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");

                    Gender gender = new Gender();
                    gender.Name = name;
                    gender.Id = id;
                    genlist.Add(gender);

                }
            }catch (Exception ex) { Console.WriteLine("Can't Connect as : " + ex.Message); }

            return genlist;
        }

        public static Gender GetGenderById(int genderId)
        {
            Gender gender = new Gender();
            try
            {
                MySqlDataReader reader = CommonDao.GetResult("SELECT * FROM gender WHERE id = " + genderId);
                
                reader.Read();
                int id = reader.GetInt32("id");
                string name = reader.GetString("name");

                gender.Id = id;
                gender.Name = name;
               
                reader.Close();
                
            }
            catch (Exception ex) { Console.WriteLine("Can't Connect as : " + ex.Message); }

            return gender;
        }

    }
}
