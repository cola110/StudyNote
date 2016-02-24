using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepth_CSharp.L06
{
    public class L06_01
    {
        public void Tst()
        {
            Func<string, string> rest = delegate(string ms)
            {
                return ms;
            };
            // Console
            Console.WriteLine(rest("test122"));

            // string str = null;
            rest = ms => { return ms; };

            rest = e => e;

            Console.WriteLine(rest("testtset"));


            List<string> list = new List<string>();

            list.ForEach(e => e += 5);
            list.FindAll(e => e.Length > 5);
            list.FindAll(e => e.Length > 5).ForEach(e => e += 2);

        }
    }
}
