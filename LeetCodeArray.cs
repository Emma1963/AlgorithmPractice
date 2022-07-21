using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    public class LeetCodeArray
    {
        //Find All Duplicates in an Array 422
        public IList<int> FindDuplicates(int[] nums)
        {

            IList<int> results = new List<int>();
            if (nums.Length == 1)
                return results;

            for (int i = 0; i < nums.Length; i++)
            {
                int location = Math.Abs(nums[i]) - 1;
                if (nums[location] < 0)
                {
                    results.Add(Math.Abs(nums[i]));
                }
                else
                {
                    nums[location] = -nums[location];
                }
            }

            return results;
        }

        //Maximum Subarray
        public int MaxSubArray(int[] nums)
        {

            int maxValue = nums[0];
            int beforeI = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                beforeI = beforeI + nums[i];
                if (beforeI < nums[i])
                {
                    beforeI = nums[i];
                    if (maxValue < nums[i])
                    {
                        maxValue = nums[i];
                    }
                }
                else
                {
                    if (maxValue < beforeI)
                    {
                        maxValue = beforeI;
                    }
                }

            }

            return maxValue;

        }

        //Plus One
        public int[] PlusOne(int[] digits)
        {
            int lastIndex = digits.Length - 1;
            digits[lastIndex] += 1;
            int maxValue = 0;
            for (int i = lastIndex; i >= 0; i--)
            {
                if (digits[i] > 9)
                {
                    digits[i] = digits[i] - 10;
                    if (i > 0)
                    {
                        digits[i - 1] = digits[i - 1] + 1;
                    }
                    else
                    {
                        maxValue = 1;
                    }
                }
                else
                {
                    return digits;
                }
            }

            if (maxValue > 0)
            {
                int[] result = new int[lastIndex + 2];
                result[0] = maxValue;
                for (int i = 1; i < result.Length; i++)
                {
                    result[i] = digits[i - 1];
                }

                return result;
            }

            return new int[] { };
        }
        /*75. Sort Colors*/
        public void SortColors(int[] nums)
        {
            int index0 = 0, index2 = nums.Length - 1;
            int indexCurrent = 0;
            while (indexCurrent <= index2)
            {
                if (nums[indexCurrent] == 0)
                {
                    Swap(index0, indexCurrent, nums);
                    index0++;
                    indexCurrent++;
                }

                else if (nums[indexCurrent] == 2)
                {
                    Swap(index2, indexCurrent, nums);
                    index2--;
                }
                else
                {
                    indexCurrent++;
                }
            }


        }

        private void Swap(int i, int j, int[] nums)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        /*402. Remove K Digits*/
        public string RemoveKdigits(string num, int k)
        {
            if (k >= num.Length)
                return "0";
            int removeCount = 0;
            Stack<int> result = new Stack<int>();
            result.Push(num[0] - '0');
            for (int i = 1; i < num.Length; i++)
            {
                int current = num[i] - '0';
                while ((removeCount < k) && result.Count > 0 && result.Peek() > current)
                {
                    result.Pop();
                    removeCount++;
                }

                result.Push(current);
            }


            if (removeCount < k)
            {
                while (removeCount < k)
                {
                    result.Pop();
                    removeCount++;
                }
            }

            StringBuilder builder = new StringBuilder();
            while (result.Count > 0)
            {
                builder.Insert(0, result.Pop());
            }

            string finallyResult = builder.ToString().TrimStart('0');
            if (finallyResult == "")
                finallyResult = "0";
            return finallyResult;
        }
    }

    public class MyQueue<T> where T:class
    {
        private Stack<T> input = new Stack<T>();
        private Stack<T> output = new Stack<T>();

        public void EnQueue(T item)
        {
            input.Push(item);
        }

        public T Dequeue()
        { 
            if(output.Count==0)
            {
                while(input.Count!=0)
                {
                    output.Push(input.Pop());
                }
            }

            return output.Pop();
        }

        private int calSum(int x)
        {
            if (x % 2 == 0)
            {
                return x / 2 * (x - 1);
            }
            return (x - 1) / 2 * x;
        }

        /*Pairs of Songs With Total Durations Divisible by 60
         need care about count[0] and count[30] length is even or odd
        because if n is even then (n-1)/2 *2 != (n-1)
        if n is odd n/2*2 != n */
        public int NumPairsDivisibleBy60(int[] time)
        {
            int[] count = new int[60];
            for (int i = 0; i < time.Length; i++)
            {
                int number = time[i] % 60;
                count[number] += 1;
            }

            int result = 0;
            int length = count.Length;
            for (int i = 1; i < 30; i++)
            {
                int j = length - i;
                result += count[i] * count[j];
            }

            if (count[0] > 1)
            {
                result = result + calSum(count[0]);
                //result=result+count[0]*(count[0]-1)/2;
            }
            if (count[30] > 1)
            {
                result = result + calSum(count[30]);
                //result=result+count[30]*(count[30]-1)/2;
            }
            return result;
        }
    }
}
