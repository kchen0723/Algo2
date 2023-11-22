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
    public class StockTests
    {
        [TestMethod()]
        public void GetMaxProfitByDpTest()
        {
            var nums = new List<int>() { 7, 2, 6, 1, 4, 2 };
            var actual = Stock.GetMaxProfitByDp(nums);
            Assert.AreEqual(4, actual);
        }

        [TestMethod()]
        public void GetMaxProfitByDp2Test()
        {
            var nums = new List<int>() { 7, 2, 6, 1, 4, 2 };
            var actual = Stock.GetMaxProfitByDp2(nums);
            Assert.AreEqual(4, actual);
        }
    }
}