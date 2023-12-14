using System;
using System.Numerics;

namespace CS002.Net000
{
    class Program
    {
        public static void Main_()
        {
            //IntegralType();
            //FloatingPointType();
            //BoolType();
            EnumType();
            StructType();
        }

        /// <summary>
        /// 整型
        /// </summary>
        static void IntegralType()
        {
            SByte a = 1;
            Byte b = 2;
            Console.WriteLine("sizeof(SByte) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(SByte), SByte.MinValue, SByte.MaxValue);
            Console.WriteLine("sizeof(Byte) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(Byte), Byte.MinValue, Byte.MaxValue);

            short c = 3;
            ushort d = 4;
            Console.WriteLine("sizeof(short) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(short), short.MinValue, short.MaxValue);
            Console.WriteLine("sizeof(ushort) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(ushort), ushort.MinValue, ushort.MaxValue);

            int e = 5;
            uint f = 6;
            Console.WriteLine("sizeof(int) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(int), int.MinValue, int.MaxValue);
            Console.WriteLine("sizeof(uint) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(uint), uint.MinValue, uint.MaxValue);

            long g = 7;
            ulong h = 8;
            Console.WriteLine("sizeof(long) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(long), long.MinValue, long.MaxValue);
            Console.WriteLine("sizeof(ulong) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(ulong), ulong.MinValue, ulong.MaxValue);

            nint i = 9;
            nuint j = 10;
            Console.WriteLine("sizeof(nint) = {0}\n\t Min = {1}\n\t Max = {2}", typeof(uint), nint.MinValue, nint.MaxValue);
            Console.WriteLine("sizeof(nuint) = {0}\n\t Min = {1}\n\t Max = {2}", typeof(nuint), nuint.MinValue, nuint.MaxValue);

            BigInteger k = 11;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);
            Console.WriteLine(g);
            Console.WriteLine(h);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.WriteLine(k);

            var hexLiteral = 0x2A;
            var decimalLiteral = 42;
            var binaryLiteral = 0b_0010_1010;

            Console.WriteLine(hexLiteral);
            Console.WriteLine(decimalLiteral);
            Console.WriteLine(binaryLiteral);
            Console.WriteLine(Convert.ToString(42, 8));

            /* 整数文本
             * 十进制：不使用任何前缀
             * 十六进制：使用 0x 或 0X 前缀
             * 二进制：使用 0b 或 0B 前缀
             * 如果文字没有后缀，则其值可以表示为以下类型的第一个类型：int、uint、long 和 ulong
             * 如果文本的后缀为 U 或 u，则它具有以下类型中可以表示其值的第一个类型：uint、ulong
             * 如果文本的后缀为 L 或 l，则它具有以下类型中可以表示其值的第一个类型：long、ulong
             * 如果文本的后缀为 UL、Ul 、、、、、uL ul LU Lu lU 或，则 lu 它属于类型 ulong
             */
            var l = 12u;
            Console.WriteLine(l);

            /* char
             * 字符文本
             * Unicode 转义序列，它是 \u 后跟字符代码的十六进制表示形式（四个符号）
             * 十六进制转义序列，它是 \x 后跟字符代码的十六进制表示形式
             */
            var chars = new[] {
                'j',
                '\u006A',
                '\x006A',
                (char)106,
            };
            Console.WriteLine(string.Join(" ", chars));

            char m = 'A';
            Console.WriteLine("sizeof(char) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(char), (int)char.MinValue, (int)char.MaxValue);
            Console.WriteLine(m);
        }

        /// <summary>
        /// 浮点型
        /// </summary>
        static void FloatingPointType()
        {
            float a = 1.0f;
            Console.WriteLine("sizeof(float) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(float), float.MinValue, float.MaxValue);

            double b = 2.0;
            Console.WriteLine("sizeof(double) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(double), double.MinValue, double.MaxValue);

            decimal c = 3.0m;
            Console.WriteLine("sizeof(decimal) = {0}\n\t Min = {1}\n\t Max = {2}", sizeof(decimal), decimal.MinValue, decimal.MaxValue);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            /* 真实文本
             *  带有 f 或 F 后缀的文本的类型为 float -> 1f 1.5f 1e10f 和 123.456F 都是类型 float
             *  不带后缀的文本或带有 d 或 D 后缀的文本的类型为 double -> 1d 1.5d 1e10d 和 123.456D 都是类型 double
             *  带有 m 或 M 后缀的文本的类型为 decimal -> 1m 1.5m 1e10m 和 123.456M 都是类型 decimal
             */
            double d = 3D;
            d = 4d;
            d = 3.934_001;

            float e = 3_000.5F;
            e = 5.4f;

            decimal f = 3_000.5m;
            f = 400.75M;

            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);

            //科学记数法
            double g = 0.42e2;
            Console.WriteLine(g);

            float h = 134.45E-2f;
            Console.WriteLine(h);

            decimal i = 1.5E6m;
            Console.WriteLine(i);
        }

        /// <summary>
        /// 布尔类型
        /// </summary>-
        static void BoolType()
        {
            //true false
            bool check = true;
            Console.WriteLine(check ? "Checked" : "Not checked");
            Console.WriteLine("sizeof(bool) = {0} \n\t{1} \n\t{2}", sizeof(bool), bool.TrueString, bool.FalseString);

            Console.WriteLine(Convert.ToBoolean(0));
            Console.WriteLine(Convert.ToBoolean(1));
            Console.WriteLine(Convert.ToByte(true));
            Console.WriteLine(Convert.ToByte(false));

            /* 运算符
             * !(逻辑非)
             * &(逻辑与)
             * |(逻辑或)
             * ^(逻辑异或)
             * &&(条件逻辑与)
             * ||(条件逻辑或)
             */

        }

        [Flags]
        public enum Days
        {
            None = 0b_0000_0000,  // 0
            Monday = 0b_0000_0001,  // 1
            Tuesday = 0b_0000_0010,  // 2
            Wednesday = 0b_0000_0100,  // 4
            Thursday = 0b_0000_1000,  // 8
            Friday = 0b_0001_0000,  // 16
            Saturday = 0b_0010_0000,  // 32
            Sunday = 0b_0100_0000,  // 64
            Weekend = Saturday | Sunday
        }

        /// <summary>
        /// 枚举类型
        /// </summary>
        static void EnumType()
        {
            Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
            Console.WriteLine(meetingDays);

            var a = (Days)37;
            Console.WriteLine(a);

            var values = Enum.GetValues(typeof(Days));
            var names = Enum.GetNames(typeof(Days));

            foreach (var value in values)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            foreach (var name in names)
            {
                Console.Write("{0} ", name);
            }
            Console.WriteLine();

            Console.WriteLine(Enum.GetName(typeof(Days), 1));

            Console.WriteLine(values.GetValue(3));

            Days days = Days.Monday | Days.Wednesday | Days.Friday;
            Days day = Days.Tuesday;
            var daysType = day.GetType();
            Console.WriteLine("days.HasFlag({0}) : {1} ", day, days.HasFlag(day));
            Console.WriteLine("Enum.IsDefined({0}, {1}): {2}", typeof(Days).Name, day, Enum.IsDefined(typeof(Days), day));
            Console.WriteLine("enumType.Name : {0}", day.GetType().Name);
            Console.WriteLine("Enum.Parse({0},{1}) : {2}", daysType, "Monday", Enum.Parse(daysType, "Monday"));
            object outValue;
            Console.WriteLine("Enum.TryParse({0},{1},out value) : {2}", daysType, "Monday", Enum.TryParse(daysType, "Monday", out outValue));
            Console.WriteLine(outValue);
        }

        public readonly struct Coords
        {
            public Coords(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double X { get; init; }
            public double Y { get; init; }

            public override string ToString() => $"({X}, {Y})";
        }

        /// <summary>
        /// 结构类型
        /// </summary>
        static void StructType()
        {
            var p1 = new Coords(0, 0);
            Console.WriteLine(p1);

            var p2 = p1 with { X = 3 };
            Console.WriteLine(p2);

            var p3 = p1 with { X = 1, Y = 4 };
            Console.WriteLine(p3);
        }
    }
}

namespace CS002.Study000
{
    // 角色类型枚举
    enum PlayerType
    {
        Warrior,
        Mage
    }

    // 装备结构体
    struct Equip
    {
        public string name;
        public int atk;
        public int def;
    }

    // 角色数据结构体
    struct PlayerData
    {
        public PlayerType type;
        public string name;
        public int atk;
        public int def;
        public int hp;
    }

    // 角色类
    class Player
    {
        public PlayerData data;
        public Equip equip;

        // 构造方法
        public Player(PlayerType type, string name, int atk, int def, int hp)
        {
            data = new PlayerData
            {
                type = type,
                name = name,
                atk = atk,
                def = def,
                hp = hp
            };

            equip = new Equip { name = "无装备", atk = 0, def = 0 };
        }

        // 计算攻击力的方法
        public int CalAtk()
        {
            return data.atk + equip.atk;
        }

        // 计算防御力的方法
        public int CalDef()
        {
            return data.def + equip.def;
        }

        // 攻击方法
        public void Attack(Player target)
        {
            int atk = CalAtk();
            int def = target.CalDef();
            int hurt = Math.Max(atk - def, 0);

            Console.WriteLine($"{data.name} 对 {target.data.name} 发起攻击，造成 {hurt} 点伤害。");

            target.Injure(hurt);
        }

        // 受伤方法
        public void Injure(int value)
        {
            data.hp -= value;
            Console.WriteLine($"{data.name} 受到 {value} 点伤害，剩余血量: {data.hp}");

            if (data.hp <= 0)
            {
                Died();
            }
        }

        // 死亡方法
        private void Died()
        {
            Console.WriteLine($"{data.name} 已经死亡。");
        }
    }

    class Program
    {
        public static void Main_()
        {
            // 创建战士和法师角色
            Player warrior = new Player(PlayerType.Warrior, "战士A", 30, 20, 100);
            Player mage = new Player(PlayerType.Mage, "法师B", 20, 15, 80);

            // 战斗过程
            Console.WriteLine("开始战斗：");
            warrior.Attack(mage);
            mage.Attack(warrior);
            warrior.Attack(mage);

            Console.WriteLine("战斗结束。按任意键退出...");
            Console.ReadKey();
        }
    }
}