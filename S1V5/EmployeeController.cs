using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace S1V5
{
    internal class EmployeeController
    {
        public static List<Employee> Get(Hashtable ht)
        {
            List<Employee> employees = new List<Employee>();

            if (ht == null || ht.Count == 0)
            {
                employees = EmployeeDao.GetAll();
            }
            else
            {
                string? name = ht["name"] as string;
                Gender? gender = ht["gender"] as Gender;

                if (name != null && gender != null)
                {
                    employees = EmployeeDao.GetAllByNameAndGender(name, gender);
                }
                else if (name != null)
                {
                    employees = EmployeeDao.GetAllByName(name);
                }
                else if (gender != null)
                {
                    employees = EmployeeDao.GetAllByGender(gender);
                }
            }
            return employees;
        }

        public static string Post(Employee employee)
        {
            string msg = "";
            string err = "";

            DateTime today = DateTime.Now;
            int age = today.Year - employee.DOB.Year;

            if (age < 18) { err = err + "\nMust be 18 Years"; }

            List<Employee> employees = EmployeeDao.GetByNic(employee.Nic);

            if (employees != null && employees.Count > 0)
            {
                err = err + "\n NIC is Already Exists";
            }

            if (string.IsNullOrEmpty(err))
            {
                string dberr = EmployeeDao.Save(employee);
                
                if (dberr.Equals("1"))
                {
                    msg = "1";
                }
                else { msg = "DB Error : " + dberr; }
            }
            else { msg = "Data Errors : \n" + err; }

            return msg;
        }
    }
}
