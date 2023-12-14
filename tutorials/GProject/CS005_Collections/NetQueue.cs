using System;
using System.Collections;
using System.Collections.Generic;

namespace CS005.Queue000
{
    class Program
    {
        public static void Main_()
        {
            Example001();
            Study();
        }

        static void Example001()
        {
            // Creates and initializes a new Queue.
            Queue myQ = new Queue();
            myQ.Enqueue("Hello");
            myQ.Enqueue("World");
            myQ.Enqueue("!");

            // Displays the properties and values of the Queue.
            Console.WriteLine("myQ");
            Console.WriteLine("\tCount:    {0}", myQ.Count);
            Console.Write("\tValues:");
            Collections.Program.PrintValues(myQ);
        }

        static void Study()
        {
            //初始化队列
            Queue<int> que = new Queue<int>();
            for (int i = 0; i < 5; i++)
            {
                que.Enqueue(i);
            }

            //取得队列头的元素, 不移除
            int val = que.Peek();
            //Console.WriteLine(val);


            //取得队列头的元素,并从队列头移除该元素
            // int val2 = que.Dequeue();
            //取得队列头的元素, 不移除
            val = que.Peek();
            //Console.WriteLine(val2 + "-----" + val);

            //遍历
            foreach (var item in que)
            {
                Console.Write(item + "   ");
            }
        }
    }
}