using System;
using System.Collections.Generic;

namespace CS103_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main00();
            //Main01();
            //Main02();
            //Main03();
            //Main04();
            //Main05();
            //Main06();
            Main07();
        }

        /// <summary>
        /// 委托的概念解释
        /// </summary>
        static void Main00()
        {
            //实例化一个委托对象
            TestDelegate test1 = new TestDelegate(Test1);
            //使用委托中的invoke函数可以调用方法
            test1.Invoke();
            //将委托对象当成方法也可以调用
            test1();

            TestDelegate test2 = new TestDelegate(Test2);
            test2();
        }

        /// <summary>
        /// 委托的四种写法
        /// </summary>
        static void Main01()
        {
            //第一种写法  类型创建
            TestDelegate back = new TestDelegate(Back);
            Call(back);

            //第二种写法 简写
            TestDelegate test1 = Test1;
            test1();

            //第三种写法：匿名方法
            TestDelegate test2 = delegate ()
            {
                Console.WriteLine("Test2");
            };
            test2();

            //第四种写法：Lambda表达式，匿名方法的简写
            TestDelegate test3 = () => { Console.WriteLine("Test3"); };
            test3();
        }

        /// <summary>
        /// 有参数和返回值的委托
        /// </summary>
        static void Main02()
        {
            TestHandler test = Test3;
            Console.WriteLine(test(2, "33"));
        }

        /// <summary>
        /// 利用委托设计英雄和技能关系
        /// </summary>
        static void Main03()
        {
            Hero yasuo = new Hero();
            yasuo.Q = SkillPools.Hasaki;

            yasuo.Q();

            Hero wuyifan = new Hero();
            wuyifan.R = SkillPools.Qinghuiyening;
        }

        /// <summary>
        /// Lambda表达式的应用
        /// </summary>
        static void Main04()
        {
            Enemy e1 = new Enemy(1, 4);
            Enemy e2 = new Enemy(3, 1);
            Enemy e3 = new Enemy(2, 2);
            Enemy e4 = new Enemy(8, 6);
            Enemy e5 = new Enemy(7, 2);

            List<Enemy> list = new List<Enemy>() { e1, e2, e3, e4, e5 };

            //list.Sort(Compara);
            list.Sort((x, y) => { return x.hp - y.hp; });

            foreach (var enemy in list)
            {
                Console.WriteLine("hp:" + enemy.hp + "\tatk" + enemy.atk);
            }
        }

        /// <summary>
        /// Action和Func委托
        /// </summary>
        static void Main05()
        {
            Action test1 = Test1;
            test1();

            Action<string> test2 = Test4;
            test2("123123");

            Action<string, int> test3 = Test5;
            test3("222", 4444);

            Func<int, string, string> func = Test3;
            Console.WriteLine(func(111, "222"));
        }

        /// <summary>
        /// 多播委托
        /// </summary>
        static void Main06()
        {
            Action action = Test1;
            action += Test2;
            action -= Test1;
            action -= Test2;    //此时委托链中没有引用对象，相当于Action action = null;
            action();
        }

        /// <summary>
        /// 事件、观察者模式
        /// </summary>
        static void Main07()
        {
            Cat cat = new Cat();
            Mouse mouse = new Mouse();

            cat.OnCatCry += mouse.Run;

            cat.Cry();
            //cat.OnCatCry();

            Enemy enemy = new Enemy(2, 9);
            Player player = new Player();
            LifeBar lifeBar = new LifeBar();

            enemy.OnEnemyAtk += player.Injured;
            player.OnPlayerInjured += lifeBar.Changed;

            enemy.Atk();
        }

        static int Compara(Enemy x, Enemy y)
        {
            return x.hp - y.hp;
        }

        public static void Call(TestDelegate back)
        {
            Console.WriteLine("Call");
            back();
        }
        public static void Back()
        {
            Console.WriteLine("Back");
        }
        public static void Test1()
        {
            Console.WriteLine("Test1");
        }
        public static void Test2()
        {
            Console.WriteLine("Test2");
        }
        public delegate void TestDelegate();    //该委托代表了没有参数组成的，没有返回值的一类方法

        public static string Test3(int a, string b)
        {
            return a.ToString();
        }
        public static void Test4(string a)
        {
            Console.WriteLine(a);
        }
        public static void Test5(string a, int b)
        {
            Console.WriteLine(b);
        }
        public delegate string TestHandler(int a, string b);
    }

    /*
     * 英雄和技能应该互相剥离
     * 英雄负责实例化模型，皮肤等表现
     * 技能应该在英雄被实例化时注册进该实例里
     */
    //public abstract class Hero
    //{
    //    public abstract void SkillQ();
    //    public abstract void SkillD();
    //    public abstract void SkiilE();
    //}
    public delegate void SkillDele();

    public class Hero
    {
        //public GameObject fbx;
        //public Texture pifu;
        public SkillDele Q;
        public SkillDele W;
        public SkillDele E;
        public SkillDele R;
    }
    public class SkillPools
    {
        public static void Hasaki()
        {
            Console.WriteLine("Hasaki");
        }
        public static void Qinghuiyening()
        {
            Console.WriteLine("Qinghuiyening");
        }
        public static void Zhongmogu()
        {
            Console.WriteLine("Zhongmogu");
        }
    }
    public class Enemy
    {
        public int hp;
        public int atk;

        public Enemy(int hp, int atk)
        {
            this.hp = hp;
            this.atk = atk;
        }

        public event Action<float> OnEnemyAtk;
        public void Atk()
        {
            Console.WriteLine("怪物开始攻击");
            OnEnemyAtk(this.atk);
        }
    }
    public class Player
    {
        public event Action<float> OnPlayerInjured;
        public void Injured(float value)
        {
            Console.WriteLine("角色受到攻击");

            OnPlayerInjured(value);
        }
    }

    public class LifeBar
    {
        public void Changed(float value)
        {
            Console.WriteLine("角色血条减少" + value);
        }
    }
    public class Mouse
    {
        public void Run()
        {
            Console.WriteLine("Run");
        }
    }
    public class Cat
    {
        public event Action OnCatCry;
        public void Cry()
        {
            Console.WriteLine("Miao");

            OnCatCry();
        }
    }
}

