using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS009.Net000
{
    class Program
    {
        public static void Main_()
        {

        }
    }
}

namespace CS009.Study000
{
    class Program
    {
        public static void Main_()
        {
            Console.Clear();

            // StringInit();
            // StringMethod00();
            // StringMethod01();
            StringFormat();
        }

        /// <summary>
        /// 字符串
        /// </summary>
        static void StringInit()
        {
            // String类 初始化
            string str1 = "yyj";
            string str2 = str1;
            string str3 = str1 + str2 + "AAAAA";
            Console.WriteLine(str3);

            // 初始化一个空的字符串,它指向堆内存中一个长度为0的地址
            string str4 = string.Empty;
            string str5 = "";
            Console.WriteLine(str4 + "---" + str5 + "----");

            // str等于null并不会在内存中分配空间
            string str6 = null;
            // string str7;

            Console.WriteLine(str6);
            // Console.WriteLine(str7);
        }

        static void StringMethod00()
        {
            // Format格式化:{0}只能从0开始顺序添加,并且后面的内容需要和占位符一一对应
            string str1 = "ta班";
            string str2 = "32人";

            // 可以传变量,可以是表达式,可以是常量字符串
            string str3 = string.Format("{0} 一共有 {1} !!!! {2}", str1, str2, "实到20人");
            Console.WriteLine(str3);

            // string.IsNullOrWhiteSpace(string str);
            // 检测字符串是否为空串或null
            bool isNullOrEmpty = string.IsNullOrWhiteSpace(string.Empty);
            Console.WriteLine("是否为空字符串: " + isNullOrEmpty);

            // string.Concat(字符串1, 字符串2, 字符串3,....); 参数是可变参数,拼接多个字符串
            string str4 = string.Concat(str1, str2, "???", "AAA");
            string str5 = str1 + str2;
            Console.WriteLine(str4);
            Console.WriteLine(str5);

            // 初始化字符串,在堆内存中开辟空间
            string str6 = "AAA BBB";
            // 丢弃原来的空间,从新在堆内存中开辟空间
            str6 = "CCC DDD";

            // 和其它引用类型类似
            int[] arr = new int[10];
            arr = new int[10];

            // string.Join(string  分隔字符串,  params string[] str); 拼接多个字符串并用指定字符串分割
            string str7 = string.Join(",", str1, str2, str6, "AAA");
            Console.WriteLine(str7);

            string str8 = string.Join("===TA===", str1, str2, str6, "AAA");
            Console.WriteLine(str8);

            string str9 = str7 + "," + str8;
            Console.WriteLine(str9);
        }

        static void StringMethod01()
        {
            // 修改字符串String的内容
            string str1 = "AAAAAAA";

            // insert 插入: 在指定下标处插入一个字符串,此处的0代表下标,小标不能超过字符串的Length-1
            string str2 = str1.Insert(0, "XXXXX");
            Console.WriteLine(str2 + " 长度: " + str2.Length);

            // 判断字符串是否以???开头或结尾
            if (str2.StartsWith("XXX"))
            {
                Console.WriteLine("字符串{0}以XXX开头", str2);
            }

            bool isEndsWith = str2.EndsWith("XXX");
            if (!isEndsWith)
            {
                Console.WriteLine("字符串{0}不以XXX结尾", str2);
            }

            // Substring截取
            string str3 = "ABCD1234567EFG";
            //从下标处开始截取字符串到字符串结尾
            string str4 = str3.Substring(5);
            Console.WriteLine(str4);

            string str5 = str3.Substring(0, 2);
            Console.WriteLine(str5);

            // Replace替换
            string str6 = "AAA BBB CCC";
            // 把老的字符, 全部替换为新的字符
            string str7 = str6.Replace('A', 'B');
            Console.WriteLine(str7);

            string str8 = str7.Replace("BBB BBB", "BBA BBB");
            Console.WriteLine("替换字符串后: " + str8);

            // Split分割
            string str9 = string.Join("|", "ABC", "123", "@#$", "789");
            Console.WriteLine(str9);

            string[] strArr = str9.Split('|');
            for (int i = 0; i < strArr.Length; i++)
            {
                Console.WriteLine(strArr[i]);
            }

            // 技能书
            // ID       skill
            // 10001    2001_5
            string skill = "2001_1";
            string[] skillInfo = skill.Split('_');

            // skillInfo[0];技能ID
            // skillInfo[1];技能等级
            Console.WriteLine(skillInfo[0]);
            Console.WriteLine(skillInfo[1]);

            // 转义字符
            string str10 = "abc\"TA\nabc";
            Console.WriteLine(str10);
            string str11 = @"abc\TA\nabc";
            Console.WriteLine(str11);

            //StringBuilder 初始化
            StringBuilder sb = new StringBuilder();
            sb.Append("ABC");
            //sb.Clear();
            sb.AppendLine("DEF");
            sb.Append("ABC");

            Console.WriteLine(sb.ToString());
        }

