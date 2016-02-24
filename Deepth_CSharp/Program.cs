using Deepth_CSharp.L01;
using Deepth_CSharp.L02;
using Deepth_CSharp.L03;
using Deepth_CSharp.L05;
using Deepth_CSharp.L06;
using Deepth_CSharp.L09;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepth_CSharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Trace.WriteLine("test");
            // new L01_2().ReadXml();
            // L02_02.maintest();
            // TestL03_03();
            // new L05_01().EnclosingMethod();
            // new L05_01().ChangingMethod();
            // new L06_01().Tst();
            new L09_01().GetExpression();
            Console.Read();
        }

        public static void TestL03_03()
        {
            string text = "Do you like green egg and ham? Do you like green egg and ham?";
            var rest = L03_01.CountWord(text);
            foreach (KeyValuePair<string, int> item in rest)
            {
                Trace.WriteLine(item.Key + ":" + item.Value);
            }
        }
    }
}
