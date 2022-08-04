

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static AlgorithmPractice.Solution;

namespace AlgorithmPractice
{
    public struct A
    {
        int a;
        int A1
        {
            get; set;
        }
        public void Gett()
        {
            Console.WriteLine("hi");
        }

        public A(int b)
        {
            a = b;
            A1 = 5;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //NumberExample ne = new NumberExample();
            //ne.TryBigInteger();
            LinkedList<int> li = new LinkedList<int>();
    }

        public void PrintNumber(int number)
        {
            for(int i=1;i<=number;i++)
            {
                bool flagDivThree = false;
                if(i%3==0)
                {
                    flagDivThree = true;
                }

                bool flagDivFive = false;
                if (i%5==0)
                {
                    flagDivFive = true;
                }

                if(flagDivThree && flagDivFive)
                {
                    Console.WriteLine("FizzBuzz");
                }

                else if(flagDivFive)
                {
                    Console.WriteLine("Buzz");
                }

                else if(flagDivThree)
                {
                    Console.WriteLine("Fizz");
                }

                else
                {
                    Console.WriteLine(i);
                }
            }
        }
      
        public bool IsPalindrome(string s)
        {
            int left= 0;
            int right = s.Length - 1;

            while(left<right)
            {
                char leftC = s[left];
                char rightC = s[right];
                if(leftC==rightC)
                {
                    left++;
                    right--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        //  static void Main(string[] args)
        //   {
        //Solution cal = new Solution();
        //int[] a = new int[2] { 1, 3 };
        //int[] b = new int[1] { 2 };
        //double result = cal.FindMedianSortedArrays(a, b);
        ////Console.WriteLine(result);
        //string s = 'aa';
        //string p = 'a*';
        //Console.WriteLine(cal.IsMatch(s, p));
        //string test = 'tmmzuxt';
        //int count=cal.LengthOfLongestSubstring(test);
        //string s = 'AB';
        //cal.Convert(s, 3);
        //string s = 'III';
        //int result=cal.RomanToInt(s);
        //string s = '42';
        //cal.MyAtoi(s);
        //Algorithm al = new Algorithm();
        ////int[] array = new int[] { 20, 8, 19, 56, 6111, 123, 87, 9, 49 };
        //int[] array = new int[] { 15,8,4,10};
        ////int[] arrray = new int[] { 12, 2, 3, 65, 5, 89, 7, 0, 3, 57,3,3,3,0};
        //SearchAlgorithm searchAlgorithm = new SearchAlgorithm();
        ////searchAlgorithm.LeftMoveArray(array);
        ////searchAlgorithm.RightMoveArray(array);
        ////Array.ForEach(array, Console.WriteLine);
        //int t=searchAlgorithm.FibonacciSearch(array,32);

        //DataStructure data = new DataStructure();
        //Console.WriteLine(data.IsMatchPattern('(he('));
        //Console.WriteLine(data.IsMatchPattern(')he('));
        //Console.WriteLine(data.IsMatchPattern(')he('));
        //Console.WriteLine(data.IsMatchPattern('he(('));
        //Console.WriteLine(data.IsMatchPattern('(he'));
        //Console.WriteLine(data.IsMatchPattern('((he)'));
        //Console.WriteLine(data.IsMatchPattern('((he))'));
        //Console.WriteLine(data.IsMatchPattern('(he)'));
        //Console.WriteLine(data.IsMatchPattern('(h)e'));

        //TreeNode t = new TreeNode(5);
        ////t.next = new Node(6);
        //t.next.next = new Node(7);
        // t.next.next.next = null;
        //BinarySearchTree tree = new BinarySearchTree();
        //tree.Insert(t, 6);
        //tree.Insert(t, 20);
        //tree.Insert(t, 2);
        //D2 d = new D2();
        //d.G();
        //d.G2();
        //Console.WriteLine('------');
        //D1 d1 = new D1();
        //d1.G();
        //d1.G2();
        //ListNode[] nodes = new ListNode[3];
        //ListNode node11 = new ListNode(1, null);
        //ListNode node12 = new ListNode(4, null);
        //ListNode node13 = new ListNode(5, null);
        //node11.next = node12;
        //node12.next = node13;


        //ListNode node21 = new ListNode(1, null);
        //ListNode node22 = new ListNode(3, null);
        //ListNode node23 = new ListNode(4, null);
        //node21.next = node22;
        //node22.next = node23;


        //ListNode node31 = new ListNode(2, null);
        //ListNode node32 = new ListNode(6, null);
        //node31.next = node32;
        //nodes[0] = node11;
        //nodes[1] = node21;
        //nodes[2] = node31;

        //cal.MergeKLists(nodes);

        //ListNode node5 = new ListNode(5, null);
        //ListNode node4 = new ListNode(4, node5);
        //ListNode node3 = new ListNode(3, node4);
        //ListNode node2 = new ListNode(2, null);
        //ListNode node1 = new ListNode(1, node2);



        //char[,] board = new char[,] {{ '5', '3', '.', '.', '7', '.', '.', '.', '.' },{ '6', '.', '.', '1', '9', '5', '.', '.', '.' },{ '.', '9', '8', '.', '.', '.', '.', '6', '.' },{ '8', '.', '.', '.', '6', '.', '.', '.', '3' },{ '4', '.', '.', '8', '.', '3', '.', '.', '1' },{ '7', '.', '.', '.', '2', '.', '.', '.', '6' },{ '.', '6', '.', '.', '.', '.', '2', '8', '.' },{ '.', '.', '.', '4', '1', '9', '.', '.', '5' },{ '.', '.', '.', '.', '8', '.', '.', '7', '9' }};
        //cal.SolveSudoku(board);
        // cal.CountAndSay(4);
        //int[] numbers = new int[] {10, 1, 2, 7, 6, 1, 5};
        ////cal.CombinationSum2(numbers, 8);
        //ArrangementAlgorithm algorithm = new ArrangementAlgorithm();
        //algorithm.ArrangementAlgorithmAll(new int[] { 3,5,6});
        ////int[] result=Houses(new int[] { 1, 1, 1, 0, 1, 1, 1, 1}, 2);
        ////Algorithm al = new Algorithm();
        //var t=al.GetCommonMutiple(new int[] { 6,3,27});
        //LeetCodeString leetCodeString = new LeetCodeString();
        //string s= "abbaca";
        //leetCodeString.RemoveDuplicates(s);
        //Medtronic me = new Medtronic();
        //while (true)
        //{
        //    Console.WriteLine("input string");
        //    string s = Console.ReadLine();
        //    if (s == "exit")
        //        break;
        //    Console.WriteLine(me.Isblancing(s));
        //}
        // LeetCodeString t = new LeetCodeString();
        // t.Multiply("123", "456");
        //MyDelegate d = delegate (int a, int b) { return a + b; };
        //d += delegate (int a,int b) { return a; };

        //if (d != null)
        //{
        //    Delegate[] delegates=d.GetInvocationList();
        //    foreach(MyDelegate d1 in delegates)
        //    {
        //        Console.WriteLine(d1(5, 3));
        //    }
        //}

        //Node aHead = new Node(1);
        //Node atail = aHead;
        //atail.next = new Node(2);
        //atail = atail.next;
        //atail.next = new Node(4);

        //Node bHead = new Node(1);
        //Node btail = bHead;
        //btail.next = new Node(3);
        //btail = btail.next;
        //btail.next = new Node(4);

        //Algorithm al = new Algorithm();
        //Node c=al.MergeList(aHead, bHead);

        //while(c!=null)
        //{
        //    Console.Write(c.data+",");
        //    c = c.next;
        //}


        //while (true)
        //{

        //    string s = Console.ReadLine();
        //    if (s == "e")
        //        return;
        //    LeetCodeString a = new LeetCodeString();
        //    var t = a.GetRepeat(s);
        //    Console.WriteLine(t);
        //}

        //if (!typeof(Subteam).IsSubclassOf(typeof(Team)))
        //{
        //    throw new Exception("Subteam class should inherit from Team class");
        //}

        //String str = Console.ReadLine();
        //String[] strArr = str.Split();
        //string initialName = strArr[0];
        //int count = Convert.ToInt32(strArr[1]);
        //Subteam teamObj = new Subteam(initialName, count);
        //Console.WriteLine("Team " + teamObj.teamName + " created");

        //str = Console.ReadLine();
        //count = Convert.ToInt32(str);
        //Console.WriteLine("Current number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
        //teamObj.AddPlayer(count);
        //Console.WriteLine("New number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);


        //str = Console.ReadLine();
        //count = Convert.ToInt32(str);
        //Console.WriteLine("Current number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
        //var res = teamObj.RemovePlayer(count);
        //if (res)
        //{
        //    Console.WriteLine("New number of players in team " + teamObj.teamName + " is " + teamObj.noOfPlayers);
        //}
        //else
        //{
        //    Console.WriteLine("Number of players in team " + teamObj.teamName + " remains same");
        //}

        //str = Console.ReadLine();
        //teamObj.ChangeTeamName(str);
        //Console.WriteLine("Team name of team " + initialName + " changed to " + teamObj.teamName);
        // LinqSolution.Try();
        // Dictionary<TreeNode, int> d = new Dictionary<TreeNode, int>();
        // TreeNode s = new TreeNode();
        // s.data = 8;
        // d.Add(s, 5);

        // TreeNode t = s;

        //bool flag1= d.ContainsKey(s);//true
        // bool flag2 = d.ContainsKey(t);//true
        // bool flag3 = d.ContainsKey(new TreeNode(8));// no

        // Employee e1 = new Employee();
        // e1.Age = 50;
        // e1.Company = "io";
        // e1.FirstName = "9";
        // e1.LastName = "8";

        // Employee e2 = new Employee();
        // e2.Age = 52;
        // e2.Company = "io";
        // e2.FirstName = "92";
        // e2.LastName = "82";

        // Employee e3 = new Employee();
        // e3.Age = 54;
        // e3.Company = "io";
        // e3.FirstName = "93";
        // e3.LastName = "83";

        // Employee e4 = new Employee();
        // e4.Age = 54;
        // e4.Company = "io1";
        // e4.FirstName = "93";
        // e4.LastName = "83";

        // List<Employee> list = new List<Employee>();
        // list.Add(e1);
        // list.Add(e2);
        // list.Add(e3);
        // list.Add(e4);

        // LinqSolution hc = new LinqSolution();
        // hc.AverageAgeForEachCompany(list);
        // hc.CountOfEmployeesForEachCompany(list);
        // hc.OldestAgeForEachCompany(list);

        // list.Sort(CompareEmployee);
        //       int[] a = new int[] { };
        //       a[0] = 8;
        //   }

        public static int CompareEmployee(Employee x,Employee y)
        {
            if(x.Age>y.Age)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public delegate int MyDelegate(int a, int b);

        public static int[] Houses(int[] states,int days)
        {
            for(int i=0;i<days;i++)
            {
                states = GetOnedayState(states);
            }

            return states;
        }

        private static int[] GetOnedayState(int[] states)
        {
            int[] stateTemp = new int[8];
            for(int j=0;j<states.Length;j++)
            {
                if(j==0)
                {
                    stateTemp[j] = states[1] == 1 ? 1 : 0;
                }

                else if(j==(states.Length-1))
                {
                    stateTemp[j] = states[states.Length - 2] == 1 ? 1 : 0;
                }

                else
                {
                    if (states[j - 1] == states[j + 1])
                        stateTemp[j] = 0;
                    else
                        stateTemp[j] = 1;
                }
            }

            return stateTemp;
        }
    }

}
