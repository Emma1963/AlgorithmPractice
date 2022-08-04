using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AlgorithmPractice
{
    public interface R
    {
        int A { get; set; }
        public int GetB();

    }
    public class R1 : R
    {
        private int a;
        public int A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }

        public int GetB()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class T
    {
        public virtual void GetA()
        {
            Console.WriteLine("A");
        }

        public abstract void GetB();

        public void GetC()
        {

        }
    }

    public class S : T
    {
        public override void GetB()
        {
            throw new NotImplementedException();
        }

        public override void GetA()
        {
            base.GetA();
        }

    }

    public class Q:S
    {
        public override void GetA()
        {
            base.GetA();
        }
    }
    public class Medtronic
    {
        //finding closest number to zero in arrays with order
        public int GetClosestNumber(int[] array, int number)
        {
            if (array[0] > number)
                return array[0];
            if (array[array.Length - 1] < number)
                return array[array.Length - 1];

            int left = 0;
            int right = array.Length - 1;
            int middle = (left + right) / 2;
            while (left <= right)
            {
                middle = (left + right) / 2;
                int gap = Math.Abs(array[middle] - number);
                if (gap == 0)
                    return array[middle];

                if (array[middle] > number)
                {
                    if (middle > 0 && array[middle - 1] < number)
                    {
                        return GetMin(array[middle], array[middle - 1], number);
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
                else
                {

                    if (middle < array.Length - 1 && array[middle + 1] > number)
                    {
                        return GetMin(array[middle], array[middle + 1], number);
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
            }

            return array[middle];
        }

        private int GetMin(int a, int b, int c)
        {
            int gapA = Math.Abs(a - c);
            int gapB = Math.Abs(b - c);
            return Math.Min(gapB, gapA);
        }

        //finding closest number to zero in arrays without order
        public int GetClosestNumberNoorder(int[] array, int number)
        {
            if (array == null || array.Length == 0)
                return 0;
            int minGap = Math.Abs(array[0] - number);
            int numberReturn = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                int gap = Math.Abs(array[i] - number);
                if (gap < minGap)
                {
                    minGap = gap;
                    numberReturn = array[i];
                }
            }

            return numberReturn;
        }

        //finding duplicate numbers in integer arrays, array is not just in 1-n
        public int[] FindDuplicateNumber(int[] array)
        {
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < array.Length; i++)
            {
                if (hashtable.Contains(array[i]))
                {
                    int number = (int)hashtable[array[i]];
                    hashtable[array[i]] = number + 1;
                }

                else
                {
                    hashtable.Add(array[i], 1);
                }
            }

            int[] duplicates = new int[] { };
            int j = 0;

            foreach (DictionaryEntry item in hashtable)
            {
                if ((int)item.Value > 1)
                {
                    duplicates[j] = (int)item.Key;
                    j++;
                }
            }

            return duplicates;
        }

        //finding duplicate numbers in integer arrays, array is  in 1-n
        public int[] FindDuplicateNumberN(int[] array)
        {
            int[] duplicates = new int[] { };
            int[] numbers = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int item = array[i];
                numbers[item - 1] = numbers[item - 1] + 1;
            }

            int j = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 1)
                {
                    duplicates[j] = numbers[i];
                    j++;
                }
            }

            return duplicates;
        }

        //finding duplicate numbers in integer arrays, array is  in 1-n Leet422
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

        //Return maximum occurring character in an input string using int
        // if s is null or empty?
        //if s only one character
        // there are two or more character has the same frequnecy
        public char GetMaxomumCharacter(string s)
        {
            if (string.IsNullOrEmpty(s))
                return ' ';
            int ASCIINumber = 255;
            int[] countList = new int[ASCIINumber];
            for (int i = 0; i < s.Length; i++)
            {
                countList[s[i]]++;
            }

            char returnValue = ' ';
            int maxCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (countList[s[i]] > maxCount)
                {
                    maxCount = countList[s[i]];
                    returnValue = s[i];
                }
            }

            return returnValue;
        }

        //parenthesis balancing
        //“[()]{}{[()()]()}”  yes
        //“[(])”  no
        //traverse 遍历,bracket括号
        // starting,closing
        public bool Isblancing(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            Hashtable hashtable = new Hashtable();
            hashtable.Add(']', '[');
            hashtable.Add('}', '{');
            hashtable.Add(')', '(');

            HashSet<char> hashSet = new HashSet<char>();
            hashSet.Add('(');
            hashSet.Add('{');
            hashSet.Add('[');
            Stack<char> datas = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (hashSet.Contains(s[i]))
                {
                    datas.Push(s[i]);
                }

                if(hashtable.Contains(s[i]))
                {
                    char current = datas.Peek();
                    if(current== (char)hashtable[s[i]])
                    {
                        datas.Pop();
                    }

                    else
                    {
                        break;
                    }
                }
            }

            if (datas.Count > 0)
                return false;
            else
                return true;
        }
    }
}
