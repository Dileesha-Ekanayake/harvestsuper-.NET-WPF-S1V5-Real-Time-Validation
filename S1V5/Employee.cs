using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1V5
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Nic { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Gender Gender { get; set; }
        public Designation Designation { get; set; }
        public Employeestatus Employeestatus { get; set; }

    }
}
