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
    public class CoinChangeTests
    {
        [TestMethod()]
        public void GetMinCountByBackTrackTest()
        {
            var arr = new int[] { 1, 5, 2 };
            var actual = CoinChange.GetMinCountByBackTrack(arr, 12);
            Assert.AreEqual(3, actual.Item1);
        }

        [TestMethod()]
        public void GetMinCountByDpTest()
        {
            var arr = new int[] { 1, 5, 2 };
            var actual = CoinChange.GetMinCountByDp(arr, 12);
            Assert.AreEqual(3, actual);
        }
    }
}