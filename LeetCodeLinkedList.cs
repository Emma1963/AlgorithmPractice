using System;
using System.Collections.Generic;

namespace AlgorithmPractice
{
    /*
      //* Definition for singly-linked list.*/
    public class ListNode<T>
    {
        public T val;
        public ListNode<T> next;
        public ListNode(T val, ListNode<T> next = null)
        {
            this.val = val;
            this.next = next;
        }
        public ListNode()
        {

        }
    }

    public class HeadItem
    {
        public int val;
        public int listIndex;
    }

    public class LinkListCode
    {
        /*Add Two Numbers*/
        public ListNode<int> AddTwoNumbers(ListNode<int> l1, ListNode<int> l2)
        {
            int flagAddExtra = 0;
            ListNode<int> l1Child = l1;
            ListNode<int> l2Child = l2;
            ListNode<int> returnNode = null;
            ListNode<int> lastNode = null;
            while (l1Child != null || l2Child != null)
            {
                ListNode<int> currentNode = new ListNode<int>();
                if (lastNode == null)//the first node
                {
                    returnNode = currentNode;
                }
                else
                {
                    lastNode.next = currentNode;
                }

                int sum = flagAddExtra;
                if (l1Child != null)
                {
                    sum += l1Child.val;
                    l1Child = l1Child.next;
                }
                if (l2Child != null)
                {
                    sum += l2Child.val;
                    l2Child = l2Child.next;
                }
                int nodeValue = sum % 10;
                flagAddExtra = sum / 10;
                currentNode.val = nodeValue;
                lastNode = currentNode;


            }
            if (flagAddExtra != 0)
            {
                ListNode<int> currentNode = new ListNode<int>();
                lastNode.next = currentNode;
                currentNode.val = flagAddExtra;
            }

            return returnNode;
        }

        /*Remove Nth Node From End of List*/
        public ListNode<int> RemoveNthFromEnd(ListNode<int> head, int n)
        {
            ListNode<int> fast = head;// L is from head the index of the node need to be deleted, L+n equal the nodes count of the list
            ListNode<int> slow = head;// this point that one need to be deleted

            for (int i = 0; i < n; i++)// i can from 1 but later need fast.next.next!=null
            {
                fast = fast.next;
            }

            if (fast == null)//if i from 1 then fast.next!=null
            {
                return head.next;
            }

            while (fast.next != null)//if i from 1 then  fast.next.next!=null
            {
                slow = slow.next;
                fast = fast.next;
            }

            slow.next = slow.next.next;

            return head;
        }

        /*Merge Two Sorted Lists*/
        public ListNode<int> MergeTwoLists(ListNode<int> list1, ListNode<int> list2)
        {
            if (list1 == null && list2 == null)
            {
                return null;
            }

            if (list1 == null && list2 != null)
            {
                return list2;
            }

            if (list1 != null && list2 == null)
            {
                return list1;
            }

            ListNode<int> head = null;
            ListNode<int> current = null;
            while (list1 != null || list2 != null)
            {
                ListNode<int> currentItem = new ListNode<int>();
                if (head == null)
                {
                    head = currentItem;
                    current = currentItem;
                }
                else
                {
                    current.next = currentItem;
                    current = currentItem;
                }

                if (list1 != null && list2 != null)
                {
                    if (list1.val <= list2.val)
                    {
                        currentItem.val = list1.val;
                        list1 = list1.next;
                        continue;
                    }
                    else if (list1.val > list2.val)
                    {
                        currentItem.val = list2.val;
                        list2 = list2.next;
                        continue;
                    }
                }

                else if (list1 == null)
                {
                    currentItem.val = list2.val;
                    list2 = list2.next;
                    continue;
                }

                else if (list2 == null)
                {
                    currentItem.val = list1.val;
                    list1 = list1.next;
                    continue;
                }
            }

            return head;
        }

        /*Merge k Sorted Lists*/
        public ListNode<int> MergeKLists(ListNode<int>[] lists)
        {
            ListNode<int> head = null;
            ListNode<int> current = null;
            if (lists.Length == 0)
                return head;

            HeadItem minValue = new HeadItem();
            minValue.val = int.MaxValue;
            minValue.listIndex = -1;
            while (true)
            {
                int listCount = lists.Length;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null)
                    {
                        if (lists[i].val < minValue.val)
                        {
                            minValue.val = lists[i].val;
                            minValue.listIndex = i;
                        }
                    }
                    else
                    {
                        listCount--;
                    }
                }

                if (listCount == 0)// all check
                {
                    break;
                }
                else
                {
                    if (current == null)
                    {
                        head = new ListNode<int>(minValue.val, null);
                        current = head;
                        lists[minValue.listIndex] = lists[minValue.listIndex].next;
                    }
                    else
                    {
                        current.next = new ListNode<int>(minValue.val, null);
                        current = current.next;
                        lists[minValue.listIndex] = lists[minValue.listIndex].next;
                    }

                    if (lists[minValue.listIndex] == null)
                    {
                        listCount--;
                        if (listCount == 0)
                            break;
                    }
                    minValue = new HeadItem();
                    minValue.val = int.MaxValue;
                }

            }

