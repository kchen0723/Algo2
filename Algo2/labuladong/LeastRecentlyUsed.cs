using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong
{
    //LeastRecentlyUsed algorithm. Cache only {capacity} items, remove the last one if out of space.
    //use dictionary and double linked list to implement it.
    public class LeastRecentlyUsed<TKey, TValue>
    {
        private int _capacity = 10;
        private Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> _dictionary = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>();
        private LinkedList<KeyValuePair<TKey, TValue>> _linkedlist = new LinkedList<KeyValuePair<TKey, TValue>> ();

        public LeastRecentlyUsed() : this(2)
        { 
        }
        public LeastRecentlyUsed(int capacity) 
        {
            _capacity = capacity;
        }

        //return the value in O(1)
        //use dictionary to return it. Also move the key to the first.
        public bool Get(TKey key, ref TValue result)
        {
            if (_dictionary.ContainsKey(key) == false)
            {
                return false;
            }

            var linkedNode = _dictionary[key];
            result = linkedNode.Value.Value;
            _linkedlist.Remove(linkedNode);
            _linkedlist.AddFirst(linkedNode);
            return true;
        }

        //put the value in P(1)
        //add key to cache, also move the key to the first. and remove the last one if out of space.
        public bool Put(TKey key, TValue value)
        {
            if (_dictionary.ContainsKey(key))
            {
                var linkedNode = _dictionary[key];
                _dictionary.Remove(key);
                _linkedlist.Remove(linkedNode);
            }
            var node = new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
            _linkedlist.AddFirst(node);
            _dictionary[key] = node;
            if (_linkedlist.Count > _capacity)
            {
                var last = _linkedlist.Last;
                _dictionary.Remove(last.Value.Key);
                _linkedlist.RemoveLast();
            }
            return true;
        }
    }
}
