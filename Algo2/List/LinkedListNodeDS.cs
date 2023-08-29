using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.List
{
    public class LinkedListNodeDS<T>
    {
        public T NodeValue { get; set; }
        public LinkedListNodeDS<T> Previous { get; set; }
        public LinkedListNodeDS<T> Next { get; set; }
    }
}
