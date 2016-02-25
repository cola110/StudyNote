using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cn.jpush.lib.report;
using System.Collections.Generic;
using System.Diagnostics;

namespace JpushUnitTest
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new ReportClient("9a59c410e24239fcc13abf21", "d79f57f5e603b413aa16a00b");
            List<string> hads = new List<string>();
            hads.Add("3957262421");
            string res = client.GetRecevicedCount(hads);

            Console.Write(res);
            Trace.WriteLine(res);
        }
    }
}
