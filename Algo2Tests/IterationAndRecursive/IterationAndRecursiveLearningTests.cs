using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.IterationAndRecursive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.IterationAndRecursive.Tests
{
    [TestClass()]
    public class IterationAndRecursiveLearningTests
    {
        [TestMethod()]
        public void IterationArrayTest()
        {
            var array = new int[] { 4, 5, 7, 8, 9 };
            IterationAndRecursiveLearning.IterationArray(array);
            IterationAndRecursiveLearning.RecursiveArray(array);
        }

        [TestMethod()]
        public void IterationLinkedListTest()
        {
            var LinkedList = new LinkedList<int>(new int[] { 4, 5, 7, 8, 9 });
            IterationAndRecursiveLearning.IterationLinkedList(LinkedList);
            IterationAndRecursiveLearning.RecursiveLinkedList(LinkedList);
        }
    }
}