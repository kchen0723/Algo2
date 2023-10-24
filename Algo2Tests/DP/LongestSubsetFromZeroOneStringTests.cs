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
    public class LongestSubsetFromZeroOneStringTests
    {
        [TestMethod()]
        public void GetLongestSubSetByBackTrackingTest()
        {
            var arr = new string[] { "10", "0001", "111001", "1", "0" };
            var actual = LongestSubsetFromZeroOneString.GetLongestSubSetByBackTracking(arr, 5, 3);
            Assert.AreEqual(4, actual);
        }

        [TestMethod()]
        public void GetLongestSubSetByDpTest()
        {
            var arr = new string[] { "10", "0001", "111001", "1", "0" };
            var actual = LongestSubsetFromZeroOneString.GetLongestSubSetByDp(arr, 5, 3);
            Assert.AreEqual(4, actual);
        }
    }
}