#region notes
/*
C#高级-委托
    委托可以把方法当做参数来传递，委托是一个类型，这个类型可以赋值一个方法的引用。

声明委托
    在C#中使用一个委托，首先我们要定义委托，告诉编辑器委托可以指向哪些类型的方法，然后创建该委托的实例。
    定义委托的语法如下：
        delegate void Calculate(int x, int y);
    我们定义了一个委托叫做Calculate，这个委托指向的方法要带有一个int类型的参数，并1且方法的返回值是void。
    定义一个委托要定义方法的参数和返回值，使用关键字delegate定义。

Action委托和Func委托
    Action 与 Func是.NET类库中增加的内置委托，以便更加简洁方便的使用委托。
    Action委托引用来一个void返回类型的方法，T表示方法参数
        Action<T1>
        Action<T1, T2>
        Action<T1, T3, T3>
        Action<T1, T3, T3,...T16>
    Func引用来一个带有返回值的方法，它可以传递0个或者最多16个参数类型，和一个返回类型
        Func <out TResult >
        Func <T1, out TResult >
        Func <T1, T2, out TResult>
        Func <T1, T2,...T16, out TResult>

匿名方法
    匿名方法（Anonymous methods） 提供了一种传递代码块作为委托参数的技术。 匿名方法是没有名称只有主体的方法。 在匿名方法中您不需要指定返回类型，它是从方法主匿名方法体内的 return 语句推断的。
        delegate void NumbemChanger(int n);
        ...
        NumbemChanger nc = delegate (int x)
        {
            Console.WriteLine("Anonymous Method:{0}", x);
        };

Lambda表达式
    Lambda表达式可用来代替匿名方法，所有Lambda表达式的本质也是定义的一个方法 。
    Lambda表达式的参数不需要声明类型。
        Action<string> action = new Action<string>((x) => { });
*/

/*
C#高级-事件
    事件基于委托，为委托提供来一个发布/订阅的机制，事件是一种具有特殊签名的委托。
    
声明事件
    事件使用 event 关键字来声明，他的返回值是一个委托类型。
        public event 委托 事件名 
    通常事件的命名，以名字 +Event ，实际项目中尽量命名规范，增加可读性。

事件与委托的区别
        委托      事件      区别
         是       否        是否可以使用=来赋值    
         是       否        是否可以在类外部调用   
         是       否        是否是一个类型        
    事件是一种特殊的委托，或者说是受限制的委托，是委托的一种特殊的应用，只能施加+=或‐=操作符，本质是一个东西事件只允许使用+=或‐=操作符，这导致来它不允许在类的外部直接触发，只能在类的内部触发使用中，委托常用来表达回调，事件表达外发的接口。
*/
#endregion