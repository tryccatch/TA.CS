using System;
using System.Collections;

namespace CS005.ArrayList000
{
    class Program
    {
        public static void Main_()
        {
            Example001();
        }

        static void Example001()
        {
            // Creates and initializes a new ArrayList.
            ArrayList myAL = new ArrayList();
            myAL.Add("Hello");
            myAL.Add("World");
            myAL.Add("!");

            // Displays the properties and values of the ArrayList.
            Console.WriteLine("myAL");
            Console.WriteLine("    Count:    {0}", myAL.Count);
            Console.WriteLine("    Capacity: {0}", myAL.Capacity);
            Console.Write("    Values:");
            Collections.Program.PrintValues(myAL);
        }
    }
}