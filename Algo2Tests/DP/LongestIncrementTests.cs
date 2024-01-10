using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP.Tests
{
    [TestClass()]
    public class LongestIncrementTests
    {
        [TestMethod()]
        public void GetContinuousLongestIncrementalTest()
        {
            var numbers = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            var actual = LongestIncrement.GetContinuousLongestIncrementalByDp(numbers);
            Assert.AreEqual(3, actual);
        }

        [TestMethod()]
        public void GetLongestIncrementalSubsequenceTest()
        {
            var numbers = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
            var actual = LongestIncrement.GetLongestIncrementalSubsequenceByDp(numbers);
            Assert.AreEqual(4, actual);
        }
    }
}