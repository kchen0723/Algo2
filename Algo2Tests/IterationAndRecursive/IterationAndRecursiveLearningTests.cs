using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.IterationAndRecursive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo2.Container;

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

        [TestMethod()]
        public void RecursiveLinkedListDSTest()
        {
            var linkedList = new LinkedListDS<int>(new int[] { 4, 5, 7, 8, 9 });
            IterationAndRecursiveLearning.RecursiveLinkedListDS(linkedList);
        }

        [TestMethod()]
        public void ReverseTest()
        {
            var linkedList = new LinkedListDS<int>(new int[] { 4, 5, 7, 8, 9 });
            var result = IterationAndRecursiveLearning.BetterReverse(linkedList);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void RecursiveArrayToIterativeTest()
        {
            var array = new int[] { 4, 5, 7, 8, 9 };
            IterationAndRecursiveLearning.RecursiveArrayToIterative(array);
        }

        [TestMethod()]
        public void RecursiveLinkedToInterativeTest()
        {
            var LinkedList = new LinkedList<int>(new int[] { 4, 5, 7, 8, 9 });
            IterationAndRecursiveLearning.RecursiveLinkedToInterative(LinkedList);
        }

        [TestMethod()]
        public void BestReverseTest()
        {
            var linkedList = new LinkedListDS<int>(new int[] { 4, 5, 7 });
            var result = IterationAndRecursiveLearning.BestReverseLinkedList(linkedList);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void BestReverseArrayTest()
        {
            var array = new int[] { 4, 5, 7, 8, 9 };
            var result = IterationAndRecursiveLearning.BestReverseArray(array);
            Assert.IsNotNull(result);
        }
    }
}