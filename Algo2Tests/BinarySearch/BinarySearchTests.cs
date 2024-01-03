using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2;
using Algo2.BinarySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.BinarySearch.Tests
{
    [TestClass()]
    public class BinarySearchTests
    {
        [TestMethod()]
        public void FindInSortedUniqueArrayTest()
        {
            var arr = Utility.ArrayHelper.CreateUniquueSortedList(12, 25).ToArray();
            var actual = BinarySearch.FindInSortedUniqueArray(arr, 16);
            //Assert.AreEqual(4, actual);
        }

        [TestMethod()]
        public void FindLeftBoundaryInSortedArrayTest()
        {
            var arr = Utility.ArrayHelper.CreateSortedList(12, 25).ToArray();
            var actual = BinarySearch.FindLeftBoundaryInSortedArray(arr, 16);
        }

        [TestMethod()]
        public void FindRightBoundaryInSortedArrayTest()
        {
            var arr = Utility.ArrayHelper.CreateSortedList(12, 25).ToArray();
            var actual = BinarySearch.FindRightBoundaryInSortedArray(arr, 16);
        }

        [TestMethod()]
        public void FindInSortedShiftArrayTest()
        {
            var arr = new int[] { 10, 20, 1, 3, 5, 6, 7, 8, 9 };
            var actual = BinarySearch.FindInSortedShiftArray(arr, 3);
            Assert.AreEqual(3, actual);
        }

        [TestMethod()]
        public void FindInSortedUniqueArrayRecursiveTest()
        {
            var arr = new int[] { 10, 20, 1, 3, 5, 6, 7, 8, 9 };
            var actual = BinarySearch.FindInSortedUniqueArrayRecursive(arr, 3);
            Assert.AreEqual(3, actual);
        }
    }
}