using System;

namespace CS201_SortingAlgorithm
{
    internal class Program
    {
        static int counter = 0;
        static void Main(string[] args)
        {
            int[] array = { 8, 9, 6, 7, 4, 5, 2, 3, 0, 1 };
            PrintArray(array);
            Console.WriteLine();

            //char[] c = { 'a', };
            //Console.WriteLine(c);

            //BubbleSort(array);
            QuickSort(array, 0, 9);

            Console.WriteLine(counter);
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 冒泡排序(O(n^2))
        /// 比较相邻的元素。如果第一个比第二个大，就交换他们两个。
        /// 对每一对相邻元素作同样的工作，从开始第一对到结尾的最后一对。这步做完后，最后的元素会是最大的数。
        /// 针对所有的元素重复以上的步骤，除了最后一个。
        /// 持续每次对越来越少的元素重复上面的步骤，直到没有任何一对数字需要比较。
        /// </summary>
        /// <param name="array">数组</param>
        private static void BubbleSort(int[] array)
        {
            int i, j, temp, length = array.Length;
            for (i = 0; i < length - 1; i++)
            {
                for (j = 0; j < length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                    else
                    {
                        //一丢丢优化
                        if (j == length - 2 - i)
                            ++i;
                    }
                    PrintArray(array);
                    counter++;
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 快速排序(O(n log n))
        /// 从数列中挑出一个元素，称为 "基准"（pivot）;
        /// 重新排序数列，所有元素比基准值小的摆放在基准前面，所有元素比基准值大的摆在基准的后面（相同的数可以到任一边）。在这个分区退出之后，该基准就处于数列的中间位置。这个称为分区（partition）操作；
        /// 递归地（recursive）把小于基准值元素的子数列和大于基准值元素的子数列排序；
        /// </summary>
        /// <param name="array">数组</param>
        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = partition(array, left, right);
                QuickSort(array, left, partitionIndex - 1);
                QuickSort(array, partitionIndex + 1, right);
            }
        }

        private static int partition(int[] array, int left, int right)
        {
            //设置基准值(pivot)
            int pivot = left;
            int index = pivot + 1;
            for (int i = index; i <= right; i++)
            {
                if (array[i] < array[pivot])
                {
                    Swip(array, i, index);
                    index++;
                }
                counter++;
            }
            Swip(array, pivot, index - 1);
            return index - 1;
        }

        private static void Swip(int[] array, int i, int j)
        {
            Console.WriteLine(HorizontalTabs(i, j));
            PrintArray(array);

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            PrintArray(array);

            Console.WriteLine();
        }

        private static string HorizontalTabs(int x, int y)
        {
            string result = string.Empty;
            int max = Math.Max(x, y);
            for (int i = 0; i < max; i++)
            {
                result += (i == y ? "\b\bindex" : string.Empty) + "\t";
            }
            return result + max;
        }
    }
}
