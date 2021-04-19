using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Reflection.Tests.TestLibrary;
namespace Reflection.Tests
{
    public class Tests
    {
        [Fact]
        public void CheckMethod1_Null()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            object data = null ;
            string param = null;
            //act
            object result = moq.Method1(data,param);
            //assert
            Assert.Null(result);                
           
        }
        [Fact]
        public void CheckMethod2_Null()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            object data = null;
            string param = null;
            object expected = null;
            //act
            object result = moq.Method2(data, param,expected);
            //assert
            Assert.Null(result);            
        }
        [Fact]
        public void CheckMethod3_Null()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            object data = null;
            //act
            object result = moq.Method3(data,null,data);
            //assert
            Assert.Null(result);          
            
        }
        [Fact]
        public void CheckMethod1_Expected()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            var data = GetTestUsers();
            var param = GetParamList();
            List<object>[] expectedlist = new List<object>[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                expectedlist[i] = GetValueList(data[i]);
            }
            //act
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < param.Count; j++)
                {
                    object result = moq.Method1(data[i], param[j]);
                    //assert
                    Assert.Equal(expectedlist[i][j],result);
                }
            }
        }
        [Fact]
        public void CheckMethod1_ExpectedFormat()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            var data = GetTestUsers();
            var param = GetParamList();
            var val = GetValueList(data[0]);
            List<object>[] expectedlist = new List<object>[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                expectedlist[i] = GetValueList(data[i]);
            }
            //act
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < param.Count; j++)
                {
                    object result = moq.Method1(data[i], param[j]);
                    //assert
                    Assert.Equal(val[j].GetType(),result.GetType());
                }
            }
        }
        [Fact]
        public void CheckMethod2_Expected()
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
                    var result = moq.Method2(data[i], param[j], expected[j]);
                    var actual = GetValueList(result);
                    //assert
                    Assert.Equal(expected[j],actual[j]);
                }
            }
        }
        [Fact]
        public void CheckMethod2_ExpectedFormat()
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
                    var result = moq.Method2(data[i], param[j], expected[j]);;
                    //assert
                    Assert.IsAssignableFrom<Employee>(result);
                }
            }
        }
        [Fact]
        public void CheckMethod3_Expected()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            var data = GetTestUsers();
            List<object>[] list = new List<object>[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                list[i] = GetValueList(data[i]);
            }
            List<object> expectedlist = new List<object>();
            for (int i = 0; i < data.Length; i++)
            {
                expectedlist.Add(list[i][3]);
            }
            //act
            for (int i = 0; i < data.Length; i++)
            {
                object result = moq.Method3(data[i], "Money", data[i]);
                double expected = 50.25+(double)expectedlist[i];
                var actual = GetValueList(result);
                //assert               
                Assert.Equal(expected,actual[3]);
            }
        }
        [Fact]
        public void CheckMethod3_ExpectedFormat()
        {
            //arrange
            var moq = CreateMock_AllUsers();
            var data = GetTestUsers();
            //act
            for (int i = 0; i < data.Length; i++)
            {
                object result = moq.Method3(data[i], "Money", data[i]);
                //assert               
                Assert.IsAssignableFrom<Employee>(result);
            }
        }
    }
}
