using System;
using System.Collections.Generic;

namespace CS005.List000
{
    class Program
    {
        public static void Main_()
        {

            // Example001();
            // Example002();
            // Example003();
            // ListEvenNumbers();
            // Study();
            Init();
        }

        static void Init() {
            List<int> list = new List<int>();

            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);
            list.Add(1);

            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);

            list.Remove(1);
            list.Remove(1);
            
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
        }

        static void Example001()
        {
            List<string> salmons = ["chinook", "coho", "pink", "sockeye"];

            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
            Console.WriteLine();

            salmons.Remove("coho");

            for (var index = 0; index < salmons.Count; index++)
            {
                Console.Write(salmons[index] + " ");
            }
            Console.WriteLine();

            salmons.Add("coho");

            foreach (var salmon in salmons)
            {
                Console.Write(salmon + " ");
            }
            Console.WriteLine();
        }

        static void Example002()
        {
            List<int> numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

            for (var index = numbers.Count - 1; index >= 0; index--)
            {
                if (numbers[index] % 2 == 1)
                {
                    numbers.RemoveAt(index);
                }
            }

            numbers.ForEach(
                number => Console.Write(number + " "));
        }

        static void Example003()
        {
            var theGalaxies = new List<Galaxy>
        {
            new (){ Name="Tadpole", MegaLightYears=400},
            new (){ Name="Pinwheel", MegaLightYears=25},
            new (){ Name="Milky Way", MegaLightYears=0},
            new (){ Name="Andromeda", MegaLightYears=3}
        };

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears);
            }
        }

        class Galaxy
        {
            public string Name { get; set; }
            public int MegaLightYears { get; set; }
        }

        static void ListEvenNumbers()
        {
            foreach (int number in EvenSequence(5, 18))
            {
                Console.Write(number.ToString() + " ");
            }
            Console.WriteLine();
        }

        static IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
        {
            for (var number = firstNumber; number <= lastNumber; number++)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }
        }

        static void Study()
        {
            //List<T>  列表
            //初始化
            List<int> list1 = new List<int>();
            //向集合添加元素  
            for (int i = 0; i < 10; i++)
            {
                list1.Add(i);
            }

            //--------------------------注意点:------------------------------------
            //此时list中有十个元素
            //此处报错,因为第是个元素并不存在(未被添加),因此无法被赋值修改
            //list1[10] = 99;
            //---------------------------------------------------------------------

            list1[9] = 99;
            list1[8] = 88;
            //PrintList(list1);

            //移除list中的指定元素
            //list1.Remove(99);

            //通过下标移除数组元素
            list1.RemoveAt(list1.Count - 1);
            //PrintList(list1);
            list1.RemoveAt(3);
            //PrintList(list1);

            //在指定索引处插入一个元素
            list1.Insert(0, 11);
            //PrintList(list1);

            //在指定索引处插入一个范围(多个)的元素  此处是插入一个数组
            list1.InsertRange(6, new int[] { 9, 8, 7 });
            List<int> list2 = new List<int>(new int[] { 1, 2, 3 });

            //此处是插入List的集合
            list1.InsertRange(0, list2);

            //查找指定元素在集合中的下标(位置)
            int index = list1.IndexOf(88);

            //集合中是否包含某个元素
            bool isContain = list1.Contains(88);
            if (isContain)
            {
                Console.WriteLine("list中存在 : " + 88);
            }

            Collections.Program.PrintValues(list1);

            //清空list中的元素, 但list本身并未被回收
            list1.Clear();
            //清空后list中的元素数量为0
        }
    }
}