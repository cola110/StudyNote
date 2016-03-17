/*
 *  Author：Ad
 *  Data：2015年12月25日 16:03:53
 *  Des：功能测试主入口
 *  Title：main method class
 */

using commonFunc._gdi;
using commonFunc.ExDeal;
using commonFunc.FileOperation;
using commonFunc.Reflection;
using System;
using System.Diagnostics;
using System.Drawing;

namespace commonFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            // new FileOpMain().FileOpAction();    // 文件操作方法
            // IOSample.FileAndDirectoryOp();  // 目录操作方法
            // new ExceptionDeal().DevideAct();
            // new ReflectTest().TestReflect();
            // new HoverWarter().TestTextToImage();
            var rest = int.Parse("exit");
            Console.WriteLine(rest);
        }
    }
}
