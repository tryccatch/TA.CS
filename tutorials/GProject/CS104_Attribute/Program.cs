#define Wechat

using System;
using System.Diagnostics;

namespace CS104_Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main00();
            Main01();
        }

        static void Main00()
        {
            //OldFunc();
            Pay pay = new Pay();
            pay.AliPay();
            pay.WechatPay();
        }
        static void Main01()
        {
            Type t = Type.GetType("CS104_Attribute.Pay");
            Type my = Type.GetType("CS104_Attribute.MyAttribute");
            object[] objs = t.GetCustomAttributes(false);
            foreach (object item in objs)
            {
                if (item.GetType().Name == my.Name)
                {
                    if (item.GetType().GetProperty("Dec").GetValue(item) != null)
                    {
                        Console.WriteLine(item.GetType().GetProperty("Dec").GetValue(item));
                    }
                }
            }
        }

        #region Obsolete特性
        [Obsolete("Use NewFunc", true)]
        static void OldFunc()
        {
            Console.WriteLine("OldFunc");
        }

        static void NewFunc()
        {
            Console.WriteLine("NewFunc");
        }
        #endregion
    }

    [My("支付类")]
    [My("支付类s")]
    [My]
    [Obsolete]
    class Pay
    {
        public int price;

        /// <summary>
        /// 条件特性
        /// </summary>
        [Conditional("Ali")]
        public void AliPay()
        {
            Console.WriteLine("Ali");
        }

        [Conditional("Wechat")]
        public void WechatPay()
        {
            Console.WriteLine("Wechat");
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class MyAttribute : Attribute
    {
        private string dec;

        public MyAttribute(string dec_in)
        {
            this.dec = dec_in;
        }

        public MyAttribute()
        {

        }

        public string Dec
        {
            get
            {
                return this.dec;
            }
        }
    }
}

#region notes
/*
C#高级-特性
    特性就是为了支持对象添加一些自我描述的信息，不影响类封装的前提添加额外信息。

声明特性
        [attribute(positional_parameters, name_parameter = value, ...)]
        element
    特性（Attribute）的名称和值是在方括号内规定的，放置在它所应用的元素之前。
    positional_parameters 规定必需的信息，name_parameter 规定可选的信息。

预定义特性
    .Net 框架提供了三种预定义特性：
        AttributeUsage
        Conditional
        Obsolete

AttributeUsage
    预定义特性 AttributeUsage 描述了如何使用一个自定义特性类。它规定了特性可应用到的项目的类型。
    
Conditional
    这个预定义特性标记了一个条件方法，其执行依赖于指定的预处理标识符。
        [Conditional(conditionalSymbol)]
    conditionalSymbol 为预编译条件，需要在文件开头加上 #define conditionalSymbol 作为标记

Obsolete
    这个预定义特性标记了不应被使用的程序实体。它可以让您通知编译器丢弃某个特定的目标元素。例如，当一个新方法被用在一个类中，但是您仍然想要保持类中的旧方法，您可以通过显示一个应该使用新方法，而不是旧方法的消息，来把它标记为obsolete（过时的）。
        [Obsolete(message)]
        [Obsolete(message, iserror)]
    参数 message，是一个字符串，描述项目为什么过时以及该替代使用什么。参数 iserror，是一个布尔值。如果该值为 true，编译器应把该项目的使用当作一个错误。默认值是 false（编译器生成一个警告）。
*/
#endregion