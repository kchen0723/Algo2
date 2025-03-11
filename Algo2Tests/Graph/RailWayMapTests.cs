using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph.Tests
{
    [TestClass()]
    public class RailWayMapTests
    {
        [TestMethod()]
        public void FindShortestPathByBackTrackingTest()
        {
            var actual = RailWayMap.FindShortestPathByBackTracking("南京", "重庆");
            Assert.AreEqual(8.5, actual);

            actual = RailWayMap.FindShortestPathByBackTracking("沈阳", "福州");
            Assert.AreEqual(12, actual);
        }
    }
}