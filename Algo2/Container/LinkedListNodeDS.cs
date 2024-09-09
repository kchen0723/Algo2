using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Container
{
    public class LinkedListNodeDS<T> where T : IComparable<T>
    {
        public LinkedListNodeDS() { }
        public LinkedListNodeDS(T val) 
        {
            Value = val;
        }
        public T Value { get; set; }
        public LinkedListNodeDS<T> Next { get; set; }
        public LinkedListNodeDS<T> Previous { get; set; }
    }
}
