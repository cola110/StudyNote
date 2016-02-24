/*
 *  Author：Ad
 *  Data：2015年12月25日 17:17:58
 *  Des：文件io-读取测试
 *  Title：how to read a text file
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonFunc.FileOperation
{
    /// <summary>
    /// 读取一个文件：文件可能不存在
    /// </summary>
    public class FileReadTest
    {
        public string ReadAllTextToDebug()
        {
            string filepath = FilePathHelper.GetRelationPath("textTest.txt");
            string result = System.IO.File.ReadAllText(filepath);
            Trace.WriteLine("\r\n");
            Trace.WriteLine(result);
            Trace.WriteLine("\r\n");
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Tuple<int, string> ReadTextLineByline()
        {
            int count = 0;
            string text = null;
            string line = null;
            string filepath = FilePathHelper.GetRelationPath("textTest.txt");
            var file = new System.IO.StreamReader(filepath);
            while ((line = file.ReadLine()) != null)
            {
                text += "\r\n" + line;
                count++;
            }
            return new Tuple<int, string>(count, text);
        }

        public string ReadAllLintToDebug()
        {
            string result = null;
            string filepath = FilePathHelper.GetRelationPath("textTest.txt");
            string[] lines = System.IO.File.ReadAllLines(filepath);

            foreach (var line in lines)
            {
                Debug.WriteLine("\t" + line);
                result += line;
            }
            return result;
        }


        public string ReadAllLineToDebug()
        {
            string result = null;
            string filepath = FilePathHelper.GetRelationPath("textTest.txt");
            var lines = System.IO.File.ReadLines(filepath);

            foreach (var line in lines)
            {
                Debug.WriteLine("\t" + line);
                result += line;
            }
            return result;
        }
    }
}
