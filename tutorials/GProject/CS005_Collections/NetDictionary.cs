using System;
using System.Collections.Generic;

namespace CS005.Dictionary000
{
    class Program
    {
        public static void Main_()
        {
            IterateThruDictionary();
            Study();
        }

        static void IterateThruDictionary()
        {
            Dictionary<string, Element> elements = BuildDictionary();

            foreach (KeyValuePair<string, Element> kvp in elements)
            {
                Element theElement = kvp.Value;

                Console.WriteLine("key: " + kvp.Key);
                Console.WriteLine("values: " + theElement.Symbol + " " +
                                               theElement.Name + " " +
                                               theElement.AtomicNumber);
            }

            string symbol = "K";
            {
                if (elements.ContainsKey(symbol) == false)
                {
                    Console.WriteLine(symbol + " not found");
                }
                else
                {
                    Element theElement = elements[symbol];
                    Console.WriteLine("found: " + theElement.Name);
                }
            }
            {
                if (elements.TryGetValue(symbol, out Element theElement) == false)
                    Console.WriteLine(symbol + " not found");
                else
                    Console.WriteLine("found: " + theElement.Name);
            }
        }

        class Element
        {
            public required string Symbol { get; init; }
            public required string Name { get; init; }
            public required int AtomicNumber { get; init; }
        }

        static Dictionary<string, Element> BuildDictionary() => new(){
        {"K",
            new (){ Symbol="K", Name="Potassium", AtomicNumber=19}},
        {"Ca",
            new (){ Symbol="Ca", Name="Calcium", AtomicNumber=20}},
        {"Sc",
            new (){ Symbol="Sc", Name="Scandium", AtomicNumber=21}},
        {"Ti",
            new (){ Symbol="Ti", Name="Titanium", AtomicNumber=22}}
    };

        static void Study()
        {
            //Dictionary<T,T> 字典
            //初始化一个字典
            Dictionary<string, int> dic = new Dictionary<string, int>();
            //向字典添加元素
            dic.Add("TA", 100);
            //如果dic中有"ta"的键值的话,此处是修改这个键对应的值;
            //如果没有,则是添加
            dic["ta"] = 99;
            Console.WriteLine("值: " + dic["ta"]);
            //根据key值,取得value值
            int val = dic["TA"];
            Console.WriteLine("值: " + val);
            //修改值
            dic["TA"] = 88;
            Console.WriteLine("值: " + dic["TA"]);

            //判断dic中是否有键
            if (dic.ContainsKey("ta"))
            {
                Console.WriteLine("访问key为:ta的元素: " + dic["ta"]);
            }
            //判断dic中是否有对应的值
            if (dic.ContainsValue(9999))
            {
                dic["ta2"] = 9999;
                Console.WriteLine("字典中有值9999");
            }

            //移除dic中的键值对: KeyValuePair
            bool isRemove = dic.Remove("ta2");
            if (isRemove)
            {
                Console.WriteLine("移除成功!");
            }

            //尝试取得key所关联的值
            int val2;
            bool isGet = dic.TryGetValue("ta2", out val2);
            if (isGet)
            {
                Console.WriteLine("尝试取得数据成功,  值为:" + val2);
            }
            else
            {
                Console.WriteLine("尝试取得数据失败");
            }

            //字典中的元素个数
            //dic.Count;
            //清空字典
            //dic.Clear();



            //被var关键字修饰的变量,必须在声明时即赋值,它会通过等号右侧的表达式推算出变量的类型
            var val3 = new List<int>();
            //collection:集合
            //foreach中的item即集合中的元素, 此处是KeyValuePair的结构体
            foreach (var item in dic)
            {
                //此处报错, 因为foreach中不能直接修改item
                // item.Value = 100;

                //可以通过item修改字典的内容
                dic[item.Key] = 100;

                //遍历取得内容
                Console.WriteLine("键:" + item.Key + "   值:" + item.Value);
            }

            List<int> numbers = new List<int>(new int[] { 1, 2, 3 });
            //foreach中的item即集合中的元素, 此处是int类型的元素
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}