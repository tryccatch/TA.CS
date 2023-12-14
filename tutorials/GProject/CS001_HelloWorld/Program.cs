using System;

namespace CS001_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ConsoleApi();
        }

        /// <summary>
        /// 控制台常用API
        /// </summary>
        static void ConsoleApi()
        {
            Console.Beep();
            Console.Write("TA,");
            Console.WriteLine("Hello World!");

            Console.WriteLine(sizeof(int));
            int size = System.Runtime.InteropServices.Marshal.SizeOf(1);//可以获取一个变量的内存大小
            Console.WriteLine(size);

            Console.ReadKey();
            //Console.Clear();
            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine('\u0007');

            Console.Write("Hello ");
            Console.WriteLine("World!");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Good day, ");
            Console.Write(name);
            Console.WriteLine("!");
        }
    }
}