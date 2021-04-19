using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public interface IRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
    }
}
