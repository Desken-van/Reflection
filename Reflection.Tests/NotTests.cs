using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Reflection.Tests.TestLibrary;

namespace Reflection.Tests
{
    public class NotTests
    {
        [Fact]
        public void CheckMethod1_NotNull()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            var data = GetTestUsers();
            var param = GetParamList();
            //act
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < param.Count; j++)
                {
                    object result = moq.Method1(data[i], param[j]);
                    //assert
                    Assert.NotNull(result);
                }
            }
        }
        [Fact]
        public void CheckMethod2_NotNull()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            var data = GetTestUsers();
            var param = GetParamList();
            var expected = GetValueList(data[data.Length - 1]);
            //act
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < param.Count; j++)
                {
                    object result = moq.Method2(data[i], param[j], expected[j]);
                    //assert
                    Assert.NotNull(result);
                }
            }
        }
        [Fact]
        public void CheckMethod3_NotNull()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            var data = GetTestUsers();
            //act
            for (int i = 0; i < data.Length; i++)
            {
                object result = moq.Method3(data[i], "Money", data[i]);
                //assert
                Assert.NotNull(result);
            }
        }
        [Fact]
        public void CheckMethod1_NotExpected()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            var data = GetTestUsers();
            var param = GetParamList();
            Employee employee = new Employee()
            {
                Name = "Peter",
                Number = 4,
                Date = DateTime.Now,
                Payday = 20.50
            };
            //act
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < param.Count; j++)
                {
                    object result = moq.Method1(data[i], param[j]);
                    //assert
                    Assert.NotEqual(employee, result);
                }
            }
        }
        [Fact]
        public void CheckMethod2_NotExpected()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            var data = GetTestUsers();
            var param = GetParamList();
            Employee employee = new Employee()
            {
                Name = "Peter",
                Number = 4,
                Date = DateTime.Now,
                Payday = 20.50
            };
            var argument = GetValueList(data[data.Length - 1]);
            var expected = GetValueList(employee);
            //act
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < param.Count; j++)
                {
                    var result = moq.Method2(data[i], param[j], argument[j]);
                    var actual = GetValueList(result);
                    //assert
                    Assert.NotEqual(expected[j], actual[j]);
                }
            }
        }
    }
}
