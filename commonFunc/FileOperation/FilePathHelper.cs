/*
 *  Author：Ad
 *  Data：2015年12月25日 16:02:20
 *  Des：作为路径方法类，获取文件路径
 *  Title：get file path
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonFunc.FileOperation
{
    /// <summary>
    /// 文件路径帮助类
    /// </summary>
    public class FilePathHelper
    {
        #region 获取文件全名
        /// <summary>
        /// 获取文件全名
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static string GetRelationPath(string fileName)
        {
            // var path = System.Environment.CurrentDirectory;
            // Debug.WriteLine(path);
            // path = System.IO.Directory.GetCurrentDirectory();
            // Debug.WriteLine(path);
            //var path = AppDomain.CurrentDomain.BaseDirectory;

            //int lenth = path.IndexOf("bin", 11);
            //string rootPath = path.Substring(0, lenth);
            // E:\github\commonFunc\commonFunc\bin\Debug
            // Debug.WriteLine(rootPaths);
            // System.IO.File.WriteAllLines()

            var path = System.Environment.CurrentDirectory;
            int lenth = path.IndexOf("bin", 11);
            var filePath = path;
            if (lenth > 0)
            {
                filePath = path.Substring(0, lenth);
            }
            return filePath + fileName;
        }
        #endregion
    }
}
