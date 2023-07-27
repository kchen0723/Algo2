using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.PermutationAndCombination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.PermutationAndCombination.Tests
{
    [TestClass()]
    public class CombinationTests
    {
        [TestMethod()]
        public void GetCombinationFromUniqueArrayTest()
        {
            var nums = new int[] { 1, 2, 3 };
            var cobinations = Combination.GetCombinationFromUniqueArray(nums, 2);
        }
    }
}