using CS007.Net001;
using System;

namespace CS008.Net000
{
    /// <summary>
    /// 红利帐户：
    ///         将获得月末余额 2% 的额度
    /// </summary>
    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance) { }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposit(interest, DateTime.Now, "apply monthly interest");
            }
        }
    }

    /// <summary>
    /// 信用帐户：
    ///         余额可以为负，但不能大于信用限额的绝对值。
    ///         如果月末余额不为 0，每个月都会产生利息。
    ///         将在超过信用限额的每次提款后收取费用。
    /// </summary>
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance) { }
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit) { }
        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                decimal interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) => isOverdrawn ? new Transaction(-20, DateTime.Now, "Apply overdraft fee") : default;
    }

    /// <summary>
    /// 礼品卡帐户：
    ///         每月最后一天，可以充值一次指定的金额。
    /// </summary>
    public class GiftCardAccount : BankAccount
    {
        public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance) { }

        private readonly decimal _monthlyDeposit = 0m;

        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance) => _monthlyDeposit = monthlyDeposit;

        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }
    }

    class Program
    {
        public static void Main_()
        {
            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            /*
            var lineOfCredit = new LineOfCreditAccount("line of credit", 0);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());
            // */

            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());
        }
    }
}

namespace CS008.Study000
{
    class Program
    {
        static void PrintVoice(Animal ani)
        {
            ani.Voice();
        }

        public static void Main_()
        {
            int index = 1;

            if (index == -1)
            {
                ClassC cc = new ClassC(1);
                cc.FTest();
                cc.CTest();

                ClassF cf = new ClassF(1);
                cf.FTest();
            }

            if (index == 0)
            {
                Cat cat0 = new Cat("喵~~~~");
                cat0.Voice();

                Dog dog0 = new Dog("汪汪~~~~");
                dog0.Voice();

                PrintVoice(cat0);
                PrintVoice(dog0);

                // 返回 true 或者 false
                bool isAnimal = dog0 is Animal;
                if (isAnimal)
                {
                    Console.WriteLine("dog 是 Animal");
                }

                // 利用多态的特性打印
                Animal[] animals = { cat0, dog0 };
                for (int i = 0; i < animals.Length; i++)
                {
                    animals[i].Voice();
                }
            }

            if (index == 1)
            {
                // 子类隐式转换成父类
                object cat1 = new Cat("喵喵");

                Animal animal1 = new Cat("喵");
                animal1.Voice();

                // animal.CatSleep();

                Cat a2c1 = (Cat)animal1;
                a2c1.Voice();
                a2c1.CatSleep();
            }

            if (index == 2)
            {
                // 错误的转换方式
                // Animal animal2 = new Animal("动物父类");
                // Cat cat2 = (Cat)animal2;
                // cat2.Voice();
                // cat2.CatSleep();

                Animal animal3 = new Animal("动物父类");
                // 如果转换失败, 返回 null
                Cat a2c3 = animal3 as Cat;
                if (a2c3 != null)
                {
                    a2c3.Voice();
                }
                else
                {
                    Console.WriteLine("转换失败");
                }
            }

            if (index == 3)
            {
                Apple apple = new Apple("苹果");
                apple.PrintInfo();
                Console.WriteLine(apple.ToString());
            }

            if (index == 4)
            {
                // Person per = new Person();
                Men men = new Men();
                men.Name = "男人";
                men.Print();
            }
        }
    }

    #region 类 
    class ClassF
    {
        int a;

        public ClassF(int value)
        {
            this.a = value;
            Console.WriteLine("调用了父类的构造方法~");
        }

        public void FTest()
        {
            Console.WriteLine("父类的Test");
        }
    }

    class ClassC : ClassF
    {
        public ClassC(int val) : base(val)
        {
            Console.WriteLine("调用了子类的构造方法~");
        }

        public void CTest()
        {
            Console.WriteLine("子类的Test");
        }
    }
    #endregion

