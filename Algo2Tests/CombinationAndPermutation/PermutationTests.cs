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
    public class PermutationTests
    {
        [TestMethod()]
        public void GetPermutationFromUniqueArrayTest()
        {
            var nums = new int[] { 1, 2, 3 };
            var permutations = Permutation.GetPermutationFromUniqueArray(nums, 3);
        }

        [TestMethod()]
        public void GetPermutationFromDuplicateArrayTest()
        {
            var nums = new int[] { 1, 2, 3, 2 };
            var permutations = Permutation.GetPermutationFromDuplicateArray(nums, 2);
        }

        [TestMethod()]
        public void GetPermutationMultipleTimesTest()
        {
            var nums = new int[] { 1, 2 };
            var permutations = Permutation.GetPermutationMultipleTimes(nums, 3);
        }

        [TestMethod()]
        public void GetPermutationMultipleTimesSubsetTest()
        {
            var nums = new int[] { 1, 2, 3 };
            var permutations = Permutation.GetPermutationMultipleTimesSubset(nums, 2);
        }
    }
}
