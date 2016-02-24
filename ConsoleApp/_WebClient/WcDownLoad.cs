/*
 *  Author：Ad
 *  Data：2016年1月11日 10:00:37
 *  Des：WEB CLIENT类下载小文件类，断点下载功能{进行中，持续开发}
 *  Title：A Small File DownLoad Tool
 *  参考博客：
 *      http://www.cnblogs.com/yank/p/HTTP-Range.html
 *      http://blog.csdn.net/SQLDebug_Fan/article/details/23092673
 *      http://www.cnblogs.com/sunheyubo/articles/878026.html
 *      http://blog.sina.com.cn/s/blog_6e51df7f0100sw6t.html
 *      http://www.cnblogs.com/x4646/archive/2013/04/11/3014634.html
 *      http://www.cnblogs.com/ahjesus/archive/2011/05/26/2057934.html
 *      http://www.cnblogs.com/wang7/archive/2012/08/07/2627298.html
 *  待用到博客：
 *      http://www.cnblogs.com/xiarifeixue/archive/2011/04/27/2030394.html
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp._WebClient
{
    public class WcDownLoad
    {
        #region 简单小文件下载
        /// <summary>
        /// 简单小文件下载
        /// </summary>
        public void DownLoadData()
        {
            FileStream fs = null;
            MemoryStream ms = null;
            try
            {
                // http://www.cnblogs.com/qiuweiguo/archive/2011/08/05/2128690.html
                // new WcDownLoad().DownLoadData();
                // string uri = "http://sf.jb51.net:81/201512/books/JavaScript_qsl(jb51.net).rar";
                string uri = "http://gdl.lixian.vip.xunlei.com/F%23yycxsj%28jb51.net%29.rar";
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                Trace.WriteLine("Begin To DownLad Data : " + uri);

                var filebyte = wc.DownloadData(uri);
                ms = new MemoryStream(filebyte);
                string file = string.Format(@"{0}\e.rar", Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));
                fs = new FileStream(file, FileMode.OpenOrCreate);
                ms.WriteTo(fs);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception: " + ex.Message + "\r\n" + ex.StackTrace);
            }
            finally
            {
                ms.Close();
                fs.Close();
                ms.Dispose();
                ms.Dispose();
            }

            Trace.WriteLine(" Web Request DownLoad Data Is Over ! ");
        }
        #endregion

        #region DownLoadData2：实现断点续传
        /// <summary>
        /// DownLoadData2：实现断点续传
        /// </summary>
        public void DownLoadData2()
        {
            FileStream fs = null;
            MemoryStream ms = null;
            try
            {
                // new WcDownLoad().DownLoadData2();
                string uri = "http://sf.jb51.net:81/201512/books/JavaScript_qsl(jb51.net).rar";
                HttpWebRequest web = HttpWebRequest.CreateHttp(uri);
                WebResponse response = web.GetResponse();
                // string filePath = @"E:\github\commonFunc\ConsoleApp\bin\Debug\e.rar";
                var buffer = new byte[10240];
                if (response != null)
                {
                    using (var stream = response.GetResponseStream())
                    {
                        int readTotalSize = 0;
                        int size = stream.Read(buffer, 0, buffer.Length);
                        while (size > 0)
                        {
                            // 只将读出的字节写入文件
                            fs.Write(buffer, 0, size);
                            readTotalSize += size;
                            size = stream.Read(buffer, 0, buffer.Length);
                        }

                        //更新当前进度
                        // this.currentSize += readTotalSize;

                        // 如果返回的response头中Content-Range值为空，说明服务器不支持Range属性，不支持断点续传,返回的是所有数据
                        if (response.Headers["Content-Range"] == null)
                        {
                            // this.isFinished = true;
                            Trace.WriteLine("文件下载完毕！");
                        }
                    }
                }
                //ms = new MemoryStream(filebyte);
                //fs = new FileStream(file, FileMode.OpenOrCreate);
                //ms.WriteTo(fs);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception: " + ex.Message + "\r\n" + ex.StackTrace);
            }
            finally
            {
                ms.Close();
                fs.Close();
                ms.Dispose();
                ms.Dispose();
            }

            Trace.WriteLine(" Web Request DownLoad Data Is Over ! ");
        }
        #endregion
    }
}
