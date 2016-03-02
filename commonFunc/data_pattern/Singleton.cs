using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 第1章 单件模式（Single Pattern） */
namespace commonFunc.data_pattern
{
    public class Singleton1
    {
        /*
         这种方式的实现对于线程来说并不是安全的，因为在多线程的环境下有可能得到Singleton类的多个实例。如果同时有两个线程去判断（instance == null），并且得到的结果为真，这时两个线程都会创建类Singleton的实例，这样就违背了Singleton模式的原则。实际上在上述代码中，有可能在计算出表达式的值之前，对象实例已经被创建，但是内存模型并不能保证对象实例在第二个线程创建之前被发现。

 

        该实现方式主要有两个优点：
            由于实例是在 Instance 属性方法内部创建的，因此类可以使用附加功能（例如，对子类进行实例化），即使它可能引入不想要的依赖性。
            直到对象要求产生一个实例才执行实例化；这种方法称为“惰性实例化”。惰性实例化避免了在应用程序启动时实例化不必要的 singleton。
         */
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

    /// <summary>
    /// 这种方式的实现对于线程来说是安全的。我们首先创建了一个进程辅助对象，线程在进入时先对辅助对象加锁然后再检测对象是否被创建，这样可以确保只有一个实例被创建，因为在同一个时刻加了锁的那部分程序只有一个线程可以进入。这种情况下，对象实例由最先进入的那个线程创建，后来的线程在进入时（instence == null）为假，不会再去创建对象实例了。但是这种实现方式增加了额外的开销，损失了性能。
    /// </summary>
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

    /*
     这种实现方式对多线程来说是安全的，同时线程不是每次都加锁，只有判断对象实例没有被创建时它才加锁，有了我们上面第一部分的里面的分析，我们知道，加锁后还得再进行对象是否已被创建的判断。它解决了线程并发问题，同时避免在每个 Instance 属性方法的调用中都出现独占锁定。它还允许您将实例化延迟到第一次访问对象时发生。实际上，应用程序很少需要这种类型的实现。大多数情况下我们会用静态初始化。这种方式仍然有很多缺点：无法实现延迟初始化。
     */
    /// <summary>
    /// 
    /// </summary>
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

    /*
       该实现与前面的示例类似，不同之处在于它依赖公共语言运行库来初始化变量。它仍然可以用来解决 Singleton 模式试图解决的两个基本问题：全局访问和实例化控制。公共静态属性为访问实例提供了一个全局访问点。此外，由于构造函数是私有的，因此不能在类本身以外实例化 Singleton 类；因此，变量引用的是可以在系统中存在的唯一的实例。
       由于 Singleton 实例被私有静态成员变量引用，因此在类首次被对 Instance 属性的调用所引用之前，不会发生实例化。
       这种方法唯一的潜在缺点是，您对实例化机制的控制权较少。在 Design Patterns 形式中，您能够在实例化之前使用非默认的构造函数或执行其他任务。由于在此解决方案中由 .NET Framework 负责执行初始化，因此您没有这些选项。在大多数情况下，静态初始化是在 .NET 中实现 Singleton 的首选方法。
     */
    /// <summary>
    /// 在此实现中，将在第一次引用类的任何成员时创建实例。公共语言运行库负责处理变量初始化。该类标记为 sealed 以阻止发生派生，而派生可能会增加实例。此外，变量标记为 readonly，这意味着只能在静态初始化期间（此处显示的示例）或在类构造函数中分配变量。
    /// </summary>
    public sealed class Singleton4
    {
        private static readonly Singleton4 instance = new Singleton4();

        static Singleton4()
        {
        }

        public static Singleton4 Instance
        {
            get
            {
                return instance;
            }
        }
    }

    /// <summary>
    /// 这里，初始化工作有Nested类的一个静态成员来完成，这样就实现了延迟初始化，并具有很多的优势，是值得推荐的一种实
    /// </summary>
    public sealed class Singleton5
    {
        Singleton5()
        {
        }

        public static Singleton5 Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            static Nested()
            {
            }

            internal static readonly Singleton5 instance = new Singleton5();
        }
    }


    /*
     优点:
    实例控制：Singleton 会阻止其他对象实例化其自己的 Singleton 对象的副本，从而确保所有对象都访问唯一实例
    灵活性：因为类控制了实例化过程，所以类可以更加灵活修改实例化过程

    缺点:
    开销：虽然数量很少，但如果每次对象请求引用时都要检查是否存在类的实例，将仍然需要一些开销。可以通过使用静态初始化解决此问题，上面的五种实现方式中已经说过了。
    可能的开发混淆：使用 singleton 对象（尤其在类库中定义的对象）时，开发人员必须记住自己不能使用 new 关键字实例化对象。因为可能无法访问库源代码，因此应用程序开发人员可能会意外发现自己无法直接实例化此类。
    对象的生存期：Singleton 不能解决删除单个对象的问题。在提供内存管理的语言中（例如基于 .NET Framework 的语言），只有 Singleton 类能够导致实例被取消分配，因为它包含对该实例的私有引用。在某些语言中（如 C++），其他类可以删除 
对象实例，但这样会导致 Singleton 类中出现悬浮引用。

    适用性:
    当类只能有一个实例而且客户可以从一个众所周知的访问点访问它时。
    当这个唯一实例应该是通过子类化可扩展的，并且客户应该无需更改代码就能使用一个扩展的实例时。

    应用场景:
    每台计算机可以有若干个打印机，但只能有一个Printer Spooler，避免两个打印作业同时输出到打印机。 
（摘自吕震宇的C#设计模式（7）－Singleton Pattern）
    PC机中可能有几个串口，但只能有一个COM1口的实例。
    系统中只能有一个窗口管理器。
    .NET Remoting中服务器激活对象中的Sigleton对象，确保所有的客户程序的请求都只有一个实例来处理。
     */
}
