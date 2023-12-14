using System;

namespace CS003.Net000
{
    class Program
    {
        public static void Main_()
        {
            // ArithmeticOperators();
            // BooleanLogicalOperators();
            BitwiseAndShiftOperators();
        }

        private static void BitwiseAndShiftOperators()
        {
            // 按位求补运算符 ~
            {
                uint a = 0b_0000_1111_0000_1111_0000_1111_0000_1100;
                uint b = ~a;
                Console.WriteLine(Convert.ToString(b, toBase: 2));
            }

            // 左移位运算符 <<
            {
                uint x = 0b_1100_1001_0000_0000_0000_0000_0001_0001;
                Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2)}");

                uint y = x << 4;
                Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2)}");

                byte a = 0b_1111_0001;

                var b = a << 8;
                Console.WriteLine(b.GetType());
                Console.WriteLine($"Shifted byte: {Convert.ToString(b, toBase: 2)}");
            }

            // 右移位运算符 >>
            {
                uint x = 0b_1001;
                Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2),4}");

                uint y = x >> 2;
                Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2).PadLeft(4, '0'),4}");

                int a = int.MinValue;
                Console.WriteLine($"Before: {Convert.ToString(a, toBase: 2)}");

                int b = a >> 3;
                Console.WriteLine($"After:  {Convert.ToString(b, toBase: 2)}");
                // Output:
                // Before: 10000000000000000000000000000000
                // After:  11110000000000000000000000000000

                uint c = 0b_1000_0000_0000_0000_0000_0000_0000_0000;
                Console.WriteLine($"Before: {Convert.ToString(c, toBase: 2),32}");

                uint d = c >> 3;
                Console.WriteLine($"After:  {Convert.ToString(d, toBase: 2).PadLeft(32, '0'),32}");
                // Output:
                // Before: 10000000000000000000000000000000
                // After:  00010000000000000000000000000000
            }

            // 无符号右移运算符 >>>
            {
                int x = -8;
                Console.WriteLine($"Before:    {x,11}, hex: {x,8:x}, binary: {Convert.ToString(x, toBase: 2),32}");

                int y = x >> 2;
                Console.WriteLine($"After  >>: {y,11}, hex: {y,8:x}, binary: {Convert.ToString(y, toBase: 2),32}");

                int z = x >>> 2;
                Console.WriteLine($"After >>>: {z,11}, hex: {z,8:x}, binary: {Convert.ToString(z, toBase: 2).PadLeft(32, '0'),32}");
                // Output:
                // Before:             -8, hex: fffffff8, binary: 11111111111111111111111111111000
                // After  >>:          -2, hex: fffffffe, binary: 11111111111111111111111111111110
                // After >>>:  1073741822, hex: 3ffffffe, binary: 00111111111111111111111111111110
            }

            // 逻辑与运算符 &
            {
                uint a = 0b_1111_1000;
                uint b = 0b_1001_1101;
                uint c = a & b;
                Console.WriteLine(Convert.ToString(c, toBase: 2));
                // Output:
                // 10011000
            }

            // 逻辑异或运算符 ^
            {
                uint a = 0b_1111_1000;
                uint b = 0b_0001_1100;
                uint c = a ^ b;
                Console.WriteLine(Convert.ToString(c, toBase: 2));
                // Output:
                // 11100100
            }

            // 逻辑或运算符 |
            {
                uint a = 0b_1010_0000;
                uint b = 0b_1001_0001;
                uint c = a | b;
                Console.WriteLine(Convert.ToString(c, toBase: 2));
                // Output:
                // 10110001
            }

            // 运算符优先级
            // 按位求补运算符 ~
            // 移位运算符 <<、>> 和 >>>
            // 逻辑与运算符 &
            // 逻辑异或运算符 ^
            // 逻辑或运算符 |
            {
                uint a = 0b_1101;
                uint b = 0b_1001;
                uint c = 0b_1010;

                uint d1 = a | b & c;
                Display(d1);  // output: 1101

                uint d2 = (a | b) & c;
                Display(d2);  // output: 1000

                void Display(uint x) => Console.WriteLine($"{Convert.ToString(x, toBase: 2),4}");
            }

            // 移位运算符的移位计数
            {
                int count1 = 0b_0000_0001;
                int count2 = 0b_1110_0001;

                int a = 0b_0001;
                Console.WriteLine($"{a} << {count1} is {a << count1}; {a} << {count2} is {a << count2}");
                // Output:
                // 1 << 1 is 2; 1 << 225 is 2

                int b = 0b_0100;
                Console.WriteLine($"{b} >> {count1} is {b >> count1}; {b} >> {count2} is {b >> count2}");
                // Output:
                // 4 >> 1 is 2; 4 >> 225 is 2

                int count = -31;
                int c = 0b_0001;
                Console.WriteLine($"{c} << {count} is {c << count}");
                // Output:
                // 1 << -31 is 2
            }
        }

        /// <summary>
        /// 布尔逻辑运算符 - AND、OR、NOT、XOR
        /// </summary>
        private static void BooleanLogicalOperators()
        {
            // 逻辑非运算符 !
            {
                bool passed = false;
                Console.WriteLine(!passed);
                Console.WriteLine(!true);
            }

            // 逻辑与运算符 &
            {
                bool SecondOperand()
                {
                    Console.WriteLine("Second operand is evaluated.");
                    return true;
                }

                bool a = false & SecondOperand();
                Console.WriteLine(a);


                bool b = true & SecondOperand();
                Console.WriteLine(b);
            }

            // 逻辑异或运算符 ^
            {
                Console.WriteLine(true ^ true);
                Console.WriteLine(true ^ false);
                Console.WriteLine(false ^ true);
                Console.WriteLine(false ^ false);
            }

            // 逻辑或运算符 |
            {
                bool SecondOperand()
                {
                    Console.WriteLine("Second operand is evaluated.");
                    return true;
                }

                bool a = true | SecondOperand();
                Console.WriteLine(a);

                bool b = false | SecondOperand();
                Console.WriteLine(b);
            }

            // 条件逻辑与运算符 &&
            {
                bool SecondOperand()
                {
                    Console.WriteLine("Second operand is evaluated.");
                    return true;
                }

                bool a = false && SecondOperand();
                Console.WriteLine(a);

                bool b = true && SecondOperand();
                Console.WriteLine(b);
            }

            // 条件逻辑或运算符 ||
            {
                bool SecondOperand()
                {
                    Console.WriteLine("Second operand is evaluated.");
                    return true;
                }

                bool a = false && SecondOperand();
                Console.WriteLine(a);

                bool b = true && SecondOperand();
                Console.WriteLine(b);
            }

            // 运算符优先级
            // 逻辑非运算符!
            // 逻辑与运算符 &
            // 逻辑异或运算符 ^
            // 逻辑或运算符 |
            // 条件逻辑与运算符 &&
            // 条件逻辑或运算符 ||
            {
                Console.WriteLine(true | true & false);
                Console.WriteLine((true | true) & false);

                bool Operand(string name, bool value)
                {
                    Console.WriteLine($"Operand {name} is evaluated.");
                    return value;
                }

                var byDefaultPrecedence = Operand("A", true) || Operand("B", true) && Operand("C", false);
                Console.WriteLine(byDefaultPrecedence);


                var changedOrder = (Operand("A", true) || Operand("B", true)) && Operand("C", false);
                Console.WriteLine(changedOrder);
            }
        }

        /// <summary>
        /// 算术运算符
        /// </summary>
        private static void ArithmeticOperators()
        {
            // 一元 ++（增量）、--（减量）、+（加）和 -（减）运算符
            // 二元 *（乘法）、/（除法）、%（余数）、+（加法）和 -（减法）运算符

            // 增量运算符 ++
            {
                int i = 3;
                Console.WriteLine(i);
                Console.WriteLine(i++);
                Console.WriteLine(i);

                double a = 1.5;
                Console.WriteLine(a);
                Console.WriteLine(++a);
                Console.WriteLine(a);
            }

            // 减量运算符--
            {
                int i = 3;
                Console.WriteLine(i);
                Console.WriteLine(i--);
                Console.WriteLine(i);

                double a = 1.5;
                Console.WriteLine(a);
                Console.WriteLine(--a);
                Console.WriteLine(a);
            }

            // 一元加和减运算符
            {
                Console.WriteLine(+4);
                Console.WriteLine(-4);
                Console.WriteLine(-(-4));

                uint a = 5;
                var b = -a;
                Console.WriteLine(b);
                Console.WriteLine(b.GetType());

                Console.WriteLine(-double.NaN);
            }

            // 乘法运算符 *
            {
                Console.WriteLine(5 * 2);
                Console.WriteLine(0.5 * 2.5);
                Console.WriteLine(0.1m * 23.4m);
            }

            // 除法运算符 /
            {
                Console.WriteLine(13 / 5);
                Console.WriteLine(-13 / 5);
                Console.WriteLine(13 / -5);
                Console.WriteLine(-13 / -5);

                Console.WriteLine(13 / 5.0);

                int a = 13;
                int b = 5;
                Console.WriteLine((double)a / b);

                Console.WriteLine(16.8f / 4.1f);
                Console.WriteLine(16.8d / 4.1d);
                Console.WriteLine(16.8m / 4.1m);
            }

            // 余数运算符 %
            {
                // 对于整数类型的操作数，a % b 的结果是 a -(a / b) * b 得出的值
                Console.WriteLine(5 % 4);
                Console.WriteLine(5 % -4);
                Console.WriteLine(-5 % 4);
                Console.WriteLine(-5 % -4);

                Console.WriteLine(-5.2f % 2.0f);
                Console.WriteLine(5.9 % 3.1);
                Console.WriteLine(5.9m % 3.1m);
            }

            // 加法运算符 +
            {
                Console.WriteLine(5 + 4);
                Console.WriteLine(5 + 4.3);
                Console.WriteLine(5.1m + 4.2m);
            }

            // 减法运算符 -
            {
                Console.WriteLine(47 - 3);
                Console.WriteLine(5 - 4.3);
                Console.WriteLine(7.5m - 2.3m);
            }

            // 复合赋值
            {
                {
                    int a = 5;
                    a += 9;
                    Console.WriteLine(a);

                    a -= 4;
                    Console.WriteLine(a);

                    a *= 2;
                    Console.WriteLine(a);

                    a /= 4;
                    Console.WriteLine(a);

                    a %= 3;
                    Console.WriteLine(a);
                }
                {
                    byte a = 200;
                    byte b = 100;

                    var c = a + b;
                    Console.WriteLine(c.GetType());
                    Console.WriteLine(c);

                    a += b;
                    Console.WriteLine(a);
                }
            }

            // 运算符优先级和关联性
            // 后缀增量 x++和减量 x-- 运算符
            // 前缀增量 ++x 和减量--x 以及一元 +和 - 运算符
            // 乘法 *、/ 和 % 运算符
            // 加法 + 和 - 运算符
            {
                Console.WriteLine(2 + 2 * 2);
                Console.WriteLine((2 + 2) * 2);

                Console.WriteLine(9 / 5 / 2);
                Console.WriteLine(9 / (5 / 2));
            }
        }
    }
}