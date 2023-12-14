using System;
using System.Collections.Generic;

namespace CS007.Net001
{
    #region 定义银行帐户类型
    public class BankAccount
    {
        private static int s_accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        // public decimal Balance { get; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        /*
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
        }
        // */

        /// <summary>
        /// 打开新帐户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="initialBalance"></param>
        /*
        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            // Balance = initialBalance;
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
        }
        // */

        /*
        public BankAccount(string name, decimal initialBalance)
        {
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;

            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        // */

        #region LineOfCreditAccount
        private readonly decimal _minimumBalance;
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;

            Owner = name;
            _minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            Transaction overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
            Transaction withdrawal = new(-amount, date, note);
            _allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                _allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }
        #endregion

        private List<Transaction> _allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }

        /*
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            // if (Balance - amount < 0)
            if (Balance - amount < _minimumBalance)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);
        }
        // */

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in _allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        // 多态性
        public virtual void PerformMonthEndTransactions() { }
    }
    #endregion

    #region 创建存款和取款
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }
    }
    #endregion

    class Program
    {
        public static void Main_()
        {
            var account = new BankAccount("<name>", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            // Test that the initial balances must be positive.
            /* 创建初始余额为负数的帐户
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                return;
            }
            // */

            // Test for a negative balance.
            /* 取款后余额为负数
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            // */

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}

namespace CS007.Study000
{
    class Program
    {
        // public static object MyClass3 { get; private set; }

        public static void Main_()
        {
            // MyClass1 mc1 = new MyClass1(1,2);
            MyClass1 mc1 = new MyClass1(1, 2, 3);
            mc1.Print();

            MyClass2 mc2 = new MyClass2(10);
            //调用索引指示器
            mc2[0] = 100;
            mc2.Print();

            // object p = MyClass3.Print();
            MyClass3.Print();
            MyClass3.Print(1);


            //我们无法去实例化一个静态对象,因为它在程序运行之处就已经存在了,有且仅有这一份
            // MyClass4 mc4 = new MyClass4();

            {
                MyClass5 mc5 = new MyClass5();

                mc5.Data = 3;
                Console.WriteLine(mc5.Data);

                mc5.DataSet = 1;
                // 此处报错
                // Console.WriteLine("只有Set的属性:" + mc5.DataSet);

                Console.WriteLine("只有get的属性:" + mc5.DataGet);

                // mc5.DataInSet = 1;
            }
        }
    }

    //类名要以大驼峰命名规则
    class BigHump
    {

    }

    class MyClass1
    {
        //成员默认为private

        //公有字段
        public int b;

        //私有字段
        int a;

        //属性
        public int AAAA
        {
            set
            {
                if (value < 0)
                {
                    a = 0;
                }
                else
                {
                    a = value;
                }
            }
            get
            {
                //逻辑运算: + - * /
                return 99999;
            }
        }

        //构造方法1
        public MyClass1(int value1, int value2)
        {
            a = value1;
            b = value2;
            Console.WriteLine("调用了构造方法~~~1");
        }
        ////构造方法的重载
        public MyClass1(int value1, int value2, int value3)
        {
            a = value1;
            b = value2;
            Console.WriteLine("调用了构造方法~~~2");
        }

        //只能在类内部访问私有的构造方法
        private MyClass1(int value1)
        {
            a = value1;
        }

        //成员方法
        public void Print()
        {
            MyClass1 class1 = new MyClass1(999);
            Console.WriteLine("打印:" + GetValue(a));
        }

        //成员方法
        int GetValue(int temp)
        {
            b += temp;
            return b;
        }
    }

    class MyClass2
    {
        private int[] data;

        public MyClass2(int length)
        {
            data = new int[length];
        }

        //索引指示器
        public int this[int index]
        {
            set
            {
                if (index < 0)
                {
                    index = 0;
                }
                if (index >= data.Length)
                {
                    index = data.Length - 1;
                }
                data[index] = value;
            }
            get
            {
                if (index < 0)
                {
                    index = 0;
                }
                if (index >= data.Length)
                {
                    index = data.Length - 1;
                }
                return data[index];
            }
        }

        public void Print()
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + "  ");
            }
            Console.WriteLine();
        }
    }

    class MyClass3
    {
        static int a;
        public static void Print()
        {
            int xxx = 0;
            // 静态方法调用普通成员时,会报错, 因为普通成员的数据可能不存在
            // GetA(); 
            Console.WriteLine("MyClass3.Print: " + a);
        }


        public static void Print(int x)
        {
            // 静态方法调用普通成员时,会报错, 因为普通成员的数据可能不存在
            // GetA(); 
            Console.WriteLine("MyClass3.Print: " + x);
        }

        public int GetA()
        {
            // 普通方法调用静态成员是可以的, 因为静态成员一定存在
            Print();
            return a;
        }
    }

    static class MyClass4
    {
        static int data;

        static void Print()
        {

        }
    }

    class MyClass5
    {
        private int _data;

        // 此处系统会为Data4自动创建一个私有变量用于使用
        public int Data
        {
            set;
            get;
        }

        // 属性可以只有一个访问器: set或get
        public int DataSet
        {
            //此处仅有set访问器, 因此也无法被访问
            set
            {
                _data = value;
            }
        }

        public int DataGet
        {
            //此处仅有get访问器, 因此仅可以被访问,但是不能被设置值
            get
            {
                return _data;
            }
        }

        public int DataInSet
        {
            // 属性允许被访问修饰符修饰, 因此该访问器仅可以在类内部访问
            private set
            {
                _data = value;
            }
            // 默认为public
            get
            {
                return _data;
            }
        }

        public void SetValue()
        {
            DataInSet = 2;
        }
    }
}