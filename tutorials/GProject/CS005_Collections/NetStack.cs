using System;
using System.Collections;
using System.Collections.Generic;

namespace CS005.Stack000
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
            // Creates and initializes a new Stack.
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");

            // Displays the properties and values of the Stack.
            Console.WriteLine("myStack");
            Console.WriteLine("\tCount:    {0}", myStack.Count);
            Console.Write("\tValues:");
            Collections.Program.PrintValues(myStack);
        }

        static void Study()
        {
            //初始化一个栈集合
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            stack1.Push(5);
            stack1.Push(6);

            //Peek查看栈顶元素
            int val1 = stack1.Peek();
            Console.WriteLine(val1 + "  Count:" + stack1.Count);

            //Pop取出元素,并在集合中删除对应元素
            //int val2 = stack1.Pop();
            //Console.WriteLine(val2 + " ---- " + stack1.Peek());//此时Peek得到的是2, 3已经被移除

            //判断元素
            bool isContain = stack1.Contains(1);
            if (isContain)
            {
                Console.WriteLine("栈中存在元素:" + isContain);
            }

            //遍历
            foreach (var item in stack1)
            {
                Console.Write(item + "   ");
            }
        }
    }
}