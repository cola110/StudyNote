using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 第2章 抽象工厂模式（Abstract Factory） */
namespace commonFunc.data_pattern
{
    public abstract class Bonus
    {
        public abstract double Calulate();
    }

    public abstract class Tax
    {
        public abstract double Calulate();
    }

    // Chinese 
    namespace ChineseSalay
    {
        public class Constant
        {
            public static double BASE_SALARY = 4000;
        }

        public class ChineseBonus : Bonus
        {
            public double Calulate()
            {
                return Constant.BASE_SALARY * 0.1;
            }
        }

        public class ChineseTax : Tax
        {
            public double Calulate()
            {
                return (Constant.BASE_SALARY + (Constant.BASE_SALARY * 0.1)) * 0.4;
            }
        }
    }

    // American
    namespace AmericanSalay
    {
        public class Constant
        {
            public static double BASE_SALARY = 4000;
        }

        public class AmericanBonus : Bonus
        {
            public double Calulate()
            {
                return Constant.BASE_SALARY * 0.1;
            }
        }

        public class AmericanTax : Tax
        {
            public double Calulate()
            {
                return (Constant.BASE_SALARY + (Constant.BASE_SALARY * 0.1)) * 0.4;
            }
        }
    }

    //namespace FactorySalary
    //{
    //    using commonFunc.data_pattern.ChineseSalay;
    //    using commonFunc.data_pattern.AmericanSalay;
    //    public class Factory
    //    {
    //        public Tax CreateTax()
    //        {
    //            return new ChineseTax();
    //        }

    //        public Bonus CreateBonus()
    //        {
    //            return new ChineseBonus();
    //        }
    //    }
    //}

    namespace AbstractFactory
    {
        using commonFunc.data_pattern.AmericanSalay;
        using commonFunc.data_pattern.ChineseSalay;
        using System.Configuration;
        using System.Reflection;
        public class ChineseFactory : AbstractFactory
        {
            public Tax CreateTax()
            {
                return new ChineseTax();
            }

            public Bonus CreateBonus()
            {
                return new ChineseBonus();
            }
        }

        public class AmericanFactory : AbstractFactory
        {
            public Tax CreateTax()
            {
                return new AmericanTax();
            }

            public Bonus CreateBonus()
            {
                return new AmericanBonus();
            }
        }

        public abstract class AbstractFactory
        {
            public static AbstractFactory GetInstance()
            {
                string factoryName = ConfigurationSettings.AppSettings["factoryName"].ToString();
                AbstractFactory instance;
                //if (factoryName == "ChineseFactory")
                //{
                //    instance = new ChineseFactory();
                //}
                //else if (factoryName == "AmericanFactory")
                //{
                //    instance = new AmericanFactory();
                //}
                //else
                //{
                //    instance = null;
                //}

                if (!string.IsNullOrEmpty(factoryName))
                {
                    instance = (AbstractFactory)Assembly.Load(factoryName).CreateInstance(factoryName);
                }
                else
                {
                    instance = null;
                }
                return instance;
            }

            public abstract Tax CreateTax();
            public abstract Bonus CreateBonus();
        }
    }

    namespace InterfaceSalary
    {
        using commonFunc.data_pattern.ChineseSalay;
        using commonFunc.data_pattern.AmericanSalay;
        public class Calulater
        {
            public static void main(string[] args)
            {
                Bonus bonus = new ChineseBonus();
                double bonusValue = bonus.Calulate();

                Tax tax = new ChineseTax();
                double taxValue = tax.Calulate();
            }
        }
    }

}



