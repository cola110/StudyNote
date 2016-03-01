using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonFunc.data_pattern
{
    public class Singleton1
    {
        static Singleton1 instance = null;

        Singleton1() { }

        public static Singleton1 Instance
        {
            get
            {
                if (Instance == null)
                {
                    instance = new Singleton1();
                }
                return instance;
            }
        }
    }

    public sealed class Singieton2
    {
        static Singieton2 instance = null;
        static readonly object padlock = new object();
        Singieton2() { }

        public static Singieton2 Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singieton2();
                    }
                    return instance;
                }
            }
        }
    }

    public sealed class Singleton3
    {
        static Singleton3 instance = null;
        static readonly object padlock = new object();

        Singleton3() { }

        public static Singleton3 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton3();
                        }
                    }
                }

                return instance;
            }
        }
    }

    public sealed class Singleton4
    {
        static Singleton4 instance = null;
    }

}
