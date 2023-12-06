using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Sorting.Tests
{
    [TestClass()]
    public class BasicSortingTests
    {
        [TestMethod()]
        public void BubbleSortTest()
        {
            var input = new int[] { 11, 10, 9, 5, 6, 7};
            var result = BasicSorting.BubbleSort(input);
            Assert.AreEqual(5, result[0]);
        }
    }
}