    #region 动物
    class Animal
    {
        // 子类无法访问父类的私有成员
        private string Name;

        // 受保护的成员, 不能再外部访问, 但是可以被子类访问
        protected string food;

        // 既可以被外部访问, 也可以被子类访问
        public string Data;

        public string voice;

        public Animal(string value)
        {
            voice = value;
        }

        public virtual void Voice()
        {
            Console.WriteLine("动物叫声: " + voice);
        }
    }

    class Cat : Animal
    {
        public Cat(string value) : base(value)
        {
            base.food = "猫粮";
        }

        public void CatSleep()
        {
            Console.WriteLine("猫在睡觉");
        }

        public override void Voice()
        {
            // base.Voice();
            Console.WriteLine("猫的叫声: " + voice);
        }
    }

    class Dog : Animal
    {
        public Dog(string value) : base(value) { }

        public override void Voice()
        {
            // base.Voice();
            Console.WriteLine("狗的叫声: " + voice);
        }
    }

    class GoldenDog : Dog
    {
        string sex;
        public GoldenDog(string sex, string str) : base(str)
        {
            this.sex = sex;
        }
    }
    #endregion

    #region 水果
    class Fruits
    {
        string _name;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public Fruits(string value)
        {
            _name = value;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("水果信息: " + _name);
        }
    }

    class Apple : Fruits
    {
        public Apple(string value) : base(value) { }

        public override void PrintInfo()
        {
            // 可以通过base关键字访问父类成员
            // base.PrintInfo(); 
            Console.WriteLine("这是" + base.Name);
        }

        public override string ToString()
        {
            return "这是一个苹果类";
        }
    }
    #endregion

    #region 人类
    abstract class Person
    {
        public string Name;

        //static不能和override, virtual, abstract同时使用
        abstract public void Print();

        public virtual void Test() { }
    }

    class Men : Person
    {
        public override void Print()
        {
            Console.WriteLine(Name);
        }

        //隐藏父类的虚方法
        public new void Test() { }
    }

    class Man : Men
    {
        // public override void Test() { base.Test(); }
    }
    #endregion
}

namespace CS008.Study001
{
    class Program
    {
        public static void Main_()
        {
            // 创建玩家和敌人
            Player player = new Player();
            Enemy enemy = new Enemy();

            // 进行回合制攻击
            while (true)
            {
                Console.WriteLine("\n按任意键进行攻击...");
                Console.ReadKey();

                // 玩家攻击敌人
                player.Attack(enemy);

                // 敌人攻击玩家
                enemy.Attack(player);
            }
        }
    }

    // 角色类（父类）
    abstract class Character
    {
        public int hp { get; set; }

        // 抽象方法：攻击
        public abstract void Attack(Character target);

        // 抽象方法：受伤
        public abstract void Injured(int value);

        // 抽象方法：死亡
        public abstract void Died();
    }

    // 玩家类（派生类）
    class Player : Character
    {
        public Player()
        {
            hp = 100;
        }

        // 实现攻击方法
        public override void Attack(Character target)
        {
            Console.WriteLine("玩家发起攻击！");
            target.Injured(20);
        }

        // 实现受伤方法
        public override void Injured(int value)
        {
            hp -= value;
            Console.WriteLine($"玩家受到 {value} 点伤害，剩余生命值: {hp}");
            if (hp <= 0)
            {
                Died();
            }
        }

        // 实现死亡方法
        public override void Died()
        {
            Console.WriteLine("玩家死亡，游戏结束。");
            Environment.Exit(0);
        }
    }

    // 敌人类（派生类）
    class Enemy : Character
    {
        public Enemy()
        {
            hp = 50;
        }

        // 实现攻击方法
        public override void Attack(Character target)
        {
            Console.WriteLine("敌人发起攻击！");
            target.Injured(10);
        }

