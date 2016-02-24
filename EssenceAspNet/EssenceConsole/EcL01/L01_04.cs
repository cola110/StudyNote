using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EssenceConsole.EcL01
{
    public class L01_04
    {
        public void Run()
        {
            if (!HttpListener.IsSupported)
            {
                throw new Exception("系统不支持");
            }

            string[] prefixes = new string[] { "http://localhost:9001/" };
            HttpListener listener = new HttpListener();
            foreach (string item in prefixes)
            {
                listener.Prefixes.Add(item);
            }
            listener.Start();
            Console.WriteLine("监听中....");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                Console.WriteLine("{0} {1} HTTP/1.1", request.HttpMethod, request.RawUrl);
                Console.WriteLine("Accept:{0}", string.Join(",", request.AcceptTypes));
                Console.WriteLine("Accept-Language:{0}", string.Join(",", request.UserLanguages));
                Console.WriteLine("User-Agent:{0}", request.UserAgent);
                Console.WriteLine("Accept-Encoding:{0}", request.Headers["Accept-Encoding"]);
                Console.WriteLine("Connection:{0}", request.KeepAlive ? "Keep-Alive" : "Close");
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Host:{0}", request.UserHostName);
                Console.WriteLine("Pragma:{0}", request.Headers["Pragma"]);

                HttpListenerResponse response = context.Response;
                string responseString = @"<html><head><title>test header</title></head><body><h1>hello word</h1></body></html>";
                response.ContentLength64 = System.Text.Encoding.UTF8.GetByteCount(responseString);
                response.ContentType = "text/html;charset=utf-8";
                System.IO.Stream output = response.OutputStream;
                System.IO.StreamWriter writer = new System.IO.StreamWriter(output);
                writer.Write(responseString);
                writer.Close();

                if (Console.KeyAvailable)
                {
                    break;
                }
            }
            listener.Stop();
        }
    }
}
