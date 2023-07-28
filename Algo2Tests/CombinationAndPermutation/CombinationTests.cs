using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.CombinationAndPermutation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.CombinationAndPermutation.Tests
{
    [TestClass()]
    public class CombinationTests
    {
        [TestMethod()]
        public void GetCombinationFromUniqueArrayTest()
        {
            var nums = new int[] { 1, 2, 3 };
            var combinations = Combination.GetCombinationFromUniqueArray(nums, 2);
        }

        [TestMethod()]
        public void GetCombinationFromDuplicateArrayTest()
        {
            var nums = new int[] { 1, 2, 3, 2 };
            var combinations = Combination.GetCombinationFromDuplicateArray(nums, 2);
        }

        [TestMethod()]
        public void GetCombinationMultipleTimesTest()
        {
            var nums = new int[] { 1, 2 };
            var combinations = Combination.GetCombinationMultipleTimes(nums, 3);
        }
    }
}