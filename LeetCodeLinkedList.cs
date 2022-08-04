using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
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
