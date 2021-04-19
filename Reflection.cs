using System;
using System.Web.Mvc;

namespace Reflection
{
    public class Reflection :Controller
    {
        IRepository repo;
        public Reflection(IRepository r)
        {
            repo = r;
        }
        public  object Method1(object obj, string name)
        {
            if(obj == null || name == null)
            {
                return null;
            }
            else
            {
                Type type = obj.GetType();
                object result = null;
                var prop = type.GetProperty(name);
                result = prop.GetValue(obj);
                return result;
            }
        }
        public object Method2(object obj, string name, params object[] argument)
        {
            if (obj == null || name == null)
            {
                return null;
            }
            else
            {
                Type type = obj.GetType();
                var prop = type.GetProperty(name);
                prop.SetValue(obj, argument[0]);
                return obj;
            }
        }
        public object Method3(object obj, string name, params object[] argument)
        {
            if (obj == null || name == null)
            {
                return null;
            }
            else
            {
                Type type = obj.GetType();
                var prop = type.GetMethod(name);
                prop.Invoke(obj, argument);
                return obj;
            }
        }    
    }
}
