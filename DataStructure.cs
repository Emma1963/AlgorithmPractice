

using System;
using System.Collections.Generic;

namespace AlgorithmPractice
{
    public class Node
    {
        public int data;

        public Node next;

        public Node previous;

        public Node(int id)
        {
            data = id;
        }
    }

    public class TreeNode
    {
        public int data { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode(int id)
        {
            data = id;
        }

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.data = val;
            this.Left = left;
            this.Right = right;
        }
    }

    public class LinkList
    {
        Node headNode = null;
        public Node Head
        {
            get
            {
                return headNode;
            }
            set
            {
                headNode = value;
            }
        }

        Node current = null;

        public void Add(Node node)
        {
            if (headNode == null)
            {
                headNode = node;
                current = node;
            }

            else
            {
                current.next = node;
                current = node;
            }
        }
    }

    public class BinarySearchTree
    {
        public TreeNode Insert(TreeNode root, int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return root;
            }
            else
            {
                if (value < root.data)
                {
                    root.Left = Insert(root.Left, value);
                }
                else if (value > root.data)
                {
                    root.Right = Insert(root.Right, value);
                }
            }

            return root;
        }
        public class DataStructure
        {
            //Generate Binary Numbers from 1 to n
            public void PrintBinaryNumberByQueue(int n)
            {
                if (n <= 0)
                    return;
                Queue<string> queue = new Queue<string>();
                queue.Enqueue("1");
                for (int i = 0; i < n; i++)
                {
                    var current = queue.Dequeue();
                    Console.WriteLine(current);

                    var temp = current;
                    queue.Enqueue(current + "0");
                    queue.Enqueue(temp + "1");
                }
            }

            //Theorizing an algorithm
            public void PrintTheorizingByStack(int[] array)
            {
                if (array.Length <= 0)
                    return;
                Stack<int> stacks = new Stack<int>();
                stacks.Push(array[0]);
                for (int i = 1; i < array.Length; i++)
                {
                    while (stacks.TryPeek(out var item))
                    {
                        if (array[i] > item)
                        {
                            Console.WriteLine(item + "->" + array[i]);
                            stacks.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }

                    stacks.Push(array[i]);
                }

                while (stacks.TryPeek(out var item))
                {
                    Console.WriteLine(item + "-> -1");
                    stacks.Pop();
                }
            }

            //"(" and ")" match, also can use counter to check
            public bool IsMatchPattern(string s)
            {
                Stack<char> stacks = new Stack<char>();
                foreach (char c in s)
                {
                    if (c == '(')
                    {
                        stacks.Push(c);
                    }
                    else if (c == ')')
                    {
                        if (stacks.Count > 0)
                        {
                            stacks.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                if (stacks.Count > 0)
                    return false;
                else
                    return true;
            }

            public bool IsCycleList(Node head)
            {
                HashSet<int> nodes = new HashSet<int>();
                if (head == null)
                    return false;
                while (head != null)
                {
                    if (nodes.Contains(head.data))
                        return true;
                    else
                    {
                        nodes.Add(head.data);
                        head = head.next;
                    }
                }

                return false;
            }

            public void preOrderTraversal(TreeNode root)
            {
                if (root == null)
                    return;
                Console.Write(root.data + " ");
                if (root.Left != null)
                {
                    preOrderTraversal(root.Left);
                }
                if (root.Right != null)
                {
                    preOrderTraversal(root.Right);
                }
            }

            public void inOrderTraversal(TreeNode root)
            {
                if (root == null)
                    return;
                if (root.Left != null)
                {
                    inOrderTraversal(root.Left);
                }
                Console.Write(root.data + " ");
                if (root.Right != null)
                {
                    inOrderTraversal(root.Right);
                }
            }

            public void postOrderTraversal(TreeNode root)
            {
                if (root == null)
                    return;
                if (root.Left != null)
                {
                    postOrderTraversal(root.Left);
                }
                if (root.Right != null)
                {
                    postOrderTraversal(root.Right);
                }
                Console.Write(root.data + " ");
            }

            public bool Search(TreeNode root, int value)
            {
                if (root == null)
                    return false;
                if (root.data == value)
                    return true;
                else if (root.data > value)
                    return Search(root, value);
                else
                    return Search(root, value);
            }
        }

        enum Graphkind { DG, DN, UDG, UDN }; //{有向图，无向图，有向网，无向网}
        public class Graph
        {
            int[] nodes;
            int edge;
            int[][] adjMatrix;
            Graphkind kind;
        }
    }
}
