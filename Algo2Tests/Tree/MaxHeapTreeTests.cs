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
    public class MaxHeapTreeTests
    {
        [TestMethod()]
        public void MaxHeapTreeTest()
        {
            var arr = new int[] { 7, 6, 3, 5};
            var maxHeapTree = new MaxHeapTree(arr);
            maxHeapTree.Insert(11);
            maxHeapTree.Delete();
            Assert.IsNotNull(maxHeapTree);
        }
    }
}