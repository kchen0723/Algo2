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
    public class BagMaxTests
    {
        [TestMethod()]
        public void GetMaxProfitForWeightByBackTrackingTest()
        {
            var bags = new int[,] { { 2, 6 }, { 2, 3 }, { 6, 5 }, { 5, 4 }, { 4, 6 } };
            var result = BagMax.GetMaxProfitForWeightByBackTracking(bags, 10);
            Assert.AreEqual(15, result);
        }

        [TestMethod()]
        public void GetMaxProfitForWeightByDpTest()
        {
            var bags = new int[,] { { 2, 6 }, { 2, 3 }, { 6, 5 }, { 5, 4 }, { 4, 6 } };
            var result = BagMax.GetMaxProfitForWeightByDp(bags, 10);
            Assert.AreEqual(15, result);
        }

        [TestMethod()]
        public void GetMaxProfitForWeightByDpMultipleTest()
        {
            var bags = new int[,] { { 3, 6 }, { 2, 3 }, { 6, 5 }, { 5, 4 }, { 4, 6 } };
            var result = BagMax.GetMaxProfitForWeightByDpMultiple(bags, 11);
            Assert.AreEqual(21, result);
        }
    }
}