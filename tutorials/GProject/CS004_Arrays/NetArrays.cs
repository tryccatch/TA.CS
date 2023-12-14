using System;

namespace CS004.Net000
{
    class Program
    {
        public static void Main_()
        {
            NetExample();
        }

        private static void NetExample()
        {
            {
                // Declare a single-dimensional array of 5 integers.
                int[] array1 = new int[5];

                // Declare and set array element values.
                int[] array2 = [1, 2, 3, 4, 5, 6];

                // Declare a two dimensional array.
                int[,] multiDimensionalArray1 = new int[2, 3];

                // Declare and set array element values.
                int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

                // Declare a jagged array.
                int[][] jaggedArray = new int[6][];

                // Set the values of the first array in the jagged array structure.
                jaggedArray[0] = [1, 2, 3, 4];
            }

            // 一维数组
            {
                int[] array = new int[5];
                string[] weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

                Console.WriteLine(weekDays[0]);
                Console.WriteLine(weekDays[1]);
                Console.WriteLine(weekDays[2]);
                Console.WriteLine(weekDays[3]);
                Console.WriteLine(weekDays[4]);
                Console.WriteLine(weekDays[5]);
                Console.WriteLine(weekDays[6]);
            }

            // 多维数组
            {
                {
                    int[,] array2DDeclaration = new int[4, 2];

                    int[,,] array3DDeclaration = new int[4, 2, 3];

                    int[,] array2DInitialization = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
                    int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } },
                                                { { 7, 8, 9 }, { 10, 11, 12 } } };

                    Console.WriteLine(array2DInitialization[0, 0]);
                    Console.WriteLine(array2DInitialization[0, 1]);
                    Console.WriteLine(array2DInitialization[1, 0]);
                    Console.WriteLine(array2DInitialization[1, 1]);

                    Console.WriteLine(array2DInitialization[3, 0]);
                    Console.WriteLine(array2DInitialization[3, 1]);


                    Console.WriteLine(array3D[1, 0, 1]);
                    Console.WriteLine(array3D[1, 1, 2]);

                    var allLength = array3D.Length;
                    var total = 1;
                    for (int i = 0; i < array3D.Rank; i++)
                    {
                        total *= array3D.GetLength(i);
                    }
                    Console.WriteLine($"{allLength} equals {total}");
                }
                {
                    int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

                    foreach (int i in numbers2D)
                    {
                        Console.Write($"{i} ");
                    }

                    int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4,   5,  6 } },
                        { { 7, 8, 9 }, { 10, 11, 12 } } };
                    foreach (int i in array3D)
                    {
                        Console.Write($"{i} ");
                    }
                }
                {
                    int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4,   5,  6 } },
                        { { 7, 8, 9 }, { 10, 11, 12 } } };

                    for (int i = 0; i < array3D.GetLength(0); i++)
                    {
                        for (int j = 0; j < array3D.GetLength(1); j++)
                        {
                            for (int k = 0; k < array3D.GetLength(2); k++)
                            {
                                Console.Write($"{array3D[i, j, k]} ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                }
            }

            // 交错数组
            {
                {
                    int[][] jaggedArray = new int[3][];

                    jaggedArray[0] = [1, 3, 5, 7, 9];
                    jaggedArray[1] = [0, 2, 4, 6];
                    jaggedArray[2] = [11, 22];

                    int[][] jaggedArray2 =
                    [
                        [1, 3, 5, 7, 9],
                        [0, 2, 4, 6],
                        [11, 22]
                    ];

                    jaggedArray2[0][1] = 77;

                    jaggedArray2[2][1] = 88;

                    int[][,] jaggedArray3 =
                    [
                        new int[,] { { 1, 3 }, { 5, 7 } },
                        new int[,] { { 0, 2 }, { 4, 6 }, { 8, 10 } },
                        new int[,] { { 11, 22 }, { 99, 88 }, { 0, 9 } }
                    ];

                    Console.Write("{0}", jaggedArray3[0][1, 0]);
                    Console.WriteLine(jaggedArray3.Length);
                }
                {
                    int[][] arr = new int[2][];

                    arr[0] = [1, 3, 5, 7, 9];
                    arr[1] = [2, 4, 6, 8];

                    for (int i = 0; i < arr.Length; i++)
                    {
                        System.Console.Write("Element({0}): ", i);

                        for (int j = 0; j < arr[i].Length; j++)
                        {
                            System.Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                        }
                        System.Console.WriteLine();
                    }
                }
            }

            // 隐式类型的数组
            {
                int[] a = new[] { 1, 10, 100, 1000 };

                // Accessing array
                Console.WriteLine("First element: " + a[0]);
                Console.WriteLine("Second element: " + a[1]);
                Console.WriteLine("Third element: " + a[2]);
                Console.WriteLine("Fourth element: " + a[3]);

                var b = new[] { "hello", null, "world" };

                Console.WriteLine(string.Join(" ", b));

                int[][] c =
                [
                    [1, 2, 3, 4],
                    [5, 6, 7, 8]
                ];

                for (int k = 0; k < c.Length; k++)
                {
                    for (int j = 0; j < c[k].Length; j++)
                    {
                        Console.WriteLine($"Element at c[{k}][{j}] is: {c[k][j]}");
                    }
                }

                string[][] d =
                [
                    ["Luca", "Mads", "Luke", "Dinesh"],
                    ["Karen", "Suma", "Frances"]
                ];

                int i = 0;
                foreach (var subArray in d)
                {
                    int j = 0;
                    foreach (var element in subArray)
                    {
                        Console.WriteLine($"Element at d[{i}][{j}] is: {element}");
                        j++;
                    }
                    i++;
                }

                var contacts = new[]{
                    new {
                        Name = " Eugene Zabokritski",
                        PhoneNumbers = new[] { "206-555-0108", "425-555-0001" }
                    },
                    new {
                        Name = " Hanying Feng",
                        PhoneNumbers = new[] { "650-555-0199" }
                    }
                };
            }
        }
    }
}

namespace CS004.Study000
{
    class Program
    {
        public static void Main_()
        {
            // 定义两个数组
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 6, 7, 8, 9, 10 };

            // 合并两个数组
            int[] mergedArray = MergeArrays(array1, array2);

            // 输出合并后的数组
            Console.WriteLine("合并后的数组:");
            foreach (int num in mergedArray)
            {
                Console.Write($"{num} ");
            }

            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }

        // 合并两个数组的方法
        static int[] MergeArrays(int[] arr1, int[] arr2)
        {
            int length1 = arr1.Length;
            int length2 = arr2.Length;
            int[] result = new int[length1 + length2];

            // 将第一个数组复制到结果数组
            Array.Copy(arr1, result, length1);

            // 将第二个数组复制到结果数组
            Array.Copy(arr2, 0, result, length1, length2);

            return result;
        }
    }
}