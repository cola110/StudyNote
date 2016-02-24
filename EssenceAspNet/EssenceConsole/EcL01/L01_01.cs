using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssenceConsole.EcL01
{
    public class L01_01
    {
        public void TestInfo()
        {
            System.Uri ms = new Uri("http://www.cnblogs.com/kklldog/p/helios_chat_room.html");

            Trace.WriteLine(string.Format("Scheme:{0}", ms.Scheme));
            Trace.WriteLine(string.Format("Host:{0}", ms.Host));
            Trace.WriteLine(string.Format("Port:{0}", ms.Port));
            Trace.WriteLine(string.Format("AbsolutePath:{0}", ms.AbsolutePath));
            Trace.WriteLine(string.Format("Query:{0}", ms.Query));

        }
    }
}
