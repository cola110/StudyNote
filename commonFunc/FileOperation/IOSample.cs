/*
 *  Author：Ad
 *  Data：2015年12月29日 14:29:06
 *  Des：对File类和Directory简单操作
 *  Title：simplly operation on File class and Directory class
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonFunc.FileOperation
{
    public class IOSample
    {
        #region 创建文件，目录，写入文件内容
        /// <summary>
        /// 创建文件，目录，写入文件内容
        /// </summary>
        public static void FileAndDirectoryOp()
        {
            FileStream fs = null;
            StreamWriter writer = null;
            try
            {
                string dirPath = @"c:\iosample";
                string filepath = string.Format(@"{0}\{1}", dirPath, "mytext.txt");
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                    Console.WriteLine(@"创建一个目录：c:\iosample");
                }
                else
                {
                    Console.WriteLine(@"目录：c:\iosample 已存在");
                }

                if (!File.Exists(filepath))
                {
                    fs = File.Create(filepath);
                    Console.WriteLine("新建一个文件：{0}", filepath);
                }
                else
                {
                    fs = File.Open(filepath, FileMode.Open);
                    fs.Seek(0, SeekOrigin.End);
                    Trace.WriteLine("文件{0}已经存在，打开她。", filepath);
                }

                writer = new StreamWriter(fs);
                string content = DateTime.Now.ToString();
                writer.WriteLine(content);
                Trace.WriteLine("写入内容：" + content);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("错误：" + ex.Message);
            }
            finally
            {
                writer.Close();
                fs.Close();
                Trace.WriteLine("关闭数据流。。。。");
            }
        }
        #endregion

        #region fileInfo
        /// <summary>
        /// fileInfo
        /// </summary>
        public static void TestFileInfo()
        {
            FileInfo fi = new FileInfo(@"c:\iosample\mytext.txt");
            if (fi.Exists)
            {
                Debug.WriteLine("Name:\t\t" + fi.Name);
                Debug.WriteLine("CreationTime:\t" + fi.CreationTime);
                Debug.WriteLine("Directory:\t" + fi.Directory);
                Debug.WriteLine("DirectoryName:\t" + fi.DirectoryName);
                Debug.WriteLine("Extension:\t" + fi.Extension);
                Debug.WriteLine("FullName:\t" + fi.FullName);
                Debug.WriteLine("LastAccessTime:\t" + fi.LastAccessTime);
                Debug.WriteLine("LastWriteTime:\t" + fi.LastWriteTime);
            }
        }
        #endregion

        public static void TestInfoOp()
        {
            FileStream fs = null;
            StreamWriter writer = null;

            try
            {
                string dirPath = @"c:\iosample";
                string filePath = string.Format(@"{0}\{1}", dirPath, "mytext.txt");
                DirectoryInfo di = new DirectoryInfo(dirPath);
                if (!di.Exists)
                {
                    di.Create();
                    Debug.WriteLine(@"创建一个目录：c:\iosample");
                }
                else
                {
                    Debug.WriteLine(@"目录：c:\iosample已经存在了");
                }
                Debug.WriteLine(@"目录名字：" + di.Name);
                FileInfo fi = new FileInfo(filePath);
                if (!fi.Exists)
                {
                    fs = fi.Create();
                }
                else
                {
                    fs = fi.Open(FileMode.Open);
                    Debug.WriteLine(@"目录:" + filePath + "已经存在了,打开他");
                }
                writer = new StreamWriter(fs);
                fs.Seek(0, SeekOrigin.End);
                string content = DateTime.Now.ToString();
                writer.WriteLine(content);

                Debug.WriteLine("想文件中写入数据：" + content);
                Debug.WriteLine("Name:\t\t" + fi.Name);
                Debug.WriteLine("CreationTime:\t" + fi.CreationTime);
                Debug.WriteLine("Directory:\t" + fi.Directory);
                Debug.WriteLine("DirectoryName:\t" + fi.DirectoryName);
                Debug.WriteLine("Extension:\t" + fi.Extension);
                Debug.WriteLine("FullName:\t" + fi.FullName);
                Debug.WriteLine("LastAccessTime:\t" + fi.LastAccessTime);
                Debug.WriteLine("LastWriteTime:\t" + fi.LastWriteTime);

            }
            finally
            {
                writer.Close();
                fs.Close();
                Debug.WriteLine("关闭数据流");
            }
        }

        public static void TestIostream()
        {
            string file = "demo.txt";
            FileStream fs = new FileStream(file, FileMode.Create);
            TextWriter writer = new StreamWriter(fs);
            writer.WriteLine("测试字符串");

            writer.Close();
            fs.Close();

            fs = new FileStream(file, FileMode.Open);
            TextReader reader = new StreamReader(fs);
            Debug.WriteLine(reader.ReadToEnd());
            reader.Close();
            fs.Close();
        }
    }
}
