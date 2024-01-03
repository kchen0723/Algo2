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
    public class AdvancedSortingTests
    {
        [TestMethod()]
        public void ShellSortTest()
        {
            var input = new int[] { 11, 10, 9, 5, 6, 7, 3, 13, 1 };
            var result = AdvancedSorting.ShellSort(input);
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod()]
        public void QuickSortTest()
        {
            var input = new int[] { 8, 10, 9, 5, 6, 7, 3, 13, 1 };
            var result = AdvancedSorting.QuickSort(input);
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod()]
        public void QuickSortTest2()
        {
            var input = new int[] { 1, 3, 7, 5, 6 };
            var result = AdvancedSorting.QuickSort(input);
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod()]
        public void QuickSortTest3()
        {
            var input = new int[] { 21, 100, 3, 50, 1 };
            var result = AdvancedSorting.QuickSort(input);
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod()]
        public void MergeInPlaceTest()
        {
            var input = new int[] { 5, 6, 7, 8, 9, 1, 3, 13 };
            AdvancedSorting.Merge2SortedHalvesArray(input, 0, 4, input.Length - 1);
            Assert.AreEqual(input[0], 1);
        }

        [TestMethod()]
        public void MergeInPlaceTest2()
        {
            var input = new int[] { 21, 100, 1, 3, 50 };
            AdvancedSorting.Merge2SortedHalvesArray(input, 0, 1, input.Length - 1);
            Assert.AreEqual(input[0], 1);
        }

        [TestMethod()]
        public void MergeInPlaceTest3()
        {
            var input = new int[] { 1, 3, 7, 5, 6 };
            AdvancedSorting.Merge2SortedHalvesArray(input, 0, 2, input.Length - 1);
            Assert.AreEqual(input[0], 1);
        }

        [TestMethod()]
        public void MergeInPlaceTest4()
        {
            var input = new int[] { 2, 3, 10, 1, 8, 20 };
            AdvancedSorting.Merge2SortedHalvesArray(input, 0, 2, input.Length - 1);
            Assert.AreEqual(input[0], 1);
        }

        [TestMethod()]
        public void MergeSortTest()
        {
            var input = new int[] { 11, 10, 9, 5, 6, 7, 3, 13, 1 };
            AdvancedSorting.MergeSort(input);
            Assert.AreEqual(1, input[0]);
        }
    }
}