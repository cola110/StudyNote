using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cn.T4.codeOut;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DbField dbRender = new DbField("E:\\github\\commonFunc\\T4Lib\\T4\\T_SysApp_LaunchADInfo.tt", "BasicUtility");
            dbRender.NamespaceStr = "T4";
            dbRender.OnlyTable.Add("T_SysApp_LaunchADInfo");//只要生成的表
            Trace.WriteLine(dbRender.Render());
        }
    }
}
