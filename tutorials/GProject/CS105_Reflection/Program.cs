using System;
using System.Reflection;
using UnityEngine;

namespace CS105_Reflection
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
            int a = 0;
            //a的类型获取
            a.GetType();
            //int的类型
            Type iType = typeof(int);

            Type type = Type.GetType("CS105_Reflection.Player");

            //利用反射 调用私有的无参构造函数，创建了Player实例
            object p1 = Activator.CreateInstance(type, true);

            //利用反射 调用私有 有参的构造函数
            object p2 = Activator.CreateInstance(type, BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { "22", 2 }, null);

            /*
             * BindingFlags:要查找的对象的权限归属
             * BindingFlags声明只能是零个或多个，不能只有一个
             */

            //获取公开的有参构造函数
            object p3 = Activator.CreateInstance(type, BindingFlags.Public | BindingFlags.Instance, null, new object[] { 2, "22" }, null);
        }
        static void Main01()
        {
            Type type = Type.GetType("CS105_Reflection.People");
            object people = Activator.CreateInstance(type);

            //利用反射获取字段，并且设置和取值
            FieldInfo fInfo_a = type.GetField("a");
            fInfo_a.SetValue(people, 50);
            object value_a = fInfo_a.GetValue(people);
            Console.WriteLine(value_a);

            FieldInfo fInfo_b = type.GetField("b", BindingFlags.NonPublic | BindingFlags.Instance);
            fInfo_b.SetValue(people, 60);
            Console.WriteLine(fInfo_b.GetValue(people));

            FieldInfo fInfo_c = type.GetField("c", BindingFlags.Public | BindingFlags.Static);
            fInfo_c.SetValue(null, 70);
            Console.WriteLine(fInfo_c.GetValue(null));

            PropertyInfo pInfo_D = type.GetProperty("D", BindingFlags.NonPublic | BindingFlags.Static);
            pInfo_D.SetValue(null, 80);
            Console.WriteLine(pInfo_D.GetValue(null));

            FieldInfo[] fInfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo item in fInfos)
            {
                if (!item.Name.Contains("Backing"))
                {

                }
            }

            //拿到方法
            MethodInfo mInfo_A = type.GetMethod("FuncA");
            //运行方法
            mInfo_A.Invoke(people, null);

            type.GetMethod("FuncB", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(people, null);

            MethodInfo mInfo_E = type.GetMethod("FuncE", BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(string), typeof(int) }, null);
            mInfo_E.Invoke(null, new object[] { "sss", 55 });

            MethodInfo mInfo_F = type.GetMethod("FuncF", BindingFlags.Public | BindingFlags.Instance);
            object re_F = mInfo_F.Invoke(people, new object[] { "www", 55 });
            Console.WriteLine(re_F);

            ConstructorInfo cInfo = type.GetConstructor(new Type[] { });
            object p1 = cInfo.Invoke(null);

            ConstructorInfo cInfo1 = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(int) }, null);
            object p2 = cInfo1.Invoke(new object[] { 2, 2 });
        }
    }

    class Player
    {
        private static Player instance;

        private Player() { Console.WriteLine("私有无参"); }
        private Player(string name, int id) { Console.WriteLine("私有两参"); }
        public Player(int a, string b) { Console.WriteLine("公开两参"); }

        internal static Player Instance
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
    }

    class People
    {
        public People()
        {
            Console.WriteLine("公共无参构造函数");
        }
        private People(int a, int b)
        {
            Console.WriteLine("私有有参构造函数");
        }

        #region
        public int a;
        private int b;
        public static int c;

        private static int d;

        public int A { get; set; }
        private int B { get; set; }
        public static int C { get; set; }
        private static int D { get; set; }
        #endregion

        public void FuncA() { Console.WriteLine("FuncA"); }
        private void FuncB() { Console.WriteLine("FuncB"); }
        public static void FuncC() { Console.WriteLine("FuncC"); }
        private static void FuncD() { Console.WriteLine("FuncD"); }
        public static void FuncE(string a, int b) { Console.WriteLine("FuncE" + a); }
        public static void FuncE() { Console.WriteLine("FuncE"); }
        public string FuncF(string a, int b) { Console.WriteLine("FuncF" + a); return b.ToString(); }
    }

    /// <summary>
    /// 项目输出类型设置为类库 => *.dll => Unity中使用
    /// </summary>
    public class MonoPeople : MonoBehaviour
    {
        public int a;

        public MonoPeople()
        {
            Debug.Log("公共无参构造函数");
        }
        private MonoPeople(int a, int b)
        {
            Debug.Log("私有有参构造函数");
        }

        public void FuncB() { Console.WriteLine("Func B"); Debug.Log("FuncB"); }
    }
}

#region notes
/*
C#高级-反射
    程序在运行的时候，可以查看其他程序集或者其本身的元数据。这个行为就是反射。 反射是.Net中获取运行时类型信息的方式，System.Reflection 命名空间中的类 与 System.Type 类使你能够获取有关加载的程序集和其中定义的类型信息，如类, 接口和值类型。可以使用反射在运行时创建，调用和访问类型的实例。
    .Net的应用程序由几个部分组成：'程序集(Assembly)'，'模块(Module)'，'类型(class)' 组成； 程序集包含模块，模块包含类型，类型包含成员。反射提供封装程序集，模块和类型的对象。可以使用反射动态的创建类型的实例，将类型绑定到现有的对象，或从现有的对象中获取类型，然后调用类型的方法或者访问其字段和属性；

反射的用途
    它允许在运行时查看特性（attribute）信息。
    它允许审查集合中的各种类型，以及实例化这些类型。
    它允许延迟绑定的方法和属性（property）。
    它允许在运行时创建新类型，然后使用这些类型执行一些任务。

使用反射
    System.Reflection
    System.Type
    System.Assembly
*/
#endregion