using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Container
{
    public class LinkedListDS<T> : IContainer<T> where T : IComparable<T>
    {
        private LinkedListNode<T> _dummyHeader = new LinkedListNode<T>();

        public LinkedListDS() { }
        public LinkedListDS(IEnumerable<T> values)
        {
            foreach (var item in values)
            {
                Insert(item);
            }
        }
        public LinkedListNode<T> First
        {
            get { return _dummyHeader.Next; }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                LinkedListNode<T> result = null;
                var current = First;
                while(current != null)
                {
                    result = current;
                    current = current.Next;
                }
                return result;
            }
        }

        public int Count
        {
            get 
            {
                int result = 0;
                var current = First;
                while (current != null)
                {
                    result++;
                    current = current.Next;
                }
                return result;
            }
        }

        public bool IsEmpty
        {
            get { return First == null; }
        }

        public bool IsFull
        {
            get { return false; }
        }

        public void Delete(T item)
        {
            var current = First;
            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    current.Previous.Next = current.Next;
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    current.Next = null;
                    current.Previous = null;
                    break;
                }
                current = current.Next;
            }
        }

        public void Insert(T item)
        {
            var node = new LinkedListNode<T>(item);
            var lastNode = Last ?? _dummyHeader;
            lastNode.Next = node;
            node.Previous = lastNode;
        }
    }
}