/*
 * http://terrylee.cnblogs.com/archive/2005/12/13/295965.html
 Softo系统的实际开发的分工可能是一个团队专门做业务规则，另一个团队专门做前端的业务规则组装。 抽象工厂模式有助于这样的团队的分工: 两个团队通讯的约定是业务接口，由抽象工厂作为纽带粘合业务规则和前段调用，大大降低了模块间的耦合性，提高了团队开发效率。

完完全全地理解抽象工厂模式的意义非常重大，可以说对它的理解是你对OOP理解上升到一个新的里程碑的重要标志。 学会了用抽象工厂模式编写框架类，你将理解OOP的精华:面向接口编程.。

应对“新对象”

抽象工厂模式主要在于应对“新系列”的需求变化。其缺点在于难于应付“新对象”的需求变动。如果在开发中出现了新对象，该如何去解决呢？这个问题并没有一个好的答案，下面我们看一下李建忠老师的回答：

“GOF《设计模式》中提出过一种解决方法，即给创建对象的操作增加参数，但这种做法并不能令人满意。事实上，对于新系列加新对象，就我所知，目前还没有完美的做法，只有一些演化的思路，这种变化实在是太剧烈了，因为系统对于新的对象是完全陌生的。”

实现要点

l         抽象工厂将产品对象的创建延迟到它的具体工厂的子类。

l         如果没有应对“多系列对象创建”的需求变化，则没有必要使用抽象工厂模式，这时候使用简单的静态工厂完全可以。

l         系列对象指的是这些对象之间有相互依赖、或作用的关系，例如游戏开发场景中的“道路”与“房屋”的依赖，“道路”与“地道”的依赖。

l         抽象工厂模式经常和工厂方法模式共同组合来应对“对象创建”的需求变化。

l         通常在运行时刻创建一个具体工厂类的实例，这一具体工厂的创建具有特定实现的产品对象，为创建不同的产品对象，客户应使用不同的具体工厂。

l         把工厂作为单件，一个应用中一般每个产品系列只需一个具体工厂的实例，因此，工厂通常最好实现为一个单件模式。

l         创建产品，抽象工厂仅声明一个创建产品的接口，真正创建产品是由具体产品类创建的，最通常的一个办法是为每一个产品定义一个工厂方法，一个具体的工厂将为每个产品重定义该工厂方法以指定产品，虽然这样的实现很简单，但它确要求每个产品系列都要有一个新的具体工厂子类，即使这些产品系列的差别很小。

优点

l         分离了具体的类。抽象工厂模式帮助你控制一个应用创建的对象的类，因为一个工厂封装创建产品对象的责任和过程。它将客户和类的实现分离，客户通过他们的抽象接口操纵实例，产品的类名也在具体工厂的实现中被分离，它们不出现在客户代码中。

l         它使得易于交换产品系列。一个具体工厂类在一个应用中仅出现一次——即在它初始化的时候。这使得改变一个应用的具体工厂变得很容易。它只需改变具体的工厂即可使用不同的产品配置，这是因为一个抽象工厂创建了一个完整的产品系列，所以整个产品系列会立刻改变。

l         它有利于产品的一致性。当一个系列的产品对象被设计成一起工作时，一个应用一次只能使用同一个系列中的对象，这一点很重要，而抽象工厂很容易实现这一点。

缺点

l         难以支持新种类的产品。难以扩展抽象工厂以生产新种类的产品。这是因为抽象工厂几口确定了可以被创建的产品集合，支持新种类的产品就需要扩展该工厂接口，这将涉及抽象工厂类及其所有子类的改变。

适用性

在以下情况下应当考虑使用抽象工厂模式：

l         一个系统不应当依赖于产品类实例如何被创建、组合和表达的细节，这对于所有形态的工厂模式都是重要的。

l         这个系统有多于一个的产品族，而系统只消费其中某一产品族。

l         同属于同一个产品族的产品是在一起使用的，这一约束必须在系统的设计中体现出来。

l         系统提供一个产品类的库，所有的产品以同样的接口出现，从而使客户端不依赖于实现。

应用场景

l         支持多种观感标准的用户界面工具箱（Kit）。

l         游戏开发中的多风格系列场景，比如道路，房屋，管道等。

l         ……

总结

总之，抽象工厂模式提供了一个创建一系列相关或相互依赖对象的接口，运用抽象工厂模式的关键点在于应对“多系列对象创建”的需求变化。一句话，学会了抽象工厂模式，你将理解OOP的精华：面向接口编程。
 */