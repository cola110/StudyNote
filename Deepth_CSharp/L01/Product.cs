using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepth_CSharp.L01
{
    public class Product
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        decimal price;
        public decimal Price
        {
            get { return this.price; }
            private set { this.price = value; }
        }

        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public static ArrayList GetSampleProduct()
        {
            ArrayList list = new ArrayList();
            list.Add(new Product("Apple", 11));
            list.Add(new Product("Banana", 13));
            list.Add(new Product("Egg", 8));
            list.Add(new Product("Orange", 10));

            return list;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", name, price);
        }
    }
}
