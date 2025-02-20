using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tree.Tests
{
    [TestClass()]
    public class PriorityQueueOnSortedDictionaryTests
    {
        [TestMethod()]
        public void EnqueueTest()
        {
            var pq = new PriorityQueueOnSortedDictionary<int, int>();
            pq.Enqueue(13, 131);
            pq.Enqueue(1, 11);
            pq.Enqueue(-10, -101);
            pq.Enqueue(4, 41);
            pq.Enqueue(2, 21);
            while (pq.IsEmpty() == false)
            {
                var item = pq.Dequeue();
                Console.WriteLine(item);
            }
        }
    }
}