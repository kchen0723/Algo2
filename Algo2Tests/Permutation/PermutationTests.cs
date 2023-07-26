using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Permutation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Permutation.Tests
{
    [TestClass()]
    public class PermutationTests
    {
        [TestMethod()]
        public void GetPermutationFromUniqueArrayTest()
        {
            var nums = new int[] { 1, 2, 3};
            var permutations = Permutation.GetPermutationFromUniqueArray(nums, 3);
        }
    }
}