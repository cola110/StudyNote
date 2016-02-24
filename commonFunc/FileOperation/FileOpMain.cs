using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonFunc.FileOperation
{
    public class FileOpMain
    {

        /// <summary>
        /// 主入口
        /// </summary>
        public void FileOpAction()
        {
            FileOpMain.ReadFileToDebug();
            FileOpMain.WriteToFile();
        }

        #region file operation
        /// <summary>
        /// 读取文件操作
        /// </summary>
        public static void ReadFileToDebug()
        {
            var reader = new FileReadTest();
            // var rest = reader.ReadAllTextToDebug();
            // var rest = reader.ReadTextLineByline();
            var rest = reader.ReadAllLintToDebug();
            Debug.WriteLine("读取结果是：\r\n");
            // Debug.WriteLine(rest.Item1 + rest.Item2);
            Debug.WriteLine(rest);
        }


        /// <summary>
        /// 向文件内容中写入内容
        /// </summary>
        public static void WriteToFile()
        {
            var writer = new FileWriteTest();
            writer.WriteArrayToFile(); // 写入一个数组到一个文件中【覆盖原内容】
            writer.WriteAllTextToFile();   // 写入一段文本到一个文件中【覆盖原内容】
            writer.WriteArrayToFileByStream();
            writer.AppendTextToFileByStream();
        }
        #endregion
    }
}
