using cn.jpush.api;
using cn.jpush.lib.Common.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPushEntry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // new JPushKey().TestMethod();
            //var ApiKey = JPushKey.GetAppKey();
            //var APIMasterSecret = JPushKey.GetMasterSecret();
            var ApiKey = "";// JPushKey.GetAppKey();
            var APIMasterSecret = "";// JPushKey.GetMasterSecret();

            JPushClient client = new JPushClient(ApiKey, APIMasterSecret);

            // client.getAliasDeviceList
            HashSet<string> hs = new HashSet<string>() { "test" };
            // var rest = client.updateDeviceTagAlias("0606faeed51", "", hs, null);140fe1da9ea932132d2
            // var rest = client.updateDeviceTagAlias("140fe1da9ea932132d2", "", hs, null);
            var rest = client.getDeviceTagAlias("140fe1da9ea932132d2");
            Trace.WriteLine("----------------------------------------");
            /*
             Send request - POST https://device.jpush.cn/v3/devices/0606faeed51 2016/2/1 14:18:46
            Request Content - {
              "alias": "",
              "tags": {
                "add": [
                  "test"
                ]
              }
            } 2016/2/1 14:18:47
            JPush API Rate Limiting params - quota:1200, remaining:1199, reset:60  2016/2/1
            14:18:49
            fail  to get response - BadRequest 2016/2/1 14:18:49
            Response Content - {"error":{"code":7002, "message":"The registration_id does no
            t belong to this appkey!"}} 2016/2/1 14:18:49
             */


            Trace.WriteLine("\r\n");
            Trace.WriteLine(rest);
            Trace.WriteLine("\r\n");

            Trace.WriteLine("----------------------------------------");

            Console.Write(rest);

        }
    }
}
