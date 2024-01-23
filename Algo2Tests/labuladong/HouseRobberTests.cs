using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.labuladong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong.Tests
{
    [TestClass()]
    public class HouseRobberTests
    {
        [TestMethod()]
        public void GetMaxValueWithoutAdjacentTest()
        {
            var arr = new int[] { 1, 2, 3, 1, 1, 7};
            var actual = HouseRobber.GetMaxValueWithoutAdjacentBackTracking(arr);
            Assert.AreEqual(4, actual);
        }
    }
}