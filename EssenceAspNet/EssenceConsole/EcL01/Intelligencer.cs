using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;
using System.Web.Hosting;

namespace EssenceConsole.EcL01
{
    public class Intelligencer : System.MarshalByRefObject
    {


        public string Report()
        {
            System.AppDomain domain = System.AppDomain.CurrentDomain;
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Domain ID: {0}\r\n", domain.Id);


            builder.AppendFormat("VirtualPath:{0}\r\n", HostingEnvironment.ApplicationVirtualPath);
            builder.AppendFormat("PhysicalPath:{0}\r\n", HostingEnvironment.ApplicationPhysicalPath);


            return builder.ToString();
        }
    }
}
