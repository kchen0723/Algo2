using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.List
{
    public class LinkedListDS<T> : IListDS<T>
    {
        private LinkedListNodeDS<T> _head = new LinkedListNodeDS<T>();
        public T this[int index] 
        {
            get
            {
                var node = GetByIndex(index);
                if (node != null)
                {
                    return node.NodeValue;
                }
                return default(T);
            }
            set
            {
                var node = GetByIndex(index);
                if (node != null)
                {
                    node.NodeValue = value;
                }
            }
        }

        public int Count
        {
            get
            { 
                var result = 0;
                var current = _head.Next;
                while(current != null)
                {
                    result++;
                    current = current.Next;
                }
                return result;
            }
        }

        public bool IsEmpty
        { 
            get 
            { 
                return _head.Next == null; 
            }
        }

        public void Append(T item)
        {
            var current = _head;
            while (current != null && current.Next != null)
            {
                current = current.Next;
            }
            var last = new LinkedListNodeDS<T>() { NodeValue = item };
            current.Next = last;
            last.Previous = current;
        }

        public void Clear()
        {
            if (_head.Next != null)
            { 
                _head.Next.Previous = null;
            }
            _head.Next = null;
        }

        public T Delete(int index)
        {
            var node = GetByIndex(index);
            if (node != null)
            {
                node.Previous.Next = node.Next;
                if (node.Next != null)
                { 
                    node.Next.Previous = node.Previous;
                }
                return node.NodeValue;
            }
            return default(T);
        }

        private LinkedListNodeDS<T> GetByIndex(int index)
        {
            if (index < 0)
            { 
                return null;
            }

            var current = _head;
            var currentIndex = -1;
            while (current != null && currentIndex < index)
            {
                currentIndex++;
                current = current.Next;
            }
            if (currentIndex == index)
            {
                return current;
            }
            return null;
        }

        public int Find(T item)
        {
            var current = _head.Next;
            var currentIndex = 0;
            while (current != null)
            {
                if (current.NodeValue.Equals(item))
                {
                    break;
                }
                currentIndex++;
                current = current.Next;
            }
            return currentIndex;
        }

        public void Insert(int index, T item)
        {
            var node = GetByIndex(index);
            if (node != null)
            {
                var newNode = new LinkedListNodeDS<T>() { NodeValue = item };
                newNode.Previous = node;
                newNode.Next = node.Next;
                node.Next = newNode;
                if (node.Next != null)
                {
                    node.Next.Previous = newNode;
                }
            }
        }

        public void TraverseRecursive(Action<T> action)
        {
            if (_head != null)
            {
                TraverseRecursiveHelp(_head.Next, action);
            }
        }

        private void TraverseRecursiveHelp(LinkedListNodeDS<T> node, Action<T> action)
        {
            if (node != null)
            {
                action?.Invoke(node.NodeValue);
                TraverseRecursiveHelp(node.Next, action);
            }
        }

        public void TraverseIteration(Action<T> action)
        {
            if (_head != null)
            {
                var current = _head.Next;
                while (current != null)
                {
                    action?.Invoke(current.NodeValue);
                    current = current.Next;
                }
            }
        }
    }
}
