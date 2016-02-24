using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Deepth_CSharp.L01
{
    public class L01_2
    {
        public void ReadXml()
        {
            XDocument doc = XDocument.Load("E:\\github\\commonFunc\\Deepth_CSharp\\ProductData.xml");
            var filtered = from p in doc.Descendants("Product")
                           join s in doc.Descendants("Supplier")
                            on (int)p.Attribute("SupplierId")
                            equals (int)s.Attribute("SupplierId")
                           where (decimal)p.Attribute("Price") > 10
                           orderby (string)s.Attribute("Name"), (string)p.Attribute("name")
                           select new
                           {
                               SupplierName = (string)s.Attribute("Name"),
                               ProductName = (string)p.Attribute("Name")
                           };
            foreach (var item in filtered)
            {
                string message = string.Format("Suppler={0},Product={1}", item.SupplierName, item.ProductName);
                Trace.WriteLine(message);
            }
            
        }
    }
}
