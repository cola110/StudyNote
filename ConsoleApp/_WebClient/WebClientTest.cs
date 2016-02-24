/*
 *  Author：Ad
 *  Data：2016年1月11日 10:00:37
 *  Des：爬虫，抓取特定数据{未开始进行}
 *  Title：A Small File DownLoad Tool
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp._WebClient
{
    public class WebClientTest
    {
        /// <summary>
        /// webclient
        /// </summary>
        public void TestWebClient()
        {
            string uri = "http://www.baidu.com";
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            Console.WriteLine("Sending an HTTP GET request to " + uri);
            //byte[] bResponse = wc.DownloadData(uri);
            //string strResponse = Encoding.UTF8.GetString(bResponse);
            // var webResponse = wc.GetWebResponse(wc);
            var filebyte = wc.DownloadData("http://sf.jb51.net:81/201512/books/JavaScript_qsl(jb51.net).rar");


            Console.WriteLine("HTTP response is: ");
            // Console.WriteLine(strResponse);
        }
    }
}
