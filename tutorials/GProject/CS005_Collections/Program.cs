using System;
using System.Collections;

namespace CS005.Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            List000.Program.Main_();

            // Dictionary000.Program.Main_();

            // Queue000.Program.Main_();

            // Stack000.Program.Main_();

            // Hashtable000.Program.Main_();

            // ArrayList000.Program.Main_();
        }

        public static void PrintValues(IEnumerable myCollection)
        {
            foreach (Object obj in myCollection)
                Console.Write("    {0}", obj);
            Console.WriteLine();
        }
    }
}
