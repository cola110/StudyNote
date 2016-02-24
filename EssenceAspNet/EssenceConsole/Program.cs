using EssenceConsole.EcL01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            //System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
            //string requestString = utf8.GetString(new byte[] { 13, 10 }, 0, 2);
            //Console.WriteLine(requestString);
            //Console.Read();
            // new EssenceConsole.L01.L01_02().testWebServer();
            // new EssenceConsole.L01.L01_04().Run();
            System.Type hostType = typeof(Intelligencer);

            Intelligencer intelligencer
                = System.Web.Hosting.ApplicationHost.CreateApplicationHost(
                    hostType,
                    "/",
                    System.Environment.CurrentDirectory
                  )
                  as Intelligencer;

            Console.WriteLine("Current domain id:{0}\r\n", AppDomain.CurrentDomain.Id);
            Console.WriteLine(intelligencer.Report());
            
            // test();

        }

        public static void test()
        {
            //System.Type hostType = typeof(Intelligencer);
            // Intelligencer intelligencer = System.Web.Hosting.ApplicationHost.CreateApplicationHost(hostType, "/", System.Environment.CurrentDirectory) as Intelligencer;

            System.Type hostType = typeof(Intelligencer);

            Intelligencer intelligencer
                = System.Web.Hosting.ApplicationHost.CreateApplicationHost(
                    hostType,
                    "/",
                    System.Environment.CurrentDirectory
                  )
                  as Intelligencer;

            Console.WriteLine("Current domain id:{0}\r\n", AppDomain.CurrentDomain.Id);
            Console.WriteLine(intelligencer.Report());
        }
    }
}
