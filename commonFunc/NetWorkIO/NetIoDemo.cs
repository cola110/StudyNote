using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace commonFunc.NetWorkIO
{
    public class NetIoDemo
    {
        public static void DoConnect(string ip, int port)
        {
            TcpClient tc = null;
            NetworkStream ns = null;
            StreamWriter sw = null;

            try
            {
                tc = new TcpClient();
                tc.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                ns = tc.GetStream();
                sw = new StreamWriter(ns, UTF8Encoding.UTF8);
                sw.AutoFlush = true;
                string[] msgs = new string[3] { "Hello", "World!", "--网络问候" };
                foreach (var item in msgs)
                {
                    sw.WriteLine(item);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                sw.Close();
                ns.Close();
                tc.Close();
            }
        }

        public static void DoListen(string ip, int port)
        {
            // TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            TcpListener listener = new TcpListener(IPAddress.Parse(ip), port);
            listener.Start();
            TcpClient client = new TcpClient();
            NetworkStream ns = null;
            StreamReader sr = null;
            bool listening = true;

            try
            {
                Debug.WriteLine("Listen.....");
                while (listening)
                {
                    if (!client.Connected)
                    {
                        client = listener.AcceptTcpClient();
                        Debug.WriteLine("connect...");
                    }

                    ns = client.GetStream();
                    if (ns != null && ns.CanRead)
                    {
                        sr = new StreamReader(ns, UTF8Encoding.UTF8);
                    }

                    try
                    {
                        string msg = sr.ReadLine();
                        if (!string.IsNullOrEmpty(msg))
                        {
                            Debug.WriteLine("接受到的消息：" + msg);
                        }
                        else
                        {
                            listening = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
                ns.Close();
                client.Close();
            }

        }
    }
}
