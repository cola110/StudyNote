using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepth_CSharp.L02
{
    public class L02_01
    {
        /*
         * delegate
         * 声明委托。
         * 委托的实例
         * 方法执行的代码
         * 调用委托实例
         */
        void TestDeletgate()
        {
            // StringProcessor proc1, proc2;


            StringProcessor process = new StringProcessor(PrintString);
            process.Invoke("");
            // process.
        }


        static void PrintString(string str)
        {
            Trace.WriteLine(str);
        }
    }
}
