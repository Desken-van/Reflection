using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public class Employee
    {
        public String Name { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double Payday { get; set; }
        public static double Money(Employee employee)
        {
            employee.Payday = employee.Payday + 50.25;
            return employee.Payday;
        }
    }
}
