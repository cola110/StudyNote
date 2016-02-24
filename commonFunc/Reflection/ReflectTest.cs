using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonFunc.Reflection
{
    public class ReflectTest
    {
        public void TestReflect()
        {
            string str = "hello";
            Type t = str.GetType();
            Trace.WriteLine(t.FullName);
            Type temp = Type.GetType("System.String", false, false);
            Trace.WriteLine(temp.FullName);
        }
    }
}
