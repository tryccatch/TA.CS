using System;
using System.IO;
using System.Text;

namespace CS010.Net000
{
    class Program
    {
        public static void Main_()
        {
            // Get the directories currently on the C drive.
            DirectoryInfo[] cDirs = new DirectoryInfo(@"c:\").GetDirectories();

            // Write each directory name to a file.
            using (StreamWriter sw = new StreamWriter("CDriveDirs.txt"))
            {
                foreach (DirectoryInfo dir in cDirs)
                {
                    sw.WriteLine(dir.Name);
                }
            }

            // Read and show each line from the file.
            string line = "";
            using (StreamReader sr = new StreamReader("CDriveDirs.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}

namespace CS010.Study000
{
    class Program
    {
        static string filePath = @"../../../";
        static string fileName = "CreateFile.txt";
        static string path = string.Empty;
        static Encoding gbEncoding = Encoding.GetEncoding("utf-8");
        public static void Main_()
        {
            Console.Clear();

            // TestEncoding();
            // TestFile();
            // TestDirectory();
            // TestPath();
            TestFileStreamWrite();
            TestFilStreamRead();
        }

        /// <summary>
        /// 编码 Encoding
        /// </summary>
        static void TestEncoding()
        {
            Encoding encoding = Encoding.UTF8;
            byte[] byteArray = encoding.GetBytes("这个是BBBBB一个#AAA文!@本n");
            string data = encoding.GetString(byteArray);
            Console.WriteLine(data);
        }

        /// <summary>
        /// 文件 File
        /// </summary>
        static void TestFile()
        {
            path = string.Concat(filePath, fileName);

            // 判断文件是否存在 
            bool isExits = File.Exists(path);
            string des = isExits ? "存在" : "不存在";
            Console.WriteLine(des);

            FileStream fs;
            if (!isExits)
            {
                fs = File.Create(path);
                Console.WriteLine("不存在, 就创建文件" + fileName);
                fs.Close();
            }

            // 国标编码(.net core不支持)
            // var gbEncoding = Encoding.GetEncoding("utf-8");

            // 写入所有文本
            File.WriteAllText(path, "写入的内容!", gbEncoding);

            // 读取所有文本
            string des1 = File.ReadAllText(path, Encoding.GetEncoding("utf-8"));

            Console.WriteLine(des1);
            Console.ReadKey();

            // 追加所有文本
            File.AppendAllText(path, "追加文本", gbEncoding);
            Console.ReadKey();

            // 写入一个字符串数组
            string[] dataArray = { "123", "abc", "ABC", "中文" };
            File.WriteAllLines(path, dataArray, gbEncoding);
            Console.ReadKey();

            // 读度所有文本, 并以行为单位返回一个字符串数组
            string[] dataArray2 = File.ReadAllLines(path, gbEncoding);
            foreach (var text in dataArray2)
            {
                Console.WriteLine(text);
            }
            Console.ReadKey();

            // 写入一个字节数组
            Byte[] bytes = gbEncoding.GetBytes("chinese中文");
            File.WriteAllBytes(path, bytes);
            Console.ReadKey();

            // 按字节数组的格式读取文本
            bytes = File.ReadAllBytes(path);
            string des3 = gbEncoding.GetString(bytes);
            Console.WriteLine(des3);
            Console.ReadKey();

            // 删除指定的文件
            File.Delete(path);
        }

        /// <summary>
        /// 目录Directory
        /// </summary>
        static void TestDirectory()
        {
            Console.Clear();
            string dirName = "CreateDirectory";
            string dirPath = filePath + dirName;
            // 判断是否存在文件夹
            bool isExitsDir = Directory.Exists(dirPath);
            if (!isExitsDir)
            {
                // 创建文件夹
                Directory.CreateDirectory(dirPath);
                Console.WriteLine("不存在则创建一个文件夹:" + dirName);
            }

            // 得到指定目录下的所有文件名称及其路径
            string[] dirFilePathArray = Directory.GetFiles(dirPath);

            // 得到指定目录下的所有子目录及其路径
            string[] dirDirPathArray = Directory.GetDirectories(dirPath);

            // 得到当前执行程序的绝对路径
            string curPath = Directory.GetCurrentDirectory();
            Console.WriteLine("当前路径:" + curPath);
        }

        /// <summary>
        /// Path 路径
        /// </summary>
        static void TestPath()
        {
            // 会自动判断需要添加\的路径,从而添加\
            string realPath = Path.Combine(filePath, fileName);
            Console.WriteLine("文件路径: " + realPath);

            // 获得文件名称, 带后缀
            string name = Path.GetFileName(realPath);
            Console.WriteLine("文件名称: " + name);

            // 获得文件名称, 不带后缀
            string realName = Path.GetFileNameWithoutExtension(realPath);
            Console.WriteLine("文件名称: " + realName);

            // 获取文件的后缀名称
            string extension = Path.GetExtension(realPath);
            Console.WriteLine("文件后缀: " + extension);

            // 返回绝对路径
            string fullPath = Path.GetFullPath(realPath);
            Console.WriteLine("绝对路径: " + fullPath);
        }

        /// <summary>
        /// 流读取 FilStream
        /// </summary>
        static void TestFilStreamRead()
        {
            path = Path.Combine(filePath, fileName);

            // 创建流
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

            // 创建用于存放读取的流数据: 字节数组
            byte[] bytes = new byte[128];

            // fs Read流不支持写入
            // fs.Write(bytes, 0, 100);

            // 为方便下面的案例,先不进入读取
            while (true)
            {
                // 读取
                int resultNum = fs.Read(bytes, 0, bytes.Length);

                // 跳出循环
                if (resultNum == 0)
                {
                    break;
                }

                string text = Encoding.UTF8.GetString(bytes);

                // 打印
                Console.WriteLine(text);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
            }

            // 关闭流
            fs.Close();

            File.Delete(path);
        }

        /// <summary>
        /// 流写入 FilStream
        /// </summary>
        static void TestFileStreamWrite()
        {
            path = Path.Combine(filePath, fileName);

            /*
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                while (true)
                {
                    string input = Console.ReadLine();

                    if (string.Equals(input, "Q"))
                    {
                        break;
                    }

                    byte[] data = gbEncoding.GetBytes(input);

                    fs.Write(data, 0, data.Length);
                }
                fs.Close();
            }
            // */

            // using关键字:会自动释放被其修饰的流
            // 创建一个写入的流
            // /*
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    while (true)
                    {
                        string input = Console.ReadLine();

                        if (string.Equals(input, "Q"))
                        {
                            break;
                        }

                        byte[] data = gbEncoding.GetBytes(input + "\n");

                        // 写入内容
                        fs.Write(data, 0, data.Length);

                        // 刷新缓冲区
                        fs.Flush();
                    }
                }
            }
            // */
        }
    }
}