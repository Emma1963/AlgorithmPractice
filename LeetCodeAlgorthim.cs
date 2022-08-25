using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmPractice
{
    //only bool does not work because bool default is false not null
    public struct MatrixItem
    {
        public bool isChecked;

        public bool checkResult;
    }

    public class Solution
    {
        /*Meian of Two Sorted Arrays*/
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int medianIndexFirst = (int)((nums1.Length + nums2.Length) / 2);
            int medianIndexAnother = medianIndexFirst;
            if ((nums1.Length + nums2.Length) % 2 == 0)
            {
                medianIndexAnother = medianIndexFirst - 1;
            }

            int finalIndex = 0;
            int j = 0;
            int i = 0;
            double m = 0;//the first
            double n = 0;//the second

            for (; i < nums1.Length || j < nums2.Length;)
            {
                if (i >= nums1.Length)
                {
                    m = n;
                    n = nums2[j];
                    if (medianIndexFirst == finalIndex)
                        break;
                    finalIndex++;
                    j++;
                }
                else if (j >= nums2.Length)
                {
                    m = n;
                    n = nums1[i];
                    if (medianIndexFirst == finalIndex)
                        break;
                    finalIndex++;
                    i++;
                }
                else
                {

                    if (nums1[i] < nums2[j])
                    {
                        m = n;
                        n = nums1[i];
                        if (medianIndexFirst == finalIndex)
                            break;
                        finalIndex++;
                        i++;
                    }
                    else if (nums1[i] == nums2[j])
                    {
                        m = n;
                        n = nums1[i];
                        if (medianIndexFirst == finalIndex)
                            break;
                        finalIndex++;
                        m = n;
                        n = nums2[j];
                        if (medianIndexFirst == finalIndex)
                            break;
                        finalIndex++;
                        j++;
                        i++;

                    }
                    else
                    {
                        m = n;
                        n = nums2[j];
                        if (medianIndexFirst == finalIndex)
                            break;
                        finalIndex++;
                        j++;
                    }
                }
            }

            if (medianIndexFirst == medianIndexAnother)
                return n;
            else
            {
                return (m + n) / 2;
            }

        }

        /*https://www.youtube.com/watch?v=HAA8mgxlov8
        Regular Expression Matching*/
        MatrixItem[,] result;
        public bool IsMatch(string s, string p)
        {
            var sLength = s.Length + 1;
            var pLength = p.Length + 1;
            result = new MatrixItem[sLength, pLength];
            return checkDeep(0, 0, s, p);
        }

        // check s[i] and p[j] and later whether is true
        bool checkDeep(int i, int j, string s, string p)
        {
            if (!result[i, j].isChecked)
            {
                bool ans;
                if (j == p.Length)// p is the end
                {
                    ans = i == s.Length;
                }
                else
                {
                    //if patter[j] is '.' or exactly same then match, but if i is out of s then false
                    bool currentExactlyMatch = (i < s.Length && (s[i] == p[j] || p[j] == '.'));

                    // check whether the follow one is '*'
                    if ((j + 1) < p.Length && p[j + 1] == '*')// follow one is '*'
                    {
                        // check * means 0  or check * means more than 1(check i of s is match and follow like aa and a*)
                        ans = (checkDeep(i, j + 2, s, p)) || (currentExactlyMatch && checkDeep(i + 1, j, s, p));
                    }
                    //follow one is not '*' or current j of p is the end
                    else
                    {
                        ans = currentExactlyMatch && checkDeep(i + 1, j + 1, s, p);
                    }
                }

                result[i, j].checkResult = ans;
                result[i, j].isChecked = true;
                return ans;
            }
            return result[i, j].checkResult;
        }

        /*Two Sum*/
        public int[] TwoSum(int[] nums, int target)
        {
            //here is the first way O(n*n) for time but O(1) for space
            //int[] indexs = new int[2];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    int sub = target - nums[i];

            //    indexs[0] = i;
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (sub == nums[j])
            //        {
            //            indexs[1] = j;
            //            return indexs;
            //        }
            //    }
            //}
            //return null;


            //use hash is the second way O(n) for time but O(n) for space
            Hashtable hashItems = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                int sub = target - nums[i];
                if (hashItems.Contains(sub))
                    return new int[2] { i, (int)hashItems[sub] };
                if (!hashItems.Contains(nums[i]))
                    hashItems.Add(nums[i], i);
            }
            return null;

        }


        /*Longest Substring Without Repeating Characters*/
        public int LengthOfLongestSubstring(string s)
        {

            Dictionary<char, int> itemsMap = new Dictionary<char, int>();
            int length = 0;
            for (int i = 0, j = 0; j < s.Length; j++)
            {
                char currentItem = s[j];
                if (itemsMap.ContainsKey(currentItem))
                {
                    int newStart = itemsMap[currentItem];//new start for the window
                    if (newStart >= i)//if current duplicate letter is in the window,move the start of the window to the index of the letter in the window now
                    {
                        i = newStart + 1;
                    }
                    itemsMap[currentItem] = j;
                }

                else
                {
                    itemsMap.Add(currentItem, j);
                }

                length = Math.Max(length, j - i + 1);// no matter start of the window change or not, length needs to calculate again, like tmmuxzt
            }
            return length;
        }

        /*Longest Palindromic Substring e.g. abccba, aba,bb*/
        public string LongestPalindrome(string s)
        {
            int start = 0; int end = 0;
            for (int i = 0; i < (s.Length - 1); i++)
            {
                int length1 = CalculateLengthOfSub(s, i, i);
                int length2 = CalculateLengthOfSub(s, i, i + 1);
                int len = Math.Max(length1, length2);
                if (len > (end - start + 1))//current subString around center s[i] or s[i]s[j] is longer
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        int CalculateLengthOfSub(string s, int i, int j)
        {
            int L = i;
            int R = j;
            while (L >= 0 && R < s.Length)
            {
                if (s[L] != s[R])
                {
                    break;
                }
                else
                {
                    L--;
                    R++;
                }
            }

            return R - 1 - (L + 1) + 1;// right need back to the equal one and left also
        }

        /* Zigzag Conversion*/
        public string Convert(string s, int numRows)
        {
            string result = "";

            if (numRows == 1)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    result += s[i];
                }
            }
            else
            {
                for (int i = 0; i < numRows; i++)
                {

                    {
                        result = AppendString(s, i, numRows, result);//add the same rowValue
                    }
                }
            }

            return result;
        }

        public string AppendString(string s, int i, int numRows, string result)
        {
            //first find the same row another new site k
            int indexK = i + (numRows + (numRows - 2 * (i + 1)));
            // find the length for very cycle
            int lengthForCycle = numRows * 2 - 2;
            int cycles = 1;
            if (lengthForCycle != 0)
            {
                cycles = s.Length / lengthForCycle;
                if (s.Length % lengthForCycle != 0)
                {
                    cycles += 1;
                }
            }
            for (int j = 0; j < cycles; j++)
            {
                if (i == (numRows - 1) || i == 0)
                {
                    if ((i + lengthForCycle * j) < s.Length)
                    {
                        result += (s[i + lengthForCycle * j]);
                    }
                }
                else
                {
                    if ((i + lengthForCycle * j) < s.Length)
                    {
                        result += (s[i + lengthForCycle * j]);
                    }
                    if ((indexK + lengthForCycle * j) < s.Length && (indexK > 0))
                    {
                        result += (s[indexK + lengthForCycle * j]);
                    }
                }
            }

            return result;
        }

        /*Palindrome Number
         convert int to string*/
        public bool IsPalindrome1(int x)
        {
            string number = x.ToString();
            for (int i = 0, j = number.Length - 1; ; i++, j--)
            {

                if (number[i] != number[j])
                {
                    return false;
                }

                if (i == j || (i + 1) == j)
                {
                    break;
                }
            }

            return true;
        }

        /*Palindrome Number not conver int to string
         revert the number to a new number and check with the left of original
        e.g. 123321 123==321
        12321 12==12
        123111 1113!=12 && 111!=12
        123567 765!=123 && 76!=123*/
        public bool IsPalindrome2(int x)
        {
            /* no conver to string*/

            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }
            int revertNumber = 0;
            while (x > revertNumber)
            {
                revertNumber = revertNumber * 10 + x % 10;
                x = x / 10;
            }

            if (x == revertNumber || revertNumber / 10 == x)
                return true;
            else
                return false;
        }

        /* Roman to Integer*/
        public int RomanToInt(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);

            int result = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (i == (s.Length - 1))
                {
                    result += map[s[i]];
                }
                else
                {
                    if (map[s[i]] < map[s[i + 1]])
                    {
                        result -= map[s[i]];
                    }
                    else
                    {
                        result += map[s[i]];
                    }
                }
            }

            return result;
        }

        /*Reverse Integer*/
        public int Reverse(int x)
        {
            int flag = 1;
            int maxValueLow = int.MaxValue % 10;
            int maxValueHigh = int.MaxValue / 10;
            int minValueLow = int.MinValue % 10;
            int minValueHigh = int.MinValue / 10;
            if (x < 0)
            {
                flag = -1;
            }

            int result = 0;

            while (x != 0)
            {
                int value = x % 10;
                if (flag > 0)// positive
                {
                    //2 power 31 - 1
                    if (result > maxValueHigh || (result == maxValueHigh && value > maxValueLow))
                        return 0;
                }
                //-2 power 31
                if (flag < 0)//negative
                {
                    if (result < minValueHigh || (result == minValueHigh && value < minValueLow))
                        return 0;
                }
                x = x / 10;
                result = result * 10 + value;
            }

            return result;
        }

        /*String to Integer (atoi)*/
        public int MyAtoi(string s)
        {
            int length = s.Length;
            int result = 0;
            int flag = 1;

            int maxValueLow = int.MaxValue % 10;
            int maxValueHigh = int.MaxValue / 10;
            int minValueLow = int.MinValue % 10;
            int minValueHigh = int.MinValue / 10;
            for (int i = 0; i < length; i++)
            {
                if (s[i] == ' ')
                    continue;

                if (i < (length - 1) && Char.IsDigit(s[i + 1]) && s[i] == '-')
                {
                    flag = -1;
                    continue;
                }

                if (!Char.IsDigit(s[i]) && s[i] != '+')
                {
                    break;
                }
                if (Char.IsDigit(s[i]))
                {
                    int value = (s[i] - '0') * flag;

                    if (flag > 0 && (result > maxValueHigh || (result == maxValueHigh && value > maxValueLow)))
                    {
                        result = int.MaxValue;
                        return result;
                    }
                    if (flag < 0 && (result < minValueHigh || (result == minValueHigh && value < minValueLow)))
                    {
                        result = int.MinValue;
                        return result;
                    }
                    result = result * 10 + value;
                }
                if (i < (length - 1) && !Char.IsDigit(s[i + 1]))
                    break;

            }

            return result;
        }

        /*Container With Most Water*/
        public int MaxArea(int[] height)
        {
            int max = Math.Min(height[0], height[height.Length - 1]) * (height.Length - 1);
            for (int i = 0, j = height.Length - 1; i < j;)
            {
                int newValue = Math.Min(height[i], height[j]) * (j - i);
                if (newValue > max)
                {
                    max = newValue;
                }

                if (height[i] > height[j])
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }
            return max;
        }

        /*Longest Common Prefix*/
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length < 1)
                return "";
            if (strs.Length == 1)
                return strs[0];
            string commPrefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                string current = strs[i];
                int size = Math.Min(current.Length, commPrefix.Length);
                if (size != commPrefix.Length)
                {
                    commPrefix = commPrefix.Substring(0, size);
                }
                for (int j = 0; j < size; j++)
                {
                    if (commPrefix[j] == current[j])
                    {
                        continue;
                    }

                    else
                    {
                        commPrefix = commPrefix.Substring(0, j);
                        break;
                    }
                }

                if (commPrefix == "")
                {
                    break;
                }
            }

            return commPrefix;
        }

   

        /*Integer to Roman*/
        public string IntToRoman(int num)
        {
            Dictionary<int, string> map = new Dictionary<int, string>();
            map.Add(1000, "M");
            map.Add(900, "CM");
            map.Add(500, "D");
            map.Add(400, "CD");
            map.Add(100, "C");
            map.Add(90, "XC");
            map.Add(50, "L");
            map.Add(40, "XL");
            map.Add(10, "X");
            map.Add(9, "IX");
            map.Add(5, "V");
            map.Add(4, "IV");
            map.Add(1, "I");
            string result = "";
            foreach (var key in map.Keys)
            {
                int size = num / key;
                if (size > 0)
                {
                    for (int j = 0; j < size; j++)
                    {
                        result += map[key];
                        num -= key;
                    }
                }
            }

            return result;
        }

        /* 3Sum*/
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            HashSet<string> set = new HashSet<string>();
            if (nums.Length < 3)
                return result;

            nums = sortArray(nums);
            for (int i = 0; nums[i] <= 0 && i < (nums.Length - 2); i++)
            {
                for (int j = i + 1, k = nums.Length - 1; k > j;)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        IList<int> item = new List<int>();
                        item.Add(nums[i]);
                        item.Add(nums[j]);
                        item.Add(nums[k]);
                        string key = item[0] + "," + item[1] + "," + item[2];
                        if (!set.Contains(key))
                        {
                            result.Add(item);
                            set.Add(key);
                        }
                        k--;
                        j++;
                    }

                    else if (sum > 0)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return result;
        }

        private int[] sortArray(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (nums[j] < nums[j - 1])
                    {
                        int temp = nums[j];
                        nums[j] = nums[j - 1];
                        nums[j - 1] = temp;
                    }
                }
            }

            return nums;
        }

        /*3Sum Closest*/
        public int ThreeSumClosest(int[] nums, int target)
        {

            int result = nums[0] + nums[1] + nums[nums.Length - 1];
            nums = InserSort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1, k = nums.Length - 1; j < k;)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (target > sum)
                    {
                        j++;
                        if (Math.Abs(target - result) > Math.Abs(target - sum))
                        {
                            result = sum;
                        }
                    }
                    else if (target < sum)
                    {
                        k--;
                        if (Math.Abs(target - result) > Math.Abs(target - sum))
                        {
                            result = sum;
                        }
                    }
                    else
                    {
                        return target;
                    }
                }
            }

            return result;
        }

        public int[] InserSort(int[] arrays)
        {
            for (int i = 1; i < arrays.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arrays[j] < arrays[j - 1])
                    {
                        int temp = arrays[j];
                        arrays[j] = arrays[j - 1];
                        arrays[j - 1] = temp;
                    }
                }
            }

            return arrays;
        }

        /*Letter Combinations of a Phone Number*/
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
                return new List<string>();
            Dictionary<int, char[]> dictionarys = GetDictionary();
            IList<string> list = new List<string>();


            list = FindString(digits, list, dictionarys, "");
            return list;
        }

        public IList<string> FindString(string digits, IList<string> list, Dictionary<int, char[]> dictionarys, string preString)
        {
            int number = digits[0] - '0';
            char[] listChars = dictionarys[number];

            if (digits.Length == 1)
            {
                for (int i = 0; i < listChars.Length; i++)
                {
                    list.Add(preString + listChars[i]);
                }

                return list;
            }

            for (int i = 0; i < listChars.Length; i++)
            {
                FindString(digits.Substring(1, digits.Length - 1), list, dictionarys, preString + listChars[i]);
            }

            return list;
        }


        private Dictionary<int, char[]> GetDictionary()
        {
            Dictionary<int, char[]> dictionarys = new Dictionary<int, char[]>();
            dictionarys.Add(2, new char[] { 'a', 'b', 'c' });
            dictionarys.Add(3, new char[] { 'd', 'e', 'f' });
            dictionarys.Add(4, new char[] { 'g', 'h', 'i' });
            dictionarys.Add(5, new char[] { 'j', 'k', 'l' });
            dictionarys.Add(6, new char[] { 'm', 'n', 'o' });
            dictionarys.Add(7, new char[] { 'p', 'q', 'r', 's' });
            dictionarys.Add(8, new char[] { 't', 'u', 'v' });
            dictionarys.Add(9, new char[] { 'w', 'x', 'y', 'z' });
            return dictionarys;
        }

        /*4Sum*/
        public IList<IList<int>> FourSum(int[] nums, int target)
        {

            if (nums.Length < 4)
                return new List<IList<int>>();
            MergeSort(nums, 0, nums.Length - 1);
            HashSet<string> set = new HashSet<string>();

            IList<IList<int>> list = new List<IList<int>>();
            KSum(nums, target, 0, nums.Length - 1, ref set, "", 4);

            foreach (var sumItem in set)
            {
                IList<int> item = new List<int>();
                string[] items = sumItem.Split(",");
                for (int j = 0; j < items.Length; j++)
                {
                    item.Add(int.Parse(items[j]));
                }

                list.Add(item);
            }

            return list;
        }


        void KSum(int[] nums, int target, int left, int right, ref HashSet<string> set, string pre, int k)
        {
            if (k == 2)
            {
                TwoSum(nums, target, left, right, ref set, pre);
                return;
            }

            else
            {
                for (int i = left; i <= right; i++)
                {

                    var perTemp = "";
                    if (pre == "")
                    {
                        perTemp = "" + nums[i];
                    }
                    else
                    {
                        perTemp = pre + "," + nums[i];
                    }

                    KSum(nums, target - nums[i], i + 1, right, ref set, perTemp, k - 1);
                }
            }
        }


        void TwoSum(int[] nums, int target, int left, int right, ref HashSet<string> set, string pre)
        {
            for (int i = left, j = right; i < j;)
            {
                int sum = nums[i] + nums[j];
                if (sum < target)
                {
                    i++;
                }
                else if (sum > target)
                {
                    j--;
                }
                else
                {
                    string itemString = pre + "," + nums[i] + "," + nums[j];
                    if (!set.Contains(itemString))
                    {
                        set.Add(itemString);
                    }

                    i++;
                    j--;
                }
            }
        }



        private void MergeSort(int[] nums, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(nums, left, middle);
                MergeSort(nums, middle + 1, right);
                Merge(nums, left, right, middle);
            }
        }

        private void Merge(int[] nums, int left, int right, int middle)
        {
            int length = right - left + 1;
            int[] array = new int[length];
            int k = 0;
            for (int i = left, j = middle + 1; ;)
            {
                if (i > middle && j > right)
                    break;
                if (i > middle && j <= right)
                {
                    array[k] = nums[j];
                    j++;
                    k++;
                    continue;
                }

                if (i <= middle && j > right)
                {
                    array[k] = nums[i];
                    i++;
                    k++;
                    continue;
                }

                if (nums[i] <= nums[j])
                {
                    array[k] = nums[i];
                    i++;
                    k++;
                }
                else
                {
                    array[k] = nums[j];
                    j++;
                    k++;
                }
            }

            k = 0;
            for (int i = left; i <= right; i++)
            {
                nums[i] = array[k];
                k++;
            }
        }

        /*Valid Parentheses*/
        public bool IsValid(string s)
        {
            if (s.Length < 2)
                return false;
            if (s.Length % 2 != 0)
                return false;
            Dictionary<char, char> dic = new Dictionary<char, char>();
            dic.Add('(', ')');
            dic.Add('{', '}');
            dic.Add('[', ']');
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    var current = s[i];
                    if (stack.Count > 0)
                    {
                        var matchItem = stack.Pop();
                        if (dic[matchItem] == current)
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (stack.Count == 0)
                return true;
            else
                return false;
        }

 

        /*Generate Parentheses*/
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            AddParentheses(0, 0, ref result, "", n);
            return result;
        }

        private void AddParentheses(int open, int close, ref IList<string> result, string currentString, int n)
        {
            if (open == n && open == close)
            {
                result.Add(currentString);
                return;
            }

            if (close > open || open > n || close > n)
            {
                return;
            }

            if (open == close)// already match
            {
                currentString = currentString + "(";
                AddParentheses(open + 1, close, ref result, currentString, n);
            }
            else if (open > close)
            {
                string temp = currentString + "(";
                AddParentheses(open + 1, close, ref result, temp, n);
                temp = currentString + ")";
                AddParentheses(open, close + 1, ref result, temp, n);
            }
        }
   
        /*Remove Duplicates from Sorted Array*/
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int i = 0;
            for (int j = 0; j < (nums.Length - 1);)
            {
                if (nums[j + 1] == nums[j])
                {
                    j++;
                }
                else
                {
                    i++;
                    nums[i] = nums[j + 1];
                    j++;
                }
            }

            return i + 1;
        }

 

        /*Remove Element*/
        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;
            int left = 0;
            int right = nums.Length - 1;
            int countVal = 0;
            while (true)
            {
                if (left > right)
                {
                    break;
                }

                if (nums[right] == val)
                {
                    countVal++;
                    right--;
                }
                else
                {
                    if (nums[left] == val)
                    {
                        int temp = nums[right];
                        nums[right] = nums[left];
                        nums[left] = temp;
                        left++;
                        right--;
                        countVal++;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            return nums.Length - countVal;
        }

        /*28. Implement strStr()*/
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;
            if (needle.Length > haystack.Length)
                return -1;
            int endStart = haystack.Length - needle.Length + 1;
            bool find = false;
            for (int i = 0; i < endStart; i++)
            {
                int check = i;
                for (int j = 0; j < needle.Length; j++)
                {
                    if (haystack[check] == needle[j])
                    {
                        if (j == (needle.Length - 1))
                        {
                            find = true;
                        }
                        else
                        {
                            check++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (find)
                    return i;
            }

            return -1;
        }

        /*Divide Two Integers*/
        public int Divide(int dividend, int divisor)
        {
            long dividendLong = dividend;
            long divisorLong = divisor;
            int flag = 1;
            if (dividendLong > 0 && divisorLong < 0)
            {
                flag = -1;
                divisorLong = Math.Abs(divisorLong);
            }

            else if (dividendLong < 0 && divisorLong > 0)
            {
                flag = -1;
                dividendLong = Math.Abs(dividendLong);
            }

            else if (dividendLong < 0 && divisorLong < 0)
            {
                divisorLong = Math.Abs(divisorLong);
                dividendLong = Math.Abs(dividendLong);
            }

            long count = DivideStep(dividendLong, divisorLong);
            if (flag < 0)
                count = -count;
            int finalCount = CheckValue(count);

            return finalCount;
        }

        long DivideStep(long dividend, long divisor)
        {
            if (dividend < divisor)
                return 0;
            long maxCount = 1;
            long tempDivisor = divisor;

            while (true)
            {
                if ((dividend - tempDivisor) > 0)
                {
                    tempDivisor = tempDivisor << 1;
                    maxCount = maxCount << 1;
                }
                else if ((dividend - tempDivisor) == 0)
                {

                    return maxCount;
                }
                else
                {
                    tempDivisor = tempDivisor >> 1;
                    maxCount = maxCount >> 1;
                    break;
                }
            }

            dividend = dividend - tempDivisor;
            long count = maxCount + DivideStep(dividend, divisor);
            return count;
        }

        int CheckValue(long value)
        {
            if (value > int.MaxValue)
            {
                return int.MaxValue;
            }

            if (value < int.MinValue)
            {
                return int.MinValue;
            }

            return (int)value;
        }

        /*Substring with Concatenation of All Words*/
        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> resultList = new List<int>();
            Hashtable hashmap = new Hashtable();
            int length = words.Length;
            int wordsLength = words[0].Length;
            int substringLength = length * wordsLength;
            for (int i = 0; i < length; i++)
            {
                if (hashmap.Contains(words[i]))
                {
                    int counter = int.Parse(hashmap[words[i]].ToString());
                    counter += 1;
                    hashmap[words[i]] = counter;
                }
                else
                {

                    hashmap.Add(words[i], 1);
                }
            }

            for (int i = 0; i < (s.Length - substringLength + 1); i++)
            {
                int index = checkVailid(hashmap, s, i, wordsLength, substringLength);
                if (index != -1)
                {
                    resultList.Add(index);
                }
            }
            return resultList;
        }

        int checkVailid(Hashtable map, string s, int start, int wordsLength, int substringLength)
        {
            Hashtable tempMap = new Hashtable(map);
            int count = 0;
            int wordsCount = substringLength / wordsLength;

            for (int i = start; ; i += wordsLength)
            {
                var subString = s.Substring(i, wordsLength);
                if (tempMap.Contains(subString))
                {
                    int counter = int.Parse(tempMap[subString].ToString());
                    counter -= 1;
                    if (counter < 0)
                    {
                        return -1;
                    }
                    tempMap[subString] = counter;
                }
                else
                {
                    return -1;
                }

                count++;
                if (count == wordsCount)
                    break;
            }

            return start;
        }

        /*Permutations
         * in a loop exchange index with everyone, then go to index+1 to do the loop again until got the last one
         */
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            ArrangementAlgorithmItem(nums, 0, list);
            return list;
        }

        private void ArrangementAlgorithmItem(int[] nums, int index, IList<IList<int>> list)
        {
            if (index == nums.Length)
            {
                PrintList(nums, list);
                return;
            }
            for (int i = index; i < nums.Length; i++)
            {
                Swap(index, i, nums);
                ArrangementAlgorithmItem(nums, index + 1, list);
                Swap(index, i, nums);
            }
        }

        private void Swap(int indexLeft, int indexRight, int[] nums)
        {
            int temp = nums[indexLeft];
            nums[indexLeft] = nums[indexRight];
            nums[indexRight] = temp;
        }

        private void PrintList(int[] nums, IList<IList<int>> list)
        {
            IList<int> listItem = new List<int>();
            foreach (var i in nums)
            {
                listItem.Add(i);
            }
            list.Add(listItem);
        }

        /*Next Permutation*/
        public void NextPermutation(int[] nums)
        {

            if (nums.Length == 1)
                return;
            bool isDone = false;
            int index = 0;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])//need adjust
                {
                    index = i;
                    break;
                }

                else
                {
                    if (i == 0)
                    {
                        isDone = true;
                    }
                }
            }

            if (!isDone)//has next permutation
            {
                for (int j = nums.Length - 1; j > index; j--)
                {
                    if (nums[j] > nums[index])
                    {
                        int temp = nums[index];
                        nums[index] = nums[j];
                        nums[j] = temp;
                        break;
                    }
                }

                for (int i = index + 1; i < nums.Length - 1; i++)
                {
                    int countChange = 0;
                    for (int j = nums.Length - 1; j > i; j--)
                    {
                        if (nums[j] < nums[j - 1])
                        {
                            int temp = nums[j];
                            nums[j] = nums[j - 1];
                            nums[j - 1] = temp;
                            countChange++;
                        }
                    }

                    if (countChange == 0)
                        break;
                }
            }

            else if (isDone)//does not have next permutation, rearrange
            {
                for (int i = 0, j = nums.Length - 1; i < j; i++, j--)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }

            return;
        }

        /*Longest Valid Parentheses*/
        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            int maxLength = 0;
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(i);
                else
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }

                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxLength = Math.Max(maxLength, i - stack.Peek());
                    }
                }
            }


            return maxLength;
        }

        /*Search in Rotated Sorted Array*/
        /*need consider left or right== current, different from binarysearch */
        /*4,5,6,7,0,1,2*/
        /*0,1,2,3,4,5,6*/
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 1)
            {
                if (nums[0] == target)
                    return 0;
                else
                    return -1;
            }
            int middleIndex;
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                if (nums[left] == target)
                    return left;
                if (nums[right] == target)
                    return right;
                middleIndex = (right + left) / 2;
                if (nums[middleIndex] == target)
                {
                    return middleIndex;
                }

                if (target > nums[middleIndex])
                {
                    if (nums[left] < nums[middleIndex])
                    {
                        left = middleIndex + 1;
                    }
                    else
                    {
                        if (target > nums[left])
                        {
                            right = middleIndex - 1;
                        }
                        else
                        {
                            left = middleIndex + 1;
                        }
                    }
                }

                else
                {
                    if (nums[left] > nums[middleIndex])
                    {
                        right = middleIndex - 1;
                    }
                    else
                    {
                        if (target > nums[left])
                        {
                            right = middleIndex - 1;
                        }
                        else
                        {
                            left = middleIndex + 1;
                        }
                    }
                }

            }

            return -1;
        }

        /*Search Insert Position*/
        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 1)
            {
                if (nums[0] == target)
                    return 0;
                else if (nums[0] > target)
                    return 0;
                else
                    return 1;
            }

            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (nums[middle] == target)
                {
                    return middle;
                }
                else
                {
                    if (target > nums[middle])
                    {
                        left = middle + 1;
                    }

                    else
                    {
                        right = middle - 1;
                    }
                }
            }

            return left;// if target larger than middle, move left,left should be middle+1; if target smaller than
                        //middle, move right, then left should be target, then middle will go to next
                        // so any case ,left is ok
        }

        /*Valid Sudoku*/
        public bool IsValidSudoku(char[,] board)
        {
            for (int i = 0, j = 0; i < 9 && j < 9; i++, j++)
            {
                HashSet<char> hashset = new HashSet<char>();
                // row
                for (int k = 0; k < 9; k++)
                {
                    if (board[i, k] == '.')
                        continue;
                    if (!hashset.Add(board[i, k]))
                    {
                        return false;
                    }
                }

                hashset = new HashSet<char>();
                //colum
                for (int k = 0; k < 9; k++)
                {
                    if (board[k, j] == '.')
                        continue;
                    if (!hashset.Add(board[k, j]))
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < 9;)
            {
                for (int j = 0; j < 9;)
                {

                    HashSet<char> hashset = new HashSet<char>();
                    for (int p = 0; p < 3; p++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (board[k + i, p + j] == '.')
                                continue;
                            if (!hashset.Add(board[k + i, p + j]))
                            {
                                return false;
                            }
                        }
                    }

                    j += 3;
                }
                i += 3;
            }

            return true;
        }

        /*Combination Sum*/
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Sort(candidates);
            IList<int> current = new List<int>();
            Combination(candidates, target, 0, current, result);
            return result;
        }

        private void Combination(int[] candidates, int target, int begin, IList<int> current, IList<IList<int>> result)
        {
            if (target == 0)
            {
                IList<int> item = new List<int>(current);
                result.Add(item);
                return;
            }

            if (target < 0)
            {
                return;
            }

            for (int i = begin; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                {
                    return;
                }

                current.Add(candidates[i]);
                Combination(candidates, target - candidates[i], i, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }

        /* Combination Sum II*/
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Sort(candidates);
            IList<int> current = new List<int>();
            IList<IList<int>> result = new List<IList<int>>();
            GetCombination(candidates, target, 0, current, result);
            return result;
        }

        private void GetCombination(int[] candidates, int target, int start, IList<int> current, IList<IList<int>> result)
        {
            if (target == 0)
            {
                IList<int> currentCopy = new List<int>(current);
                result.Add(currentCopy);
                return;
            }

            if (target < 0)
                return;

            for (int i = start; i < candidates.Length; i++)
            {
                if (target < candidates[i])
                {
                    return;
                }

                if (i > start && candidates[i] == candidates[i - 1])
                    continue;
                current.Add(candidates[i]);
                GetCombination(candidates, target - candidates[i], i + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }

        }

        private void Sort(int[] candidates)
        {

            for (int i = (candidates.Length - 1); i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (candidates[j] > candidates[j + 1])
                    {
                        int temp = candidates[j];
                        candidates[j] = candidates[j + 1];
                        candidates[j + 1] = temp;
                    }
                }
            }
        }

        /*Count and Say*/
        public string CountAndSay(int n)
        {
            return CountSay(n);
        }

        private string CountSay(int n)
        {
            if (n == 1)
                return "1";
            else
            {
                var sayLast = CountSay(n - 1);
                return say(sayLast);
            }
        }

        private string say(string original)
        {
            string result = "";
            char number = original[0];
            int count = 1;
            for (int i = 1; i < original.Length; i++)
            {
                if (original[i] == number)
                {
                    count++;
                }
                else
                {
                    result = result + count.ToString() + number;
                    number = original[i];
                    count = 1;
                }
            }

            result = result + count.ToString() + number;
            return result;
        }

        /*Sudoku Solver continue go and check valid*/
        public void SolveSudoku(char[,] board)
        {
            SolveSolution(board, 0, 0);
        }

        public bool SolveSolution(char[,] board, int row, int column)
        {

            if (column == 9)
            {
                row += 1;
                column = 0;
            }

            if (row == 9)// all set
            {
                return true;
            }

            if (board[row, column] != '.')
            {
                return SolveSolution(board, row, column + 1);
            }

            for (int i = 1; i < 10; i++)
            {
                board[row, column] = (char)('0' + i);
                if (IsValid(board, row, column))
                {
                    if (SolveSolution(board, row, column + 1))
                    {
                        return true;
                    }
                    else
                    {
                        board[row, column] = '.';
                    }
                }
                else
                {
                    board[row, column] = '.';
                }
            }

            return false;
        }

        private bool IsValid(char[,] board, int row, int column)
        {
            HashSet<char> hashset = new HashSet<char>();
            //row
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] != '.')
                {
                    if (!hashset.Add(board[row, i]))
                    {
                        return false;
                    }
                }
            }

            hashset.Clear();
            //column
            for (int i = 0; i < 9; i++)
            {
                if (board[i, column] != '.')
                {
                    if (!hashset.Add(board[i, column]))
                    {
                        return false;
                    }
                }
            }

            hashset.Clear();
            //subgrid
            int gridRowIndex = row / 3 * 3;
            int gridColumnIndex = column / 3 * 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i + gridRowIndex, j + gridColumnIndex] != '.')
                    {
                        if (!hashset.Add(board[i + gridRowIndex, j + gridColumnIndex]))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /*First Missing Positive*/
        public int FirstMissingPositive(int[] nums)
        {

            if (nums.Length == 1)
            {
                if (nums[0] == 1)
                    return 2;
                else
                    return 1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0 || nums[i] > nums.Length)
                    continue;
                if ((nums[i] - 1) == i)
                    continue;
                else
                {
                    int temp = nums[i];
                    if (nums[temp - 1] == temp)
                        continue;
                    nums[i] = nums[temp - 1];
                    nums[temp - 1] = temp;
                    i--;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                    return i + 1;
                else
                    continue;
            }

            return nums.Length + 1;
        }

        /*Pow(x, n)*/
        public double MyPow(double x, int n)
        {
            return MyPowSub(x, n);
        }

        public double MyPowSub(double x, int n)
        {
            if (n == 0)
                return 1;
            else if (n == 1)
                return x;
            else if (n == -1)
                return 1 / x;
            else
            {
                if (n > 0)
                {
                    if (n % 2 == 0)
                    {
                        double half = MyPowSub(x, n / 2);
                        return half * half;
                    }

                    else
                    {
                        double half = MyPowSub(x, n / 2);
                        return half * half * x;
                    }
                }

                else
                {
                    if (n % 2 == 0)
                    {
                        double half = MyPowSub(x, n / 2);
                        return half * half;
                    }

                    else
                    {
                        double half = MyPowSub(x, n / 2);
                        return half * half / x;
                    }
                }
            }
        }

        /*Trapping Rain Water*/
        public int Trap(int[] height)
        {
            if (height.Length <= 2)
                return 0;
            //total number can be trapped
            int finallyCount = 0;
            //maxLeft
            int maxLeft = height[0];
            //maxRight
            int maxRight = height[height.Length - 1];

            //left point and right point
            for (int left = 1, right = height.Length - 2; left <= right;)
            {
                //if maxleft is smaller than right, no matter how big is the max right later,
                // the min(maxleft,maxright) is maxleft
                if (maxLeft <= maxRight)
                {
                    int heightRule = maxLeft;
                    int current = heightRule - height[left];
                    // only the height of current position is smaller
                    if (current > 0)
                        finallyCount += current;
                    if (maxLeft < height[left])
                    {
                        maxLeft = height[left];
                    }
                    left++;
                }

                else
                {
                    int heightRule = maxRight;
                    int current = heightRule - height[right];
                    // only the height of current position is smaller
                    if (current > 0)
                        finallyCount += current;
                    if (maxRight < height[right])
                    {
                        maxRight = height[right];
                    }
                    right--;
                }
            }

            return finallyCount;
        }


        /*Rotate Image*/
        /*onion methord*/
        public void Rotate(int[][] matrix)
        {
            Rotate(matrix, matrix.Length, 0, matrix.Length - 1);
        }

        private void Rotate(int[][] matrix, int n, int left, int right)
        {
            //if original n is single
            if (n == 1)
                return;
            //if original n is double
            if (n == 0)
                return;

            //deal with the edges
            //[left,i]->[i,right]->[right,right-i]->[right-i,left]->[left,i]
            for (int i = left; i < right; i++)
            {
                int temp = matrix[right - i + left][left];// add offset left
                matrix[right - i + left][left] = matrix[right][right - i + left];
                matrix[right][right - i + left] = matrix[i][right];
                matrix[i][right] = matrix[left][i];
                matrix[left][i] = temp;
            }

            Rotate(matrix, n - 2, left + 1, right - 1);
        }    
    }
}
