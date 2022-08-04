using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
public class LeetCodeTrees
{
    public LeetCodeTrees()
    {

    }


    //inorder left,root,right
    //preorder root,left,right
    //postorder left,right,root
    /*Binary Tree Inorder Traversal*/
    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> list = new List<int>();
        if (root != null)
            InorderTraversal(root, list);
        return list;
    }

    private void InorderTraversal(TreeNode root, IList<int> list)
    {
        //left
        if (root.Left != null)
        {
            InorderTraversal(root.Left, list);
        }

        //root
        list.Add(root.data);

        //right
        if (root.Right != null)
        {
            InorderTraversal(root.Right, list);
        }
    }

    /*Unique Binary Search Trees II*/
    public IList<TreeNode> GenerateTrees(int n)
    {
        return GetSubTrees(1, n);
    }

    private IList<TreeNode> GetSubTrees(int left, int right)
    {
        IList<TreeNode> roots = new List<TreeNode>();
        if (left > right)//no node left to construct the sub Tree
        {
            roots.Add(null);
            return roots;
        }

        for (int i = left; i <= right; i++)// use every node as the root
        {
            IList<TreeNode> leftTrees = GetSubTrees(left, i - 1);//get left subTrees
            IList<TreeNode> rightTrees = GetSubTrees(i + 1, right);//get right subTrees
            for (int j = 0; j < leftTrees.Count; j++) //left subtree combine with right subtree
            {
                for (int k = 0; k < rightTrees.Count; k++)
                {
                    TreeNode root = new TreeNode(i);
                    root.Left = leftTrees[j];
                    root.Right = rightTrees[k];
                    roots.Add(root);
                }
            }

        }

        return roots;
    }

        /*Unique Binary Search Trees, just get the number*/
        public int NumTrees(int n)
        {
            int[] cache = new int[n + 1];
            cache[0] = 1;
            cache[1] = 1;
            return GetSubTreeCount(1, n, cache);
        }

        public int GetSubTreeCount(int left, int right, int[] cache)
        {
            if (left > right)
                return cache[0];
            int count = right - left + 1;
            if (cache[count] != 0)
                return cache[count];

            int totalCount = 0;
            for (int i = left; i <= right; i++)
            {
                int leftCount = GetSubTreeCount(left, i - 1, cache);
                int rightCount = GetSubTreeCount(i + 1, right, cache);

                int rootSubTree = leftCount * rightCount;
                totalCount += rootSubTree;
            }

            cache[count] = totalCount;
            return totalCount;
        }

        /*Validate Binary Search Tree*/
        // binary search tree use inorder read is a ascend list
        public bool IsValidBST(TreeNode root)
        {
            IList<int> treeList = new List<int>();
            InputNode(root, treeList);
            for (int i = 0; i < treeList.Count - 1; i++)
            {
                if (treeList[i] >= treeList[i + 1])
                    return false;
            }

            return true;
        }

        private void InputNode(TreeNode root, IList<int> list)
        {
            if (root == null)
                return;
            InputNode(root.Left, list);
            list.Add(root.data);
            InputNode(root.Right, list);
        }

        /*All Possible Full Binary Trees*/
        public IList<TreeNode> AllPossibleFBT(int n)
        {
            IList<TreeNode> list = new List<TreeNode>();
            if (n % 2 == 0)
                return list;
            list = GetSubTree(n);
            return list;

        }

        public IList<TreeNode> GetSubTree(int n)
        {
            IList<TreeNode> tempRoot = new List<TreeNode>();
            if (n == 1)
            {
                TreeNode root = new TreeNode(1);
                tempRoot.Add(root);
                return tempRoot;
            }
            for (int i = 1; i < n - 1; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }

                IList<TreeNode> leftSubTrees = GetSubTree(i);
                IList<TreeNode> rightSubTrees = GetSubTree(n - i - 1);

                for (int j = 0; j < leftSubTrees.Count; j++)
                {
                    for (int k = 0; k < rightSubTrees.Count; k++)
                    {
                        TreeNode root = new TreeNode();
                        tempRoot.Add(root);
                        root.Left = leftSubTrees[j];
                        root.Right = rightSubTrees[k];
                    }
                }
            }

            return tempRoot;
        }

        /*Delete Nodes And Return Forest*/
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            IList<TreeNode> roots = new List<TreeNode>();
            IList<int> deleteNodes = new List<int>();
            for (int i = 0; i < to_delete.Length; i++)
            {
                deleteNodes.Add(to_delete[i]);
            }

            if (ContainNode(deleteNodes, root.data) < 0)
            {
                roots.Add(root);
            }

            DelNode(root, deleteNodes, roots);
            //  roots.Add(root);
            return roots;
        }

        private TreeNode DelNode(TreeNode root, IList<int> deleteNodes, IList<TreeNode> roots)
        {
            if (root == null)
            {
                return null;
            }

            if (deleteNodes.Count == 0)
                return root;

            /*  Console.WriteLine("root"+ root.val);
                   if(root.left!=null)
               Console.WriteLine("left"+ root.left.val);
             else
             {
                 Console.WriteLine("left null before");
             }
              if(root.right!=null)
              Console.WriteLine("right"+ root.right.val);
              else
                  Console.WriteLine("right null before");*/

            root.Left = DelNode(root.Left, deleteNodes, roots);
            root.Right = DelNode(root.Right, deleteNodes, roots);
            /* Console.WriteLine("root"+ root.val);
             if(root.left!=null)
                 Console.WriteLine("left"+ root.left.val);
             else
             {
                   Console.WriteLine("left null");
             }
             if(root.right!=null)
             {
             Console.WriteLine("right"+ root.right.val);
             }
             else
             {
                   Console.WriteLine("right null");
             }
     */
            int returnIndex = ContainNode(deleteNodes, root.data);
            if (returnIndex >= 0)
            {
                //  Console.WriteLine("delete----------------"+ root.val);
                if (root.Left != null)
                    roots.Add(root.Left);
                if (root.Right != null)
                    roots.Add(root.Right);
                deleteNodes.Remove(root.data);
                //root.val=-1;
                return null;
            }
            return root;
        }

        private int ContainNode(IList<int> deleteNodes, int value)
        {
            for (int i = 0; i < deleteNodes.Count; i++)
            {
                if (deleteNodes[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