        static void StringFormat()
        {
            // 格式化的深入
            // C: 货币, 货币至少会保留两位小数
            string str1 = string.Format("C: 猪肉价:{0:C}, 牛肉价:{1:C2}, 羊肉价:{2:C3}", 20.12343f, 30.12341f, 40.12341f);
            Console.WriteLine(str1);

            // D:表示十进制, 只能传整数
            string str2 = string.Format("D: 猪肉价:{0:D}, 羊肉价:{1:D}", -20, 30);
            Console.WriteLine(str2);

            // E:表示科学计数算法
            string str3 = string.Format("E: 猪肉价:{0:E}, 羊肉价:{1:E}", 20, 30);
            Console.WriteLine(str3);

            // G:常规,G和G2是同一个精度,2以后精度依次递增
            string str4 = string.Format("G: 猪肉价:{0:G4}, 羊肉价:{1:G}", 20.12345, 30);
            Console.WriteLine(str4);

            // N:用分号隔开的数字: N表示默认留两位小数, N1表示默认留一位小数, 以此类推~~~~~
            string str5 = string.Format("N: 猪肉价:{0:N1}, 羊肉价:{1:N2}", 1000000.123, 3000);
            Console.WriteLine(str5);

            // X:十六进制
            string str6 = string.Format("X: 猪肉价:0x{0:X}, 羊肉价:0x{1:X}", 100000, 3000);
            Console.WriteLine(str6);

            // P:百分比
            string str7 = string.Format("P: 猪肉价:{0:P}, 羊肉价:{1:P}", 0.2354, 0.99);
            Console.WriteLine(str7);

            // 对时间的格式化
            while (true)
            {
                string str8 = string.Format("当前时间:{0:yyyy-MM-dd  H:mm:ss}", DateTime.Now);

                Console.WriteLine(str8);

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

namespace CS009.Study001
{
    class Program
    {
        public static void Main_()
        {
            // 测试字符串是否是回文字符串
            string str1 = "abccba";
            string str2 = "abcdcbb";

            Console.WriteLine($"{str1} 是回文字符串: {IsPalindromic(str1)}");
            Console.WriteLine($"{str2} 是回文字符串: {IsPalindromic(str2)}");

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        // 判断字符串是否是回文字符串的方法
        static bool IsPalindromic(string str)
        {
            // 移除字符串中的空格，并转换为小写
            string cleanedStr = str.Replace(" ", "").ToLower();

            // 反转字符串
            char[] charArray = cleanedStr.ToCharArray();
            Array.Reverse(charArray);
            string reversedStr = new string(charArray);

            // 比较原始字符串和反转后的字符串是否相同
            return cleanedStr == reversedStr;
        }
    }
}

namespace CS009.Study002
{
    using System;

    class Program
    {
        public static void Main_()
        {
            // 测试替换字符串中的字符
            string originalString = "Hello, World!";
            char oldChar = 'o';
            char newChar = '*';

            string replacedString = ReplaceChar(originalString, oldChar, newChar);

            Console.WriteLine($"原始字符串: {originalString}");
            Console.WriteLine($"替换后的字符串: {replacedString}");

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        // 替换字符串中的指定字符为新的字符的方法
        static string ReplaceChar(string input, char oldChar, char newChar)
        {
            // 将字符串转换为字符数组
            char[] charArray = input.ToCharArray();

            // 遍历字符数组，替换指定字符
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == oldChar)
                {
                    charArray[i] = newChar;
                }
            }

            // 将字符数组转换回字符串
            string result = new string(charArray);
            return result;
        }
    }
}

namespace CS009.Study003
{
    class Program
    {
        public static void Main_()
        {
            // 测试统计字符串中出现频率最多的字符
            string inputString = "programming";

            char mostFrequentChar = MostChar(inputString);

            Console.WriteLine($"字符串: {inputString}");
            Console.WriteLine($"出现频率最多的字符: {mostFrequentChar}");

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        // 获取字符串中出现频率最多的字符的方法
        static char MostChar(string input)
        {
            // 使用字典记录字符及其出现的次数
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            // 遍历字符串，统计字符出现的次数
            foreach (char c in input)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }

            // 找到出现频率最高的字符
            char mostFrequentChar = charCount.OrderByDescending(pair => pair.Value).First().Key;

            return mostFrequentChar;
        }
    }
}

namespace CS009.Study004
{
    class Program
    {
        public static void Main_()
        {
            // 测试截断字符串并添加省略号
            string inputString = "This is a long string that needs to be truncated.";
            int maxLength = 20;

            string truncatedString = SubString(inputString, maxLength);

            Console.WriteLine($"原始字符串: {inputString}");
            Console.WriteLine($"截断后的字符串: {truncatedString}");

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        // 截断字符串并添加省略号的方法
        static string SubString(string str, int maxLength)
        {
            if (str.Length > maxLength)
            {
                // 截断字符串并添加省略号
                string truncatedStr = str.Substring(0, maxLength) + "...";
                return truncatedStr;
            }
            else
            {
                // 字符串长度未超过指定长度，不进行截断
                return str;
            }
        }
    }
}

namespace CS009.Study005
{
    using System;
    using System.Threading;

    class Program
    {
        public static void Main_()
        {
            // 设定Loading界面存在的最短时间（单位：秒）
            int minimumLoadingTimeInSeconds = 3;

            // 显示Loading界面
            显示Loading界面();

            // 模拟一些耗时操作
            模拟耗时操作();

            // 关闭Loading界面
            关闭Loading界面(minimumLoadingTimeInSeconds);

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        // 显示Loading界面的方法
        static void 显示Loading界面()
        {
            Console.Write("Loading...");

            // 可以添加更复杂的Loading效果，比如旋转的字符或进度条
        }

        // 模拟耗时操作的方法
        static void 模拟耗时操作()
        {
            // 这里可以模拟一些耗时的操作，比如数据加载、文件读取等
            Thread.Sleep(5000); // 休眠5秒钟，模拟耗时操作
        }

        // 关闭Loading界面的方法
        static void 关闭Loading界面(int minimumLoadingTimeInSeconds)
        {
            // 计算Loading界面已经存在的时间
            DateTime startTime = DateTime.Now;
            TimeSpan elapsedTime;

            do
            {
                elapsedTime = DateTime.Now - startTime;
            } while (elapsedTime.TotalSeconds < minimumLoadingTimeInSeconds);

            Console.WriteLine("\nLoading完成！");
        }
    }
}

namespace CS009.Study006
{
    using System;
    using System.Threading;

    class Program
    {
        public static void Main_()
        {
            // 设定Loading界面存在的最短时间（单位：秒）
            int minimumLoadingTimeInSeconds = 3;

            // 显示动态Loading界面
            显示动态Loading界面();

            // 模拟一些耗时操作
            模拟耗时操作();

            // 关闭Loading界面
            关闭Loading界面(minimumLoadingTimeInSeconds);

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }

        // 显示动态Loading界面的方法
        static void 显示动态Loading界面()
        {
            Console.Write("Loading");

            // 循环显示动态Loading效果，模拟动态Loading
            int dotsCount = 0;
            while (true)
            {
                // 模拟动态效果，每隔500毫秒切换一次
                Thread.Sleep(500);

                Console.Write(".");
                dotsCount++;

                // 回车后重新输出Loading，形成动态效果
                if (dotsCount == 3)
                {
                    Console.Write("\b\b\b   \b\b\b"); // 回退并清空三个字符
                    dotsCount = 0;
                }
            }
        }

        // 模拟耗时操作的方法
        static void 模拟耗时操作()
        {
            // 这里可以模拟一些耗时的操作，比如数据加载、文件读取等
            Thread.Sleep(5000); // 休眠5秒钟，模拟耗时操作
        }

        // 关闭Loading界面的方法
        static void 关闭Loading界面(int minimumLoadingTimeInSeconds)
        {
            // 计算Loading界面已经存在的时间
            DateTime startTime = DateTime.Now;
            TimeSpan elapsedTime;

            do
            {
                elapsedTime = DateTime.Now - startTime;
            } while (elapsedTime.TotalSeconds < minimumLoadingTimeInSeconds);

            Console.WriteLine("\nLoading完成！");
        }
    }
}