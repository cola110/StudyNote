/*
 *  Author：Ad
 *  Data：2015年12月25日 16:10:28
 *  Des：文件io-写入测试
 *  Title：how to write a text file
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonFunc.FileOperation
{
    public class FileWriteTest
    {
        #region 将一个数组写入文件
        /// <summary>
        /// 将一个数组写入文件
        /// </summary>
        public void WriteArrayToFile()
        {
            string filepath = FilePathHelper.GetRelationPath("arrayTest.txt");
            string[] lines = { "First Line", "Second Line", "Third Line" };
            System.IO.File.WriteAllLines(filepath, lines);
        }
        #endregion

        #region 写入一段文本到文件中
        /// <summary>
        /// 写入一段文本到文件中
        /// </summary>
        public void WriteAllTextToFile()
        {
            string text = "微软的web api是在vs2012上的mvc4项目绑定发行的，它提出的web api是完全基于RESTful标准的，完全不同于之前的（同是SOAP协议的）wcf和webService，它是简单，代码可读性强的，上手快的，如果要拿它和web服务相比，我会说，它的接口更标准，更清晰，没有混乱的方法名称，有的只有几种标准的请求，如get,post,put,delete等，它们分别对应的几个操作，下面讲一下";
            string filepath = FilePathHelper.GetRelationPath("textTest.txt");
            System.IO.File.WriteAllText(filepath, text);
            Trace.WriteLine("测试消息:\r\n" + filepath);
        }
        #endregion

        #region 使用文件流写入文件信息
        /// <summary>
        /// 使用文件流写入文件信息
        /// </summary>
        public void WriteArrayToFileByStream()
        {
            string[] lines = { "First Line", "Second Line", "Third Line" };
            string filepath = FilePathHelper.GetRelationPath("Stream.txt");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath))
            {
                foreach (string line in lines)
                {
                    if (line.Contains("Second") == false)
                    {
                        file.WriteLine(line);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 向文档中追加内容
        /// </summary>
        public void AppendTextToFileByStream()
        {
            string text = "微软的web api是在vs2012上的mvc4项目绑定发行的，它提出的web api是完全基于RESTful标准的，完全不同于之前的（同是SOAP协议的）wcf和webService，它是简单，代码可读性强的，上手快的，如果要拿它和web服务相比，我会说，它的接口更标准，更清晰，没有混乱的方法名称，有的只有几种标准的请求，如get,post,put,delete等，它们分别对应的几个操作，下面讲一下";
            string filepath = FilePathHelper.GetRelationPath("append.txt");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, true))
            {
                file.WriteLine(text);
            }
        }
    }
}
