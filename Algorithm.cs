using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmPractice
{
    public interface IAlgorithm
    {
        public void Recursion(int number);
    }
    public class Algorithm : IAlgorithm
    {
        public void Recursion(int number)
        {
            Console.WriteLine("number is:" + number);
            if (number == 0)
                return;
            else
                Recursion(number - 1);
        }

        public int CalPower(int number, int pwr)
        {
            if (pwr == 0)
                return 1;
            else
                return number * CalPower(number, pwr - 1);
        }

        public int CalFactorial(int number)
        {
            if (number == 0)
                return 1;
            else
                return number * (number - 1);
        }

        public bool IsAllUpcase(string s)
        {
            return s.All(char.IsUpper);
        }

        public bool IsAllLowcase(string s)
        {
            return s.All(char.IsLower);
        }

        public bool IsPasswordComplex(string s)
        {
            return s.Any(char.IsUpper) && s.Any(char.IsLower) && s.Any(char.IsDigit);
        }





        public string Reverse1(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            else
            {
                StringBuilder builder = new StringBuilder(s.Length);
                foreach (char t in s)
                {
                    builder.Append(t);
                }

                return builder.ToString();
            }
        }
        public string Reverse2(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            else
            {
                char[] array = s.ToCharArray();
                Array.Reverse(array);

                return new string(array);
            }
        }

        public string ReversePerWord(string s)
        {
            StringBuilder builder = new StringBuilder(s.Length);
            if (string.IsNullOrEmpty(s))
                return "";
            string temp = "";

            foreach (char c in s)
            {
                if (c == ' ')
                {
                    builder.Append(Reverse2(temp) + ' ');
                    temp = "";
                }
                else
                {
                    temp += c;
                }
            }

            builder.Append(Reverse2(temp) + ' ');

            return builder.ToString();
        }

        //一个数的全部因子
        public IList<int> GetNumbers(int number)
        {
            IList<int> numbers = new List<int>();
            numbers.Add(1);
            if (number != 1)
                numbers.Add(number);
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    numbers.Add(i);
                    if (i * i != number)
                    {
                        numbers.Add(number / i);
                    }
                }
            }

            return numbers;
        }
        //最大公约数，(a,b)=(a,ka+b)
        //so (74,14)=(60,14)=(46,14)=(32,14)=(18,14)=(4,14)=(10,4)=(6,4)=(2,4)=(2,2)=(0,2)
        //also can divide/2 first to make it easier
        public int GetGCD(int[] list, int number)
        {
            if (number == 1)
                return list[0];
            else
            {
                int gcd = GCDForTwo(list[0], list[1]);
                if (gcd == 1)
                    return 1;
                for (int i = 2; i < number; i++)
                {

                    gcd = GCDForTwo(list[i], gcd);
                    if (gcd == 1)
                        return 1;
                }

                return gcd;
            }
        }


        private int GCDForTwo(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            if (a < 0 || b < 0)
            {
                return 1;
            }

            else
                return a > 0 ? a : b;
        }

        //最小公倍数
        //a=m*c
        //b=n*c c is gcg
        //(a,b)=m*n*c=a*b/c
        public int GetCommonMutiple(int[] array)
        {
            int gcd = GetGCD(array, array.Length);
            int mutip = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                mutip = mutip * array[i] / gcd;
            }

            return mutip;
        }

        public Node MergeList(Node a, Node b)
        {
            if (a == null)
                return b;
            if (b == null)
                return a;
            if (a == null && b == null)
                return null;
            Node head = new Node(0);
            Node tail = head;
            while(true)
            {
                if (a.data < b.data)
                {
                    tail.next = a;
                    a = a.next;
                    tail = tail.next;
                }
                else
                {
                    tail.next = b;
                    b = b.next;
                    tail = tail.next;
                }

                if(a==null)
                {
                    tail.next = b;
                    break;
                }

                if(b==null)
                {
                    tail.next = a;
                    break;
                }
            }

            return head.next;
        }

        /*Given an algebraic string ( ex. "22.5*n-1.5/4") and a result (ex. 14). Return the value of n as a double with 4
         * points of precision. I must say for a 1 hour challenge with 2 other questions this seemed unfair. You essentially '
         * have to write a parser.*/

        //public double GetN(string format, double result)
        //{
        //    Stack<string> sysmbles = new Stack<string>();
        //    double left = 0.0000;
        //    double right = 0.0000;
        //    string symble = "";


        //    string number = "";
        //    for (int i = 0; i < format.Length; i++)
        //    {
        //        if (IsSymble(format[i].ToString()))
        //        {

        //            if (FirstOperation(sysmbles.Peek()))
        //            {
        //                if (number == "n")
        //                {
        //                    sysmbles.Push(number);
        //                    continue;
        //                }
        //                right = double.Parse(number.ToString());
        //                symble = sysmbles.Pop();
        //                if (sysmbles.Peek() == "n")
        //                {
        //                    sysmbles.Push(symble);
        //                    sysmbles.Push(number);
        //                    continue;
        //                }
        //                left = double.Parse(sysmbles.Pop());

        //                double tempResult = 0;
        //                switch (symble)
        //                {
        //                    case "*":
        //                        {
        //                            tempResult = left * right;
        //                            sysmbles.Push(tempResult.ToString());
        //                            break;
        //                        }

        //                    case "/":
        //                        {
        //                            tempResult = left / right;
        //                            sysmbles.Push(tempResult.ToString());
        //                            break;
        //                        }
        //                    default:
        //                        break;
        //                }
        //            }

        //            else
        //            {
        //                sysmbles.Push(number);
        //                sysmbles.Push(format[i].ToString());
        //                number = "";
        //            }
        //        }
        //        else
        //        {
        //            number += format[i];
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(number))
        //    {
        //        sysmbles.Push(number);
        //    }

        //    string leftResult = "";
        //    string symbleResult = "";
        //    string rightResult = "";
        //    while (sysmbles.Count > 0)
        //    {
        //        right = result;
        //        if (!IsSymble(sysmbles.Peek()))
        //        {
        //            left = double.Parse(sysmbles.Pop());
        //            continue;
        //        }
        //        else
        //        {
        //            if(FirstOperation(sysmbles.Peek()))
        //            {
        //                symbleResult = sysmbles.Pop();
        //                leftResult = sysmbles.Pop();
        //                rightResult = left.ToString();
        //            }


        //        }
        //    }

        //}

        private bool IsSymble(string item)
        {
            if (!string.IsNullOrEmpty(item) && (item == "*" || item == "+" || item == "-" || item == "/"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool FirstOperation(string item)
        {
            if (item == "*" || item == "/")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class SortAlgorithm
    {
        public void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int counts = array.Length - 1 - i;
                for (int j = 0; j < counts; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (right + left) / 2;// should left+(right-left)/2
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, right, middle);
            }
        }

        private void Merge(int[] array, int leftIndex, int rightIndex, int middle)
        {
            int length = rightIndex - leftIndex + 1;
            int[] tempArray = new int[length];
            int k = 0;
            for (int i = leftIndex, j = middle + 1; ;)
            {
                if (i > middle && j > rightIndex)
                    break;
                if (i > middle && j <= rightIndex)
                {
                    tempArray[k] = array[j];
                    j++;
                    k++;
                    continue;
                }

                if (i <= middle && j > rightIndex)
                {
                    tempArray[k] = array[i];
                    i++;
                    k++;
                    continue;
                }

                if (array[i] <= array[j])
                {
                    tempArray[k] = array[i];
                    i++;
                    k++;
                }

                else
                {
                    tempArray[k] = array[j];
                    j++;
                    k++;
                }
            }

            k = 0;
            for (int i = leftIndex; i <= rightIndex; i++, k++)
            {
                array[i] = tempArray[k];
            }
        }

        public void QuickSort(int[] array, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            int temp = array[low];
            int less = low;
            int more = high;


            while (less < more)
            {
                while (more > less)
                {
                    if (array[more] >= temp)
                    {
                        more--;
                    }
                    else
                    {
                        break;
                    }
                }

                while (less < more)
                {
                    if (array[less] <= temp)
                    {
                        less++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (array[less] > temp && array[more] < temp)
                {
                    int t = array[less];
                    array[less] = array[more];
                    array[more] = t;
                }
            }

            array[low] = array[less];
            array[less] = temp;

            QuickSort(array, low, less - 1);
            QuickSort(array, less + 1, high);
        }

        public void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        int temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        //基数排序  int[] array = new int[] { 20, 8, 19, 56, 6111,123, 87, 9, 49};
        public void RadixSort(int[] array)
        {
            List<List<int>> buckets = new List<List<int>>();
            for (int i = 0; i < 10; i++)
            {
                buckets.Add(new List<int>());
            }

            int maxLength = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].ToString().Length > maxLength)
                {
                    maxLength = array[i].ToString().Length;
                }
            }

            for (int j = 0; j < maxLength; j++)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    int temp = array[k] / (int)Math.Pow(10, j);
                    int index = temp % 10;
                    if (index > 9)
                        index = 0;
                    buckets[index].Add(array[k]);
                }

                int indexForArray = 0;
                for (int i = 0; i < 10; i++)
                {
                    foreach (int li in buckets[i])
                    {
                        array[indexForArray] = li;
                        {
                            indexForArray++;
                        }
                    }

                    buckets[i].Clear();
                }

            }
        }

        //桶排序
        public void BucketSort()
        {
            //1. set the datas to different bucket by some rule(need all data are int or all data are decimal)
            //2. sort each bucket
            //3. as sequence set the datas back to array
        }

        public void ShellSort(int[] array)
        {
            int gap = array.Length / 2;
            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    int j = 1;
                    while ((i - gap * j) >= 0)
                    {
                        if (array[i - gap * j] > array[i - gap * (j - 1)])
                        {
                            int temp = array[i - gap * j];
                            array[i - gap * j] = array[i - gap * (j - 1)];
                            array[i - gap * (j - 1)] = temp;
                        }
                        j++;
                    }
                }
                gap = gap / 2;
            }
        }

        public void HeapSort(int[] array)
        {
            BuildMaxHeapFirstTime(array);
            for (int i = array.Length - 1; i > 0; i--)
            {
                Swap(ref array[0], ref array[i]);
                MaxHeapForOneNode(array, 0, i);
            }
        }

        //heapsize is the last index of the array need to be sorted, the last ones already sorted
        private void MaxHeapForOneNode(int[] array, int index, int heapSize)
        {
            int large = array[index];
            int largeIndex = index;
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            if (leftChildIndex < heapSize && array[leftChildIndex] > large)
            {
                large = array[leftChildIndex];
                largeIndex = leftChildIndex;
            }
            if (rightChildIndex < heapSize && array[rightChildIndex] > large)
            {
                large = array[rightChildIndex];
                largeIndex = rightChildIndex;
            }

            if (largeIndex != index)
            {
                Swap(ref array[largeIndex], ref array[index]);
                MaxHeapForOneNode(array, largeIndex, heapSize);
            }
        }

        private void BuildMaxHeapFirstTime(int[] array)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeapForOneNode(array, i, array.Length);
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }

    public class SearchAlgorithm
    {
        public int SearchElemetnInArray(int[] array, int item)
        {
            //int s= Array.Find(array, elementT => elementT == item);
            Array.ForEach(array, Console.WriteLine);

            // here is one issue, if item is 0, return 0, can't figer out exist or not
            int s = Array.Find(array, element => Function(element, item));
            // or use loop to find
            return s;
        }

        private bool Function(int element, int item)
        {
            if (item == element && item != 0)
                return true;
            else
                return false;

        }

        public bool BinarySearch(int[] array, int item)
        {
            // Array.BinarySearch(array, item);
            if (array.Length == 1)
            {
                if (array[0] == item)
                    return true;
                else
                    return false;
            }

            int min = 0;
            int max = array.Length - 1;
            while (min <= max)
            {
                int index = (max + min) / 2;
                if (array[index] > item)
                {
                    max = index - 1;
                }
                else if (array[index] < item)
                {
                    min = index + 1;
                }
                else
                {
                    return true;
                }

            }

            return false;
        }

        public void ReverseArray(int[] array)
        {
            int end = array.Length / 2;
            if (array.Length <= 1)
                return;

            for (int i = 0; i < end; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = temp;
            }
        }

        public void LeftMoveArray(int[] array)
        {
            if (array.Length <= 1)
                return;
            for (int i = 1; i < array.Length; i++)
            {
                Swap(ref array[i], ref array[i - 1]);
            }
        }

        public void RightMoveArray(int[] array)
        {
            if (array.Length <= 1)
                return;
            for (int i = array.Length - 2; i >= 0; i--)
            {
                Swap(ref array[i], ref array[i + 1]);
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public int InterpolationSearch(int[] array, int left, int right, int value)
        {

            if (left > right || value < array[0] || value > array[array.Length - 1])
                return -1;


            int midIndex = left + (right - left) * (value - array[left]) / (array[right] - array[left]);

            if (value > array[midIndex])
            {
                return InterpolationSearch(array, midIndex + 1, right, value);
            }

            else if (value < array[midIndex])
            {
                return InterpolationSearch(array, left, midIndex - 1, value);
            }

            return midIndex;
        }

        public int FibonacciSearch(int[] array, int value)
        {
            int maxSize = 20;// depends on the array size
            int[] f = Fibonacci(maxSize);
            int k = 0;
            int low = 0;
            int high = array.Length - 1;
            while (array.Length > f[k] - 1)
            {
                ++k;
            }

            int[] temp = new int[f[k] - 1];
            for (int i = 0; i < (f[k] - 1); i++)
            {
                if (i >= array.Length)
                {
                    temp[i] = -5;
                }
                else
                {
                    temp[i] = array[i];
                }
            }

            while (low <= high)
            {
                int mid = low + f[k - 1] - 1;
                if (value < temp[mid])
                {
                    high = mid - 1;
                    k--;
                }
                else if (value > temp[mid])
                {
                    low = mid + 1;
                    k -= 2;
                }

                else
                {
                    if (mid < array.Length)
                        return mid;
                    else
                        return -1;
                }
            }

            return -1;
        }

        private int[] Fibonacci(int maxSize)
        {
            int[] f = new int[maxSize];
            f[0] = 1;
            f[1] = 1;
            for (int i = 2; i < maxSize; i++)
            {
                f[i] = f[i - 1] + f[i - 2]
    ;
            }

            return f;
        }
    }

    public class ArrangementAlgorithm
    {
        int count = 0;
        public void ArrangementAlgorithmAll(int[] list)
        {
            ArrangementAlgorithmItem(list, 0);
            Console.WriteLine(count);
        }

        private void ArrangementAlgorithmItem(int[] list, int index)
        {
            if (index == list.Length)
            {
                count++;
                PrintList(list);
                return;
            }
            for (int i = index; i < list.Length; i++)
            {
                Swap(index, i, list);
                ArrangementAlgorithmItem(list, index + 1);
                Swap(index, i, list);
            }
        }

        private void Swap(int indexLeft, int indexRight, int[] list)
        {
            int temp = list[indexLeft];
            list[indexLeft] = list[indexRight];
            list[indexRight] = temp;
        }

        private void PrintList(int[] list)
        {
            foreach (var i in list)
            {
                Console.Write(i + ",");
            }

            Console.WriteLine();
        }
    }
}
