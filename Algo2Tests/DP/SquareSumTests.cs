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
    public class SquareSumTests
    {
        [TestMethod()]
        public void GetMinSquareCountTest()
        {
            var actual = SquareSum.GetMinSquareCountByDp(11);
            Assert.AreEqual(3, actual);
        }
    }
}