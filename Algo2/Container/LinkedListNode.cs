using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Container
{
    public class LinkedListNode<T> where T : IComparable<T>
    {
        public LinkedListNode() { }
        public LinkedListNode(T val) 
        {
            Value = val;
        }
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }
    }
}
