using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonFunc.Formatter
{
    [Serializable]
    public class Person
    {
        private string name = "test string";
        private ArrayList favourites = new ArrayList();
        private double weight;

        public string height;

        [NonSerialized]
        public string birthday;

        public Person() { }

        public Person(ArrayList favourites)
        {
            this.favourites = favourites;
        }

        public string Name
        {
            get { return this.name; }
        }

        public ArrayList Favourites
        {
            get { return favourites; }
        }

        public void SetWeight(double weight)
        {
            this.weight = weight;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name:" + Name + "\n");
            builder.Append("Height:" + height + "\n");
            builder.Append("Birthday:" + birthday + "\n");
            builder.Append("Weight:" + weight + "\n");
            builder.Append("Favourites:");
            for (int i = 0; i < favourites.Count; i++)
            {
                builder.Append(favourites[i] + "\n");
            }
            return builder.ToString();
        }
    }
}
