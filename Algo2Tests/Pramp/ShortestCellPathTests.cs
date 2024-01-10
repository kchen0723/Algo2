using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Pramp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Pramp.Tests
{
    [TestClass()]
    public class ShortestCellPathTests
    {
        [TestMethod()]
        public void GetShortestPathTest()
        {
            var arr = new int[,] { { 1, 1, 1, 1 }, { 0, 0, 1, 1 }, { 1, 1, 1, 0 } };
            var result = ShortestCellPath.GetShortestPathByBfs(arr, 0, 0, 2, 0);
            Assert.AreEqual(6, result);
        }
    }
}