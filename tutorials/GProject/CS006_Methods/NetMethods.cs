using System;
using System.Linq;

namespace CS006.Net000
{
    public static class SquareExample
    {
        public static void Main_()
        {
            // Call with an int variable.
            int num = 4;
            int productA = Square(num);

            // Call with an integer literal.
            int productB = Square(12);

            // Call with an expression that evaluates to int.
            int productC = Square(productA * 3);
        }

        static int Square(int i)
        {
            // Store input argument in a local variable.
            int input = i;
            return input * input;
        }
    }
}

namespace CS006.Net001
{
    abstract class Motorcycle
    {
        // Anyone can call this.
        public void StartEngine() {/* Method statements here */ }

        // Only derived classes can call this.
        protected void AddGas(int gallons) { /* Method statements here */ }

        // Derived classes can override the base class implementation.
        public virtual int Drive(int miles, int speed) { /* Method statements here */ return 1; }

        // Derived classes can override the base class implementation.
        public virtual int Drive(TimeSpan time, int speed) { /* Method statements here */ return 0; }

        // Derived classes must implement this.
        public abstract double GetTopSpeed();
    }

    class TestMotorcycle00 : Motorcycle
    {
        public override double GetTopSpeed() => 108.4;

        public static void Main_()
        {
            var moto = new TestMotorcycle00();

            moto.StartEngine();
            moto.AddGas(15);
            _ = moto.Drive(5, 20);
            double speed = moto.GetTopSpeed();
            Console.WriteLine("My top speed is {0}", speed);
        }
    }

    class TestMotorcycle01 : Motorcycle
    {
        public override int Drive(int miles, int speed) =>
            (int)Math.Round((double)miles / speed, 0);

        public override double GetTopSpeed() => 108.4;

        public static void Main_()
        {
            var moto = new TestMotorcycle01();
            moto.StartEngine();
            moto.AddGas(15);
            int travelTime = moto.Drive(miles: 170, speed: 60);
            // int travelTime = moto.Drive(170, speed: 55);
            Console.WriteLine("Travel time: approx. {0} hours", travelTime);
        }
    }
}

namespace CS006.Net002
{
    public class Person
    {
        public string FirstName = default!;
    }

    public static class ClassTypeExample
    {
        public static void Main_()
        {
            Person p1 = new() { FirstName = "John" };
            Person p2 = new() { FirstName = "John" };
            Console.WriteLine("p1 = p2: {0}", p1.Equals(p2));
        }
    }
}

namespace CS006.Net003
{
    public class Person
    {
        public string FirstName = default!;

        public override bool Equals(object obj) =>
            obj is Person p2 &&
            FirstName.Equals(p2.FirstName);

        public override int GetHashCode() => FirstName.GetHashCode();
    }

    public static class Example
    {
        public static void Main_()
        {
            Person p1 = new() { FirstName = "John" };
            Person p2 = new() { FirstName = "John" };
            Console.WriteLine("p1 = p2: {0}", p1.Equals(p2));
        }
    }
}

namespace CS006.Net004
{
    #region 按值传递参数
    public static class ByValueExample
    {
        public static void Main_()
        {
            var value = 20;
            Console.WriteLine("In Main, value = {0}", value);
            ModifyValue(value);
            Console.WriteLine("Back in Main, value = {0}", value);
        }

        static void ModifyValue(int i)
        {
            i = 30;
            Console.WriteLine("In ModifyValue, parameter value = {0}", i);
            return;
        }
    }

    public class SampleRefType
    {
        public int value;
    }

    public static class ByRefTypeExample
    {
        public static void Main_()
        {
            var rt = new SampleRefType { value = 44 };
            ModifyObject(rt);
            Console.WriteLine(rt.value);
        }

        static void ModifyObject(SampleRefType obj) => obj.value = 33;
    }
    #endregion

    #region 按引用传递参数
    public static class ByRefExample
    {
        public static void Main_()
        {
            var value = 20;
            Console.WriteLine("In Main, value = {0}", value);
            ModifyValue(ref value);
            Console.WriteLine("Back in Main, value = {0}", value);
        }

        private static void ModifyValue(ref int i)
        {
            i = 30;
            Console.WriteLine("In ModifyValue, parameter value = {0}", i);
            return;
        }
    }

    public static class RefSwapExample
    {
        public static void Main_()
        {
            int i = 2, j = 3;
            Console.WriteLine("i = {0}  j = {1}", i, j);

            Swap(ref i, ref j);

            Console.WriteLine("i = {0}  j = {1}", i, j);
        }

        static void Swap(ref int x, ref int y) =>
            (y, x) = (x, y);
    }
    #endregion

    #region 参数数组
    static class ParamsExample
    {
        public static void Main_()
        {
            string fromArray = GetVowels(["apple", "banana", "pear"]);
            Console.WriteLine($"Vowels from array: '{fromArray}'");

            string fromMultipleArguments = GetVowels("apple", "banana", "pear");
            Console.WriteLine($"Vowels from multiple arguments: '{fromMultipleArguments}'");

            string fromNull = GetVowels(null);
            Console.WriteLine($"Vowels from null: '{fromNull}'");

            string fromNoValue = GetVowels();
            Console.WriteLine($"Vowels from no value: '{fromNoValue}'");
        }

        static string GetVowels(params string[] input)
        {
            if (input == null || input.Length == 0)
            {
                return string.Empty;
            }

            char[] vowels = ['A', 'E', 'I', 'O', 'U'];
            return string.Concat(
                input.SelectMany(
                    word => word.Where(letter => vowels.Contains(char.ToUpper(letter)))));
        }
    }
    #endregion

