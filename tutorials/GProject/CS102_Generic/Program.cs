using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CS102_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main00();
            //Main01();
            //Main02();
            Main03();
        }

        static void Main00()
        {
            /*
            Print("hhhhhh");
            Print(111);
            PrintObj(22.22 + "123");
            PrintT<int>(555);
            PrintT<string>("666");

            ArrayList al = new ArrayList() { };
            al.Add(111);
            al.Add(11.111);
            al.Add("11111");
            //*/
            /*
             * ArrayList和List是等效类
             * ArrayList组成元素是object  List是泛型T
             * ArrayList存在装箱问题，性能开销比Liat大
             */

            long intTime;
            long objTime;
            long genericTime;
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < 1000000; i++)
                {
                    Print(11);
                }
                sw.Stop();
                intTime = sw.ElapsedMilliseconds;
                Console.WriteLine(intTime);
            }
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < 1000000; i++)
                {
                    PrintObj(11);
                }
                sw.Stop();
                objTime = sw.ElapsedMilliseconds;
                Console.WriteLine(objTime);
            }
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < 1000000; i++)
                {
                    PrintT<int>(11);
                }
                sw.Stop();
                genericTime = sw.ElapsedMilliseconds;
                Console.WriteLine(genericTime);
            }
        }
        static void Main01()
        {
            int[] numbers = new int[] { 1, 3, 2, 8 };

            List<int> list = new List<int>(numbers);
            MyList<int> mylist = new MyList<int>(numbers);

            int a = list[2];
            int b = mylist[2];

            list[3] = 6;
            mylist[3] = 6;

            int listCount = list.Count;
            int myListCount = mylist.Count;

            int index = list.IndexOf(3);
            Console.WriteLine(mylist.IndexOf(7));

            mylist.Add(8);

            mylist.RemoveAt(4);

            list.Sort();
            mylist.Sort();
        }
        static void Main02()
        {
            Enemy e1 = new Enemy(1, 4);
            Enemy e2 = new Enemy(2, 1);
            Enemy e3 = new Enemy(4, 2);
            Enemy e4 = new Enemy(5, 6);
            Enemy e5 = new Enemy(7, 2);

            Enemy[] es = new Enemy[] { e1, e2, e3, e4, e5 };

            List<Enemy> enemies = new List<Enemy>();
            MyList<Enemy> myList = new MyList<Enemy>(es);
            myList.Sort();
        }
        static void Main03()
        {
            Player.Instance.TestFunc();
            Player.Instance.TestFunc();
            PlayerData.Instance.TestFunc();
        }

        #region 泛型概念解释
        //方法的重载实现多类型的打印
        static void Print(string content)
        {

        }
        static void Print(int content)
        {

        }
        static void Print(float content)
        {

        }

        /// <summary>
        /// 使用基类object来实现多类型打印(装箱)
        /// </summary>
        /// <param name="content"></param>
        static void PrintObj(object content)
        {

        }
        static void PrintT<T>(T content)
        {

        }

        void TestFunc<T, U, i>() { }
        #endregion
    }

    class MyList<T> where T : IComparable, IComparable<T>
    {
        T[] array = new T[0];
        public MyList()
        {

        }
        public MyList(T[] array)
        {
            this.array = array;
        }
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return array.Length;
            }
        }

        /// <summary>
        /// 传入一个T 返回T在List中的索引
        /// </summary>
        /// <param name="item">List的元素，可以为null</param>
        /// <returns>如果找到，则为整个list中第一个匹配的索引，如果没找到，则返回-1</returns>
        public int IndexOf(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Add(T item)
        {
            //新建一个比array长1的数组temp[]
            T[] temp = new T[Count + 1];
            //把array的所有值赋给temp
            Array.Copy(array, temp, Count);
            //temp[]的最后一位 = item
            temp[Count] = item;
            //把temp[]给array
            array = temp;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                //把index位开始的元素都往前挪一位
                for (int i = index; i < Count - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                //创建一个新数组，长度是array的长度 -1
                T[] temp = new T[Count - 1];
                Array.Copy(array, temp, Count - 1);
                array = temp;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (array[i].CompareTo(array[j]) < 0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
    #region 泛型类和泛型接口
    class People<T>
    {

    }
    interface IFeet<T>
    {

    }
    #endregion

    public class Enemy : IComparable, IComparable<Enemy>
    {
        public int hp;
        public int atk;

        public Enemy(int hp, int atk)
        {
            this.hp = hp;
            this.atk = atk;
        }

        public int CompareTo(object obj)
        {
            Enemy e = obj as Enemy;
            //if (this.atk > e.atk)
            //{
            //    return 1;
            //}else if(this.atk < e.atk)
            //{
            //    return -1;
            //}
            //else
            //{
            //    return 0;
            //}
            return this.atk - e.atk;
        }

        public int CompareTo(Enemy other)
        {
            return this.hp - other.hp;
        }
    }

    public class Singleton<T> where T : new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }
    }
    public class PlayerData : Singleton<PlayerData>
    {
        public void TestFunc()
        {
            Console.WriteLine("PlayerData");
        }
    }
    public class Player
    {
        //整个项目或场景有且只有一个该类的实例对象
        //外部不能new 该对象 (构造函数私有化)
        //对外部提供一个方法或属性 能返回该类的单一实例
        private Player()
        {
            Console.WriteLine("私有构造函数被调用");
        }

        private static Player instance;

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }
        public void TestFunc()
        {
            Console.WriteLine("TestFunc");
        }
    }
}

#region notes
/*
C#高级-泛型
    在客户端代码声明并初始化这些类和方法之前，这些类和方法会延迟指定一个或多个类型使用泛型类型可以最大限度地重用代码、保护类型安全性以及提高性能。
泛型概述
    泛型最常见的用途是创建集合类。
    可以创建自己的泛型接口、泛型类、泛型方法、泛型事件和泛型委托。
    可以对泛型类进行约束以访问特定数据类型的方法。
    在泛型数据类型中所用类型的信息可在运行时通过使用反射来获取。

泛型约束
    约束告知编译器类型参数必须具备的功能。 在没有任何约束的情况下，类型参数可以是任何类型。
        约束                描述
        where T : struct    类型参数必须是值类型。
        where T : class     类型参数必须是引用类型。 此约束还应用于任何类、接口、委托或数组类型。
        where T : new()     类型参数必须具有公共无参数构造函数。 与其他约束一起使用时，new() 约束必须最后指定。
        where T : <基类名>   类型参数必须是指定的基类或派生自指定的基类。
        where T : <接口名>   类型参数必须是指定的接口或实现指定的接口。 可指定多个接口约束。 约束接口也可以是泛型。
    某些约束是互斥的。 所有值类型必须具有可访问的无参数构造函数。 struct 约束包含 new() 约束，且 new() 约束不能与 struct 约束结合使用。

泛型类
    泛型类封装不特定于特定数据类型的操作。 泛型类最常见用法是用于链接列表、哈希表、堆栈、队列和树等集合。 无论存储数据的类型如何，添加项和从集合删除项等操作的执行方式基本相同。

泛型接口
    为避免对值类型的装箱和取消装箱操作，泛型类的首选项使用泛型接口，例如 IComparable<T> 而不是 IComparable。

泛型方法
    方法的参数和返回值可以定义为泛型，增加了方法的可用范围。
*/
#endregion
