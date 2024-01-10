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
    public class TriangleMinPathTests
    {
        [TestMethod()]
        public void GetMinPathTest()
        {
            var first = new List<int>() { 2 };
            var second = new List<int>() { 3, 4 };
            var third = new List<int>() { 6, 5, 7 };
            var fouth = new List<int>() { 4, 1, 8, 3 };
            var triangle = new List<List<int>>() { first, second, third, fouth };
            var min = TriangleMinPath.GetMinPathByDp(triangle);
            Assert.AreEqual(11, min);
        }
    }
}