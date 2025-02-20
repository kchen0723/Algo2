using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tree
{
    public class PriorityQueueOnSortedDictionary<Tkey, TValue>
    {
        public SortedDictionary<Tkey, Queue<TValue>> _sortedDictionary = new SortedDictionary<Tkey, Queue<TValue>>();

        public void Enqueue(Tkey priority, TValue value)
        {
            if (_sortedDictionary.ContainsKey(priority) == false)
            {
                _sortedDictionary[priority] = new Queue<TValue>();
            }
            _sortedDictionary[priority].Enqueue(value);
        }

        private Tkey GetFirst()
        {
            if (_sortedDictionary.Count == 0)
            {
                throw new InvalidOperationException("priority queue is empty");
            }
            var result = default(Tkey);
            foreach(var kvp in _sortedDictionary)
            {
                result = kvp.Key;
                break;
            }
            return result;
        }

        public TValue Dequeue()
        {
            if (_sortedDictionary.Count == 0)
            {
                throw new InvalidOperationException("priority queue is empty");
            }

            var firstKey = GetFirst();
            var result = _sortedDictionary[firstKey].Dequeue();
            if (_sortedDictionary[firstKey].Count == 0)
            {
                _sortedDictionary.Remove(firstKey);
            }
            return result;
        }

        public TValue Peek()
        {
            if (_sortedDictionary.Count == 0)
            {
                throw new InvalidOperationException("priority queue is empty");
            }

            var firstKey = GetFirst();
            return _sortedDictionary[firstKey].Peek();
        }

        public bool IsEmpty()
        { 
            return _sortedDictionary.Count == 0;
        }
    }
}
