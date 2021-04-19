using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reflection.Tests
{
    public class TestLibrary
    {
        public static Employee[] GetTestUsers()
        {
           Employee[] users = new Employee[]
            {
                new Employee  
                {
                    Name = "Sam",
                    Number = 1,
                    Date = DateTime.Now,
                    Payday = 200.50 
                },
                new Employee  
                {
                Name = "Dean",
                Number = 2,
                Date = DateTime.Now,
                Payday = 100.50
                },
                new Employee
                {
                Name = "John",
                Number = 3,
                Date = DateTime.Now,
                Payday = 50.50
                },

            };
            return users;
        }
        public static List<string> GetParamList()
        {
            Employee employee = new Employee();
            Type type = employee.GetType();
            PropertyInfo[] list = type.GetProperties();
            List<string> data = new List<string>(); 
            foreach (var s in list)
            {
                data.Add(s.Name);
            }
            return data;
        }
          public static List<object> GetValueList(object obj)
        {
            Type type = obj.GetType();
            object result = null;
            List<string> param = GetParamList();
            List<object> value = new List<object>();
            foreach(var s in param)
            {
                var prop = type.GetProperty(s);
                value.Add(prop.GetValue(obj));
            }
            return value;
           }
        public static Reflection CreateMock_AllUsers()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestUsers());
            var moq = new Reflection(mock.Object);
            return moq;
        }
    }
}
