using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepth_CSharp.L02
{
    class Person
    {
        string name;
        public Person(string name) { this.name = name; }

        public void Say(string message)
        {
            string str = string.Format("{0} say: {1}", name, message);
            Trace.WriteLine(str);
        }

        public int Age { get; set; }
    }

    class Backgroud
    {
        public static void Note(string note)
        {
            Trace.WriteLine(string.Format("({0})", note));
        }
    }

    public class L02_02
    {
        public static void maintest()
        {
            Person jon = new Person("Jon");
            Person tom = new Person("Tom");
            StringProcessor jonsVoice = new StringProcessor(jon.Say);
            StringProcessor tomsVoice = new StringProcessor(tom.Say);
            StringProcessor background = new StringProcessor(Backgroud.Note);
            StringProcessor temp = jon.Say;
            temp.Invoke("asdfasdfd");
            temp += jon.Say;

            temp = delegate
            {
                Console.WriteLine("tst");
            };
            // Func<int, int, string> fun = (x, y) => (x + y).ToString();
            Func<int, int, string> func = delegate(int x, int y)
            {
                return (x + y).ToString();
            };

            string msg = func(8, 9);

            Predicate<int> predicate = (e) => e > 0;
            // Action act = maintest;
            // Action<int> temp1 = (x) => (x + 100);
            // 有返回值、无返回值、返回bool
            Func<int, int, bool> boolFunc = delegate(int x, int y)
            {
                return x > y;
            };

            jonsVoice("tttt");
            tomsVoice("sssss");
            background.Invoke("this is test message");
        }
    }
}