        // 实现受伤方法
        public override void Injured(int value)
        {
            hp -= value;
            Console.WriteLine($"敌人受到 {value} 点伤害，剩余生命值: {hp}");
            if (hp <= 0)
            {
                Died();
            }
        }

        // 实现死亡方法
        public override void Died()
        {
            Console.WriteLine("敌人死亡。");
        }
    }
}

namespace CS008.Study002
{

    // 书类
    class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int page { get; set; }

        // 行为：展示书的信息
        public virtual void Display()
        {
            Console.WriteLine($"标题: {title}");
            Console.WriteLine($"作者: {author}");
            Console.WriteLine($"页数: {page} 页");
        }
    }

    // 有声书类（子类）
    class AudioBook : Book
    {
        public string audioFormat { get; set; }

        // 重写父类的展示信息方法
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"音频格式: {audioFormat}");
        }
    }

    // 文学书类（子类）
    class LiteratureBook : Book
    {
        public string type { get; set; }

        // 重写父类的展示信息方法
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"类型: {type}");
        }
    }

    // 历史书类（子类）
    class HistoryBook : Book
    {
        public string era { get; set; }

        // 重写父类的展示信息方法
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"时代: {era}");
        }
    }

    class Program
    {
        public static void Main_()
        {
            // 创建不同类型的书对象
            AudioBook audioBook = new AudioBook
            {
                title = "《科幻世界》",
                author = "Isaac Asimov",
                page = 300,
                audioFormat = "MP3"
            };

            LiteratureBook literatureBook = new LiteratureBook
            {
                title = "《红楼梦》",
                author = "曹雪芹",
                page = 800,
                type = "古典小说"
            };

            HistoryBook historyBook = new HistoryBook
            {
                title = "《人类简史》",
                author = "尤瓦尔·赫拉利",
                page = 400,
                era = "人类历史"
            };

            // 展示书的信息
            Console.WriteLine("有声书信息:");
            audioBook.Display();

            Console.WriteLine("\n文学书信息:");
            literatureBook.Display();

            Console.WriteLine("\n历史书信息:");
            historyBook.Display();

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}

namespace CS008.Study003
{
    // 书类
    class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int page { get; set; }

        // 行为：展示书的信息
        public virtual void Display()
        {
            Console.WriteLine($"标题: {title}");
            Console.WriteLine($"作者: {author}");
            Console.WriteLine($"页数: {page} 页");
        }
    }

    // 印刷工厂类
    class PrintFactory
    {
        // 生产书的方法
        public Book OutBook(string type)
        {
            switch (type)
            {
                case "海底两万里":
                    return new AudioBook
                    {
                        title = "海底两万里",
                        author = "儒勒·凡尔纳",
                        page = 400,
                        audioFormat = "MP3"
                    };
                case "史记":
                    return new HistoryBook
                    {
                        title = "史记",
                        author = "司马迁",
                        page = 600,
                        era = "中国古代"
                    };
                default:
                    Console.WriteLine($"暂不支持生产类型为 {type} 的书。");
                    return null;
            }
        }
    }

    // 有声书类（子类）
    class AudioBook : Book
    {
        public string audioFormat { get; set; }

        // 重写父类的展示信息方法
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"音频格式: {audioFormat}");
        }
    }

    // 历史书类（子类）
    class HistoryBook : Book
    {
        public string era { get; set; }

        // 重写父类的展示信息方法
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"时代: {era}");
        }
    }

    class Program
    {
        public static void Main_()
        {
            // 创建印刷工厂对象
            PrintFactory printFactory = new PrintFactory();

            // 生产不同类型的书
            Book book1 = printFactory.OutBook("海底两万里");
            Book book2 = printFactory.OutBook("史记");

            // 展示书的信息
            Console.WriteLine("第一本书的信息:");
            book1?.Display();

            Console.WriteLine("\n第二本书的信息:");
            book2?.Display();

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}