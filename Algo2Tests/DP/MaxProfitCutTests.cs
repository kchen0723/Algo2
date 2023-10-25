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
    public class MaxProfitCutTests
    {
        [TestMethod()]
        public void GetMaxProfitTest()
        {
            var sections = new int[] { 1, 2, 3, 4, 5, 6 };
            var profiles = new int[] { 1, 3, 4, 5, 6, 7 };
            var actual = MaxProfitCut.GetMaxProfitByBackTracking(sections, profiles, 12);
            Assert.AreEqual(18, actual);
        }

        [TestMethod()]
        public void GetMaxProfitByDpTest()
        {
            var sections = new int[] { 1, 2, 3, 4, 5, 6 };
            var profiles = new int[] { 1, 3, 4, 5, 6, 7 };
            var actual = MaxProfitCut.GetMaxProfitByDp(sections, profiles, 12);
            Assert.AreEqual(18, actual);
        }
    }
}