    #region 可选参数和自变量
    public class Options
    {
        public void ExampleMethod(int required, int optionalInt = default, string description = default)
        {
            var msg = $"{description ?? "N/A"}: {required} + {optionalInt} = {required + optionalInt}";
            Console.WriteLine(msg);
        }
    }

    public static class OptionsExample
    {
        public static void Main_()
        {
            var opt = new Options();
            opt.ExampleMethod(10);
            opt.ExampleMethod(10, 2);
            opt.ExampleMethod(12, description: "Addition with zero:");
        }
    }
    #endregion

    #region 返回值
    class SimpleMath
    {
        public int AddTwoNumbers(int number1, int number2) => number1 + number2;

        public int SquareANumber(int number) => number * number;
    }

    public static class SimpleMathTest
    {
        public static void Main_()
        {
            var obj = new SimpleMath();
            int result = obj.AddTwoNumbers(1, 2);
            result = obj.SquareANumber(result);
            // The result is 9.
            Console.WriteLine(result);

            result = obj.SquareANumber(obj.AddTwoNumbers(1, 2));
            // The result is 9.
            Console.WriteLine(result);
        }
    }
    #endregion

    #region 返回的元组类型
    public class PersonExample00
    {
        public static void Main_()
        {
            var person = GetPersonalInfo("111111111");
            Console.WriteLine($"{person.Item1} {person.Item3}: age = {person.Item4}");
        }

        public static (string, string, string, int) GetPersonalInfo(string id)
        {
            PersonInfo per = PersonInfo.RetrieveInfoById(id);
            return (per.FirstName, per.MiddleName, per.LastName, per.Age);
        }
    }

    public class PersonExample01
    {
        public static void Main_()
        {
            var person = GetPersonalInfo("111111111");
            Console.WriteLine($"{person.FName} {person.LName}: age = {person.Age}");
        }

        public static (string FName, string MName, string LName, int Age) GetPersonalInfo(string id)
        {
            PersonInfo per = PersonInfo.RetrieveInfoById(id);
            return (per.FirstName, per.MiddleName, per.LastName, per.Age);
        }
    }

    class PersonInfo
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public PersonInfo(string FName, string MName, string LName, int age)
        {
            FirstName = FName;
            MiddleName = MName;
            LastName = LName;
            Age = age;
        }

        public static PersonInfo RetrieveInfoById(string id)
        {
            return new PersonInfo("Y", "Y", "J", 28);
        }
    }
    #endregion

    #region 数组作为自变量传递
    public static class ArrayValueExample
    {
        public static void Main_()
        {
            int[] values = [2, 4, 6, 8];
            DoubleValues(values);
            foreach (var value in values)
            {
                Console.Write("{0}  ", value);
            }
        }

        public static void DoubleValues(int[] arr)
        {
            for (var ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
            {
                arr[ctr] *= 2;
            }
        }
    }
    #endregion
}

namespace CS006.Study000
{
    class Program
    {
        class MyClassA
        {
            // int a;
            public int b;
        }
        static int hp = 1;
        public static void Main_()
        {
            //写代码的地方
            // Test(1);
            #region 方法
            MyClassA myClassA = new MyClassA();
            myClassA.b = 1;

            Study001.MyClassB myClassB = new Study001.MyClassB();

            int result1 = GetPlayerMaxHp();
            Console.WriteLine("hp: " + result1);

            int result2 = Add(1, 2, 2);
            Console.WriteLine("1 + 2 + 2 = " + result2);

            int result3 = Add(1, 2);
            Console.WriteLine("1 + 2  = " + result3);

            int result4 = Add(1, 2, 3, 4, 5, 6, 7, 8);
            int result5 = Add(1, 2, new int[] { 3, 4, 5, 6, 7, 8 });

            Console.WriteLine("result4: " + result4);
            Console.WriteLine("result5: " + result5);
            #endregion

            int result6 = 0;
            TestRef(ref result6);
            Console.WriteLine("ref result6: " + result6);

            int result7, result8, result9;
            TestOut(out result7, out result8, out result9);
            Console.WriteLine("out result7: " + result7);

            int[] array = { 0, 1, 2 };
            // 值传递,引用类型
            SetArray(array);

            ChangeArray(array);

            TestRef(ref array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "   ");
            }
        }

        // 访问修饰符   返回值的数据类型   方法名   参数
        public static void Test(int value)
        {
            hp = 2;
            Console.WriteLine("方法Test中的打印");
        }

        #region 方法的重载和参数
        static int GetPlayerMaxHp()
        {
            return hp;
        }

        /// <summary>
        /// 加法运算
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static int Add(int a, int b, int c = 0)
        {
            int result = a + b + c;
            return result;
        }

        static int Add(int d, int e, float f)
        {
            return d + e;
        }

        /// <summary>
        /// 默认参数后,后面的参数, 也必须有默认参数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static int Sub(int a = 1, int b = 2, int c = 3)
        {
            int result = a - b - c;
            return result;
        }

        /// <summary>
        /// 可变参数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int Add(int a, int b, params int[] arr)
        {
            int result = a + b;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i];
            }

            return result;
        }
        #endregion

        #region 参数修饰符
        static public void SetArray(int[] arr)
        {
            arr[0] = 99;
        }

        static public void ChangeArray(int[] arr)
        {
            arr = new int[3];
            arr[0] = 1;
        }

        static public void SetInt(int value)
        {
            value = 99;
        }

        // 值参数的引用传递
        static public void TestRef(ref int value)
        {
            value = 1;
        }

        static public void TestRef(ref int[] arr)
        {
            arr = new int[5] { 99, 88, 77, 66, 55 };
        }

        static public void TestOut(out int value1, out int value2, out int value3)
        {
            value1 = 1;
            value2 = 1;
            value3 = 1;
        }
        #endregion
    }
}

namespace CS006.Study001
{
    class MyClassB
    {

    }
}