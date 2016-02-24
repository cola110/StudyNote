using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EssenceConsole.EcL01
{
    public class L01_02
    {
        public void testWebServer()
        {
            // new EssenceConsole.L01.L01_02().testWebServer();
            IPAddress address = IPAddress.Loopback;
            IPEndPoint endPort = new IPEndPoint(address, 9001);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPort);
            socket.Listen(10);
            Console.WriteLine("开始监听，端口号：" + endPort.Port);
            while (true)
            {
                // 
                Socket client = socket.Accept();
                // 
                Console.WriteLine(client.RemoteEndPoint);
                // 
                byte[] buffer = new byte[4096];
                // 
                int length = client.Receive(buffer, 4096, SocketFlags.None);
                // 
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                //
                string requestString = utf8.GetString(buffer, 0, length);
                // 
                Console.WriteLine(requestString);
                // 
                string statusLine = "HTTP/1.1 200 OK\r\n";
                byte[] statusLineBytes = utf8.GetBytes(statusLine);
                // 
                string responseBody = "<html><head><title>from server</title></head><body><h1>hello world</h1></body></html>";
                byte[] responseBodyBytes = utf8.GetBytes(responseBody);
                // 
                string responseHeader = string.Format("content-Type:text/html;charset=utf-8\r\ncontent-length:{0}\r\n", responseBody.Length);
                byte[] responseHeaderBytes = utf8.GetBytes(responseHeader);

                // 
                client.Send(statusLineBytes);
                // client.
                // 
                client.Send(responseHeaderBytes);
                // 
                client.Send(new byte[] { 13, 14 });
                // 
                client.Send(responseBodyBytes);

                client.Close();

                if (Console.KeyAvailable)
                {
                    break;
                }
            }
            socket.Close();
        }

        public void testWebServer1()
        {
            // 取得本机的 loopback 网络地址，即 127.0.0.1
            IPAddress address = IPAddress.Loopback;
            // 创建可以访问的端点，49152 表示端口号
            IPEndPoint endPoint = new IPEndPoint(address, 9001);
            // 创建一个 socket，使用 IPv4 地址，传输控制协议 TCP，双向、可靠、基于连接的字节流
            Socket socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            // 将 socket 绑定到一个端点上
            socket.Bind(endPoint);
            // 设置连接队列的长度
            socket.Listen(10);
            Console.WriteLine("开始监听, 端口号：{0}.", endPoint.Port);
            while (true)
            {
                // 开始监听，这个方法会阻塞线程的执行，直到接受到一个客户端的连接请求
                Socket client = socket.Accept();
                // 输出客户端的地址
                Console.WriteLine(client.RemoteEndPoint);
                // 准备读取客户端请求的数据，读取的数据将保存在一个数组中
                byte[] buffer = new byte[4096];
                // 接受数据
                int length = client.Receive(buffer, 4096, SocketFlags.None);
                // 将请求的数据翻译为 UTF-8
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                string requestString = utf8.GetString(buffer, 0, length);
                // 显示请求的内容
                Console.WriteLine(requestString);
                // 状态行
                string statusLine = "HTTP/1.1 200 OK\r\n";
                byte[] statusLineBytes = utf8.GetBytes(statusLine);
                // 准备发送到客户端的网页
                string responseBody
                    = @"<html>
                            <head><title>From Socket Server</title></head>
                            <body><h1>Hello, world.</h1></body>
                        </html>";
                byte[] responseBodyBytes = utf8.GetBytes(responseBody);
                // 回应的头部
                string responseHeader =
                    string.Format(
                        "Content-Type: text/html; charset=UTF-8\r\nContent-Length: {0}\r\n",
                        responseBody.Length
                        );
                byte[] responseHeaderBytes = utf8.GetBytes(responseHeader);

                // 向客户端发送状态信息
                client.Send(statusLineBytes);
                // 向客户端发送回应头
                client.Send(responseHeaderBytes);
                // 头部与内容的分隔行
                client.Send(new byte[] { 13, 10 });
                // 向客户端发送内容部分
                client.Send(responseBodyBytes);

                // 断开与客户端的连接
                client.Close();
                if (Console.KeyAvailable)
                    break;
            }
            // 关闭服务器
            socket.Close();
        }
    }
}
