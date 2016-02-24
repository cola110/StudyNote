using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cn.jpush.lib.push;
using System.Diagnostics;

namespace JpushUnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestValidataPush()
        {
            var client = new PushClient("9a59c410e24239fcc13abf21", "d79f57f5e603b413aa16a00b");

            string res = client.ValidataPush();

            Console.Write(res);
            Trace.WriteLine(res);
        }
    }
}
