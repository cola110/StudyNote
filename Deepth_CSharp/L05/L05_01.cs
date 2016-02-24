using Deepth_CSharp.L02;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepth_CSharp.L05
{
    public class L05_01
    {

        public void EnclosingMethod()
        {
            // int outerVariable = 5;
            string captureVariable = "captured";

            if (DateTime.Now.Hour == 13)
            {
                int normalLocalVariable = DateTime.Now.Minute;
                Console.WriteLine(normalLocalVariable);
            }

            Action action = delegate()
            {
                string anonLocal = "local to anonymous method";
                Console.WriteLine(captureVariable + anonLocal);
            };
            action();
        }

        public void ChangingMethod()
        {
            string captured = "before";

            Action x = delegate
            {
                Console.WriteLine(captured);
                captured = "changed by x";
            };

            captured = "current";
            x();

            Console.WriteLine(captured);

            captured = "after";
            x();
        }


        List<Person> FindAllYoungerThan(List<Person> people, int limit)
        {
            Predicate<Person> act = delegate(Person person)
            {
                return person.Age < limit;
            };

            return people.FindAll(act);
        }
    }
}
