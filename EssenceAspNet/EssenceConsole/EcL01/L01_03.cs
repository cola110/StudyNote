using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EssenceConsole.EcL01
{
    public class L01_03
    {
        public void Run()
        {
            IPAddress address = IPAddress.Loopback;
            IPEndPoint endPort = new IPEndPoint(address, 9001);
            TcpListener newServer = new TcpListener(endPort);
            newServer.Start();
            Console.WriteLine("开始监听、、、");
            while (true)
            {
                TcpClient client = newServer.AcceptTcpClient();
                Console.WriteLine("已经建立连接");
                NetworkStream ns = client.GetStream();
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                byte[] request = new byte[4096];
                int length = ns.Read(request, 0, 4096);
                string requestString = utf8.GetString(request, 0, length);
                Console.WriteLine(requestString);

                String statusLine = "HTTP/1.1 200ok \r\n";
                byte[] statusLineBytes = utf8.GetBytes(statusLine);

                String requestBody = @"<html>
<head>
    <title>test header</title>
</head>
<body>
    <h1>hello world</h1>
</body>
</html>";
                byte[] requestBodyStatus = utf8.GetBytes(requestBody);

                string requestHeader = string.Format("Content-Type:text/html;charset=utf-8\r\nContent-length:{0}\r\n", requestBody.Length);

                byte[] requestHeaderBytes = utf8.GetBytes(requestHeader);
                ns.Write(statusLineBytes, 0, statusLineBytes.Length);
                ns.Write(requestHeaderBytes, 0, requestHeaderBytes.Length);


                ns.Write(new byte[] { 13, 10 }, 0, 2);
                ns.Write(requestBodyStatus, 0, requestBodyStatus.Length);
                client.Close();
                if (Console.KeyAvailable)
                {
                    break;
                }
            }
            newServer.Stop();

        }
    }
}
