using System;

namespace CS101_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal fish = new Fish();

            //接口的实例,由实现该接口的类来进行实例化
            IFeet birdFeet = new Bird();

            Dog dog = new Dog();


            TV tv = new TV();

            ISwitch switchTV = new TV();
            switchTV.Power_On();

            IRemote remoteTV = new TV();
            remoteTV.Power_On();


            IOperation sub = Factory.Choose("-");
            sub.NumberA = 5;
            sub.NumberB = 3;
            Console.WriteLine(sub.GetResult());
        }
    }

    #region 工厂
    class Factory
    {
        public static IOperation Choose(string symbol)
        {
            IOperation oper = null;
            switch (symbol)
            {
                case "+":
                    oper = new Add();
                    break;
                case "-":
                    oper = new Sub();
                    break;
                default:
                    break;
            }
            return oper;
        }
    }

    interface IOperation
    {
        int NumberA { get; set; }
        int NumberB { get; set; }
        int GetResult();
    }

    class Add : IOperation
    {
        public int NumberA { get; set; }
        public int NumberB { get; set; }

        public int GetResult()
        {
            return NumberA + NumberB;
        }
    }
    class Sub : IOperation
    {
        public int NumberA { get; set; }
        public int NumberB { get; set; }

        public int GetResult()
        {
            return NumberA - NumberB;
        }
    }
    #endregion

    #region 接口概念解释(隐式实现与调用)
    interface IMouth
    {
        int Size
        {
            get; set;
        }
    }
    interface IFeet
    {
        void Run();
        void Jump();
    }
    abstract class Animal
    {
        public int age;
        public int Class;   //科属
    }

    class Dog : Animal
    {
        public Dog()
        {
            Console.WriteLine("Dog");
        }
    }
    class Fish : Animal, IFeet, IMouth
    {
        public int Size
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Jump()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
    class Bird : IFeet, IMouth
    {
        public int Size { get; set; }

        public void Jump()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine("我有腿啦");
        }
    }
    #endregion

    #region 显式实现与调用
    interface ISwitch   //电源开关
    {
        void Power_On();    //开机
        void Power_Off();   //关机
    }
    interface IRemote   //远程开关
    {
        void Power_On();
        void Power_Off();
    }
    class TV : ISwitch, IRemote
    {
        void ISwitch.Power_Off()
        {
            Console.WriteLine("直接关机");
        }

        void IRemote.Power_Off()
        {
            Console.WriteLine("远程关机");
        }

        void ISwitch.Power_On()
        {
            Console.WriteLine("直接开机");
        }

        void IRemote.Power_On()
        {
            Console.WriteLine("远程开机");
        }
    }
    #endregion
}

#region notes
/*
C#高级-接口（Interface）
    接口是某一种行为的规范

接口概述
    接口类似于只有抽象成员的抽象基类。 实现接口的任何类或结构都必须实现其所有成员。
    接口无法直接进行实例化。 其成员由实现接口的任何类或结构来实现。
    接口可以包含事件、索引器、方法和属性。
    接口不包含方法的实现。
    一个类或结构可以实现多个接口。 一个类可以继承一个基类，还可实现一个或多个接口。

接口的特点
    通过接口可以实现多重继承，C# 接口的成员不能有 public、protected、internal、private 等修饰符。原因很简单，接口里面的方法都需要由外面接口实现去现方法体，那么其修饰符必然是 public。C# 接口中的成员默认是 public。
    接口成员不能有 new、static、abstract、override、virtual 修饰符。
    接口没有构造函数，所以不能直接使用 new 对接口进行实例化。接口中只能包含方法、属性、事件和索引的组合。接口一旦被实现，实现类必须实现接口中的所有成员，除非实现类本身是抽象类。
    C# 是单继承，接口是解决 C# 里面类可以同时继承多个基类的问题。

接口声明
    public interface IDoSomething
    {
        void DoSomething();
    }

实现接口与调用
    隐式实现与调用
        class Program : IDoSomething
        {
            public void DoSomething()
            {
                throw new NotImplementedException();
            }
        }
    显式实现与调用
        class Program : IDoSomething
        {
            void IDoSomething.DoSomething()
            {
                throw new NotImplementedException();
            }
        }
        
    隐示实现对象声明为接口和类都可以访问到其行为，显示实现只有声明为接口可以访问。
    如果两个接口中有相同的方法名，那么同时实现这两个接口的类，就会出现不确定的情形，在编写方法时，也不知道实现哪个接口的方法了。为解决这一问题，C#提供了显示接口实现技术，就是在方法名前加接口名称，用接口名称来限定成员。用“接口名.方法名()”来区分实现的是哪一个接口。
    注意：显示接口实现时，在方法名前不能加任何访问修饰符。显式接口实现时方法前不加任何修饰符，默认为私有的，如果前面加上修饰符，会出现编译错误。
    调用显示接口实现的正确方式是通过接口引用，通过接口引用来确定要调用的版本。

接口和抽象的区别
    接口用于规范，抽象类用于共性。抽象类是类，所以只能被单继承，但是接口却可以一次实现多个。
    接口中只能声明方法，属性，事件，索引器。而抽象类中可以有方法的实现，也可以定义非静态的类变量。抽象类可以提供某些方法的部分实现，接口不可以。
    抽象类的实例是它的子类给出的。接口的实例是实现接口的类给出的。
    在抽象类中加入一个方法，那么它的子类就同时有了这个方法。而在接口中加入新的方法，那么实现它的类就要重新编写（这就是为什么说接口是一个类的规范了）。
    接口成员被定义为公共的，但抽象类的成员也可以是私有的、受保护的、内部的或受保护的内部成员（其中受保护的内部成员只能在应用程序的代码或派生类中访问）。
    接口不能包含字段、构造函数、析构函数、静态成员或常量。 
*/
#endregion