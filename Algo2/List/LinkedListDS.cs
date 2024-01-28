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
        private LinkedListNodeDS<T> _last = null;
        private int _count = 0;
        
        private LinkedListNodeDS<T> First
        {
            get { return _head.Next; }
        }

        private LinkedListNodeDS<T> Last
        {
            get { return _last; }
        }

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
                return _count;
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
            var current = _last;
            var linkedListNode = new LinkedListNodeDS<T>() { NodeValue = item };
            if (current != null)
            {
                current.Next = linkedListNode;
                linkedListNode.Previous = current;
            }
            else
            {
                _head.Next = linkedListNode;
                linkedListNode.Previous = _head;
            }
            _last = linkedListNode;
            _count++;
        }

        public void Clear()
        {
            if (_head.Next != null)
            { 
                _head.Next.Previous = null;
            }
            _head.Next = null;
            _count = 0;
            _last = null;
        }

        public T Delete(int index)
        {
            var node = GetByIndex(index);
            if (node != null)
            {
                if (_count == 1)     //only one element
                { 
                    _last = null;
                }
                else     
                {
                    _last = _last.Previous;        //move _last point.
                }
                node.Previous.Next = node.Next;
                node.Previous = null;
                if (node.Next != null)
                { 
                    node.Next.Previous = node.Previous;
                }
                _count--;
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

        public void InsertAfter(int index, T item)
        {
            var node = GetByIndex(index);
            if (node != null)
            {
                var newNode = new LinkedListNodeDS<T>() { NodeValue = item };
                newNode.Previous = node;
                newNode.Next = node.Next;
                if (node.Next != null)    //insert in the middle
                {
                    node.Next.Previous = newNode;
                }
                else        //insert in the end
                {
                    _last = newNode;
                }
                node.Next = newNode;
                _count++;
            }
        }

        public bool RemoveLast(ref LinkedListNodeDS<T> result)
        {
            if (IsEmpty)
            {
                return false;
            }

            result = _last;
            if (_count == 1)
            {
                _last = null;
            }
            else
            {
                _last = _last.Previous;
            }
            result.Previous.Next = null;
            result.Previous = null;
            _count--;
            return true;
        }

        public void AddFirst(T item)
        {
            var newNode = new LinkedListNodeDS<T>() { NodeValue = item };
            var oldFirst = _head.Next;
            oldFirst.Previous = newNode;
            newNode.Next = oldFirst;
            _head.Next = newNode;
            newNode.Previous = _head;
            if (_count == 0)
            {
                _last = newNode;
            }
            _count++;
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

        public void TraverseBackRecursive(Action<T> action)
        {
            if (_head != null)
            {
                TraverseBackRecursiveHelp(_head.Next, action);
            }
        }

        private void TraverseBackRecursiveHelp(LinkedListNodeDS<T> node, Action<T> action)
        {
            if (node != null)
            {
                TraverseRecursiveHelp(node.Next, action);
                action?.Invoke(node.NodeValue);
            }
        }
    }
}
