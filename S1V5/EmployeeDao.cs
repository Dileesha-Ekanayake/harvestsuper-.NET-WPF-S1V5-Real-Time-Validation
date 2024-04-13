using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace S1V5
{
    internal class EmployeeDao
    {
        public static List<Employee> Get(string query)
        {
            List<Employee> emplist = new List<Employee>();

            try
            {
                MySqlDataReader reader = CommonDao.GetResult(query);

                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    string nic = reader.GetString("nic");
                    DateTime dobirth = reader.GetDateTime("dob");
                    string email = reader.GetString("email");
                    string mobile = reader.GetString("mobile");
                    int genderId = reader.GetInt32("gender_id");
                    int designationId = reader.GetInt32("designation_id");
                    int statusId = reader.GetInt32("statusemployee_id");

                    Gender gender = GenderDao.GetGenderById(genderId);
                    Designation designation = DesignationDao.GetDesignationById(designationId);
                    Employeestatus employeestatus = EmployeestatusDao.GetEmployeestatusById(statusId);

                    Employee emp = new Employee();
                    emp.Id = id;
                    emp.Name = name;
                    emp.Nic = nic;
                    emp.DOB = dobirth;
                    emp.Email = email;
                    emp.Mobile = mobile;
                    emp.Gender = gender;
                    emp.Designation = designation;
                    emp.Employeestatus = employeestatus;

                    emplist.Add(emp);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine("Can't Connect as : " + ex.Message); }

            return emplist;

        }
        public static List<Employee> GetAll()
        {

            return Get("SELECT * FROM employee");
            
        }

        public static List<Employee> GetAllByName(string name)
        {
            return Get("SELECT * FROM employee WHERE name like '" + name + "%'");
        }

        public static List<Employee> GetAllByGender(Gender gender)
        {
            return Get("SELECT * FROM employee WHERE gender_id = " + gender.Id);
        }

        public static List<Employee> GetAllByNameAndGender(string name, Gender gender)
        {
            return Get("SELECT * FROM employee WHERE name like '" + name + "%' AND gender_id = " + gender.Id );
        }

        public static List<Employee> GetByNic(string nic)
        {
            return Get("SELECT * FROM employee WHERE nic='" + nic + "'");
        }
        public static string Save(Employee employee)
        {
            string msg = "";
            DateOnly dateOnly = DateOnly.FromDateTime(employee.DOB);
            string formattedDOB = dateOnly.ToString("yyyy-MM-dd");

            string sql = "INSERT INTO employee (name, dob, gender_id, nic, mobile, email, designation_id, statusemployee_id) VALUES ('" +
                        employee.Name + "', '" +
                        formattedDOB + "' , '" +
                        employee.Gender.Id + "' , '" +
                        employee.Nic + "' , '" +
                        employee.Mobile + "' , '" +
                        employee.Email + "' , '" +
                        employee.Designation.Id + "' , '" +
                        employee.Employeestatus.Id + "')";


            msg = CommonDao.Modify(sql);

            return msg;
        }

    }
}
