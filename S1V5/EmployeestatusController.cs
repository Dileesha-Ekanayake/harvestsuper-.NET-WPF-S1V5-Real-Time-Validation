using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1V5
{
    internal class EmployeestatusController
    {

        public static List<Employeestatus> Get()
        {
            return EmployeestatusDao.GetAll();
        }
    }
}
