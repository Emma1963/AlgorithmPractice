using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    public class LeetCodeString
    {
        /*Remove All Adjacent Duplicates In String*/
        public string RemoveDuplicates(string s)
        {

            for (int i = 0; i < s.Length - 1;)
            {
                if (s[i] == s[i + 1])
                {
                    s = s.Remove(i, 2);
                    if (i != 0)
                    {
                        i = i - 1;
                    }
                }
                else
                {
                    i++;
                }
            }

            return s;
        }

        //Length of Last Word
        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            int length = 0;
            bool begin = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ' && begin == false)
                {
                    continue;
                }

                else if (s[i] == ' ' && begin == true)
                {
                    return length;
                }

                else
                {
                    if (begin == false)
                        begin = true;
                    length += 1;
                }
            }

            return length;
        }

        //Multiply Strings
        public string Multiply(string num1, string num2)
        {
            if (num2 == "0" || num1 == "0")
                return "0";
            if (num1 == "1")
                return num2;
            if (num2 == "1")
                return num1;

            string[] subResult = new string[num2.Length];

            int index = 0;
            // get all the subResult string
            for (int i = num2.Length - 1; i >= 0; i--)
            {
                string sub = "";
                //how many 0 should be 
                for (int j = 0; j < index; j++)
                {
                    sub = sub + "0";
                }

                int extra = 0;
                for (int k = num1.Length - 1; k >= 0; k--)
                {
                    int subMutil = (num1[k] - '0') * (num2[i] - '0') + extra;
                    int currentNumber = subMutil % 10;
                    sub = sub + currentNumber;
                    extra = subMutil / 10;
                }

                if (extra > 0)
                {
                    sub = sub + extra;
                }

                subResult[index] = sub;
                index++;
            }

            string finalResult = subResult[0];
            //get the sum result but from 0 to higher
            for (int i = 1; i < subResult.Length; i++)
            {
                int extra = 0;
                int length = subResult[i].Length <= finalResult.Length ? subResult[i].Length : finalResult.Length;
                for (int j = 0; j < finalResult.Length; j++)
                {
                    if (j == subResult[i].Length)
                    {
                        int number = finalResult[j] - '0' + extra;
                        int currentNumber = number % 10;
                        extra = number / 10;
                        finalResult = updateString(currentNumber, j, finalResult);
                        break;
                    }
                    else
                    {
                        int number = finalResult[j] - '0' + (subResult[i][j] - '0') + extra;
                        int currentNumber = number % 10;
                        extra = number / 10;
                        finalResult = updateString(currentNumber, j, finalResult);
                    }
                }

                if(subResult[i].Length> length)
                {
                    for (int k = length; k < subResult[i].Length; k++)
                    {
                        int number = subResult[i][k] - '0' + extra;
                        int currentNumber = number % 10;
                        extra = number / 10;
                        finalResult=finalResult+currentNumber;
                    }

                }

                if (extra > 0)
                {
                    finalResult = finalResult + extra;
                }

            }

            // converse the order
            string final = "";
            for (int i = finalResult.Length - 1; i >= 0; i--)
            {
                final += finalResult[i];
            }

            return final;

        }

        private string updateString(int num, int index, string original)
        {
            char[] temp = original.ToCharArray();
            temp[index] = char.Parse(num.ToString());
            return new string(temp);
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (letters.ContainsKey(magazine[i]))
                {
                    letters[magazine[i]] += 1;
                }
                else
                {
                    letters.Add(magazine[i], 1);
                }
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (letters.ContainsKey(ransomNote[i]))
                {
                    letters[ransomNote[i]] -= 1;
                    if (letters[ransomNote[i]] <= 0)
                        letters.Remove(ransomNote[i]);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    
        public int GetFirstNodeDuplicate(string s)
        {
            Dictionary<char, int> hash = new Dictionary<char, int>();
            for(int i=0;i<s.Length;i++)
            {
                if(hash.Keys.Contains(s[i]))
                {
                    int number = hash[s[i]];
                    hash[s[i]] = number + 1;
                }
                else
                {
                    hash.Add(s[i], 1);
                }
            }

            for(int i=0;i<s.Length;i++)
            {
                if (hash[s[i]] == 1)
                    return i;
            }
            return -1;
        }

        //get the length of the smallest repeat string
        public int GetRepeat(string s)
        {
            for (int i = 1; i < (s.Length / 2 + 1); i++)
            {
                string subString = s.Substring(0, i);
                string temp = s.Replace(subString, "");
                if (temp.Length == 0)
                    return subString.Length;
            }

            return s.Length;
        }
    }
}