            return head;
        }

        /* Swap Nodes in Pairs*/
        public ListNode<int> SwapPairs(ListNode<int> head)
        {
            if (head == null)
                return null;
            if (head.next == null)
            {
                return head;
            }
            ListNode<int> headNew = null;
            ListNode<int> lastIndexSeq = null;
            ListNode<int> current = head;
            while (true)
            {
                if (current == null)
                {
                    break;
                }
                ListNode<int> currentOne = current.next;

                if (currentOne == null)
                {
                    break;
                }

                ListNode<int> currentTwo = currentOne.next;
                current.next = currentTwo;
                currentOne.next = current;
                if (lastIndexSeq != null)
                {
                    lastIndexSeq.next = currentOne;
                }

                if (headNew == null)
                {
                    headNew = currentOne;
                }

                lastIndexSeq = current;
                current = current.next;
            }

            return headNew;
        }

        /*Reverse Nodes in k-Group*/
        public ListNode<int> ReverseKGroup(ListNode<int> head, int k)
        {
            if (head == null)
                return head;
            if (head.next == null)
            {
                return head;
            }

            ListNode<int> current = head;
            for (int i = 0; i < k; i++)
            {
                if (current != null)
                {
                    current = current.next;
                }
                else
                {
                    return head;// not enough k number
                }
            }


            current = head;
            ListNode<int> preNode = null;
            for (int i = 0; i < k; i++)
            {
                ListNode<int> nextNode = current.next;
                current.next = preNode;
                preNode = current;
                current = nextNode;
            }


            head.next = ReverseKGroup(current, k);
            return preNode;
        }

        /*Note: Try to solve this task in O(n) time using O(1) additional space, where n is the number of elements in l, since this is what you'll be asked to do during an interview.

        Given a singly linked list of integers, determine whether or not it's a palindrome.

        Note: in examples below and tests preview linked lists are presented as arrays just for simplicity of visualization: in real data you will be given a head node l of the linked list
        */
        bool solution(ListNode<int> l)
        {
            if (l == null)
                return true;
            if (l.next == null)
                return true;
            if (l.next.next == null)
            {
                if (l.val == l.next.val)
                    return true;
                else
                    return false;
            }

            ListNode<int> left = l;
            ListNode<int> right = FindMiddle(l);
            Console.WriteLine(right.val);
            right = Reverse(right);
            return CheckValid(left, right);
        }

        //find Middle
        ListNode<int> FindMiddle(ListNode<int> l)
        {
            ListNode<int> low = l;
            ListNode<int> high = l;
            while (true)
            {
                low = low.next;
                if (high.next == null || high.next.next == null)
                    break;
                else
                    high = high.next.next;
            }

            return low;
        }

        ListNode<int> Reverse(ListNode<int> l)
        {
            if (l == null)
                return l;
            if (l.next == null)
            {
                return l;
            }
            ListNode<int> p = null;
            ListNode<int> c = l;
            ListNode<int> h = l.next;
            while (h != null)
            {
                c.next = p;
                p = c;
                c = h;
                h = h.next;
            }

            c.next = p;

            return c;
        }

        bool CheckValid(ListNode<int> left, ListNode<int> right)
        {
            while (right != null)
            {
                if (left.val == right.val)
                {
                    left = left.next;
                    right = right.next;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

    }
    public class Cache
    {
        public int Key;
        public int Value;

        public Cache(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    /*LRU Cache*/
        public class LRUCache
    {

        private int capacity;
        private Dictionary<int, LinkedListNode<Cache>> caches = new Dictionary<int, LinkedListNode<Cache>>();
        private LinkedList<Cache> LRU = new LinkedList<Cache>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (!caches.ContainsKey(key))
                return -1;

            else
            {
                var returnCache = caches[key];
                LRU.Remove(returnCache);
                LRU.AddFirst(returnCache);
                return returnCache.Value.Value;
            }
        }

        public void Put(int key, int value)
        {

            if (caches.ContainsKey(key))
            {
                var current = caches[key];
                LRU.Remove(current);

                current.Value.Value = value;

                LRU.AddFirst(current);
            }
            else
            {
                if (caches.Count < capacity)
                {
                    var newCache = new Cache(key, value);
                    var newLinkedNode = new LinkedListNode<Cache>(newCache);
                    caches.Add(key, newLinkedNode);
                    LRU.AddFirst(newLinkedNode);
                }

                else
                {
                    var removeKey = LRU.Last.Value.Key;
                    LRU.RemoveLast();
                    caches.Remove(removeKey);

                    var newCache = new Cache(key, value);
                    var newLinkedNode = new LinkedListNode<Cache>(newCache);
                    caches.Add(key, newLinkedNode);
                    LRU.AddFirst(newLinkedNode);

                }
            }

        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
