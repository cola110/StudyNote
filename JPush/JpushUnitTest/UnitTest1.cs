using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cn.jpush.lib.device;
using System.Diagnostics;
using System.Collections.Generic;

namespace JpushUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        string registrationId = null;
        public UnitTest1()
        {
            /*
                001afb83f14
                0301aa88e9f
                0606faeed51
                071f721223a
                08009c7dc45
             */
            registrationId = "001afb83f14";
        }

        /// <summary>
        /// 查询设备对应的别名标签信息
        /// </summary>
        [TestMethod]
        public void TestQueryDeviceTagAliasById()
        {
            var client = new DeviceClient("9a59c410e24239fcc13abf21", "d79f57f5e603b413aa16a00b");

            string res = client.QueryDeviceTagAliasById("0606faeed51");

            Console.Write(res);
            Trace.WriteLine(res);
        }


        /// <summary>
        /// 查询所有的标签信息
        /// </summary>
        [TestMethod]
        public void TestGetTagList()
        {
            var client = new TagClient("9a59c410e24239fcc13abf21", "d79f57f5e603b413aa16a00b");

            string res = client.GetTagList();

            Console.Write(res);
            Trace.WriteLine(res);
        }

        /// <summary>
        /// 判断设备与标签的绑定关系
        /// </summary>
        [TestMethod]
        public void TestIsDeviceIdsBindWithTags()
        {
            var client = new TagClient("9a59c410e24239fcc13abf21", "d79f57f5e603b413aa16a00b");

            string deviceId = string.Empty;
            // deviceId = "090fdab226d";
            // deviceId = "08009c7dc45";
            // deviceId = "001afb83f14";
            // deviceId = "0301aa88e9f";
            deviceId = "02164e0464c";
            string res = client.IsDeviceIdsBindWithTags("send", "08009c7dc45");

            Console.Write(res);
            Trace.WriteLine(res);
        }

        /// <summary>
        /// 判断设备与标签的绑定关系
        /// </summary>
        [TestMethod]
        public void TestDeleteTagByTagName()
        {
            var client = new TagClient("9a59c410e24239fcc13abf21", "d79f57f5e603b413aa16a00b");

            string deviceId = string.Empty;
            string res = client.DeleteTagByTagName("send");

            Console.Write(res);
            Trace.WriteLine(res);
        }


        /// <summary>
        /// 判断设备与标签的绑定关系
        /// </summary>
        [TestMethod]
        public void TestSetDeviceIdTag()
        {
            var client = new TagClient("9a59c410e24239fcc13abf21", "d79f57f5e603b413aa16a00b");

            string deviceId = string.Empty;
            HashSet<string> addDevices = new HashSet<string>();
            addDevices.Add("0606faeed51");
            string res = client.SetDeviceIdTag("send", addDevices, null);

            Console.Write(res);
            Trace.WriteLine(res);
        }
    }
}
