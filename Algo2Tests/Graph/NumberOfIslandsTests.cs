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
    public class NumberOfIslandsTests
    {
        [TestMethod()]
        public void GetNumberOfIslandsTest()
        {
            var binaryMatrix = new int[,] { { 1, 0, 1, 0 }, { 0, 1, 1, 1 }, { 0, 0, 1, 0 } };
            var result = NumberOfIslands.GetNumberOfIslandsByDfs(binaryMatrix);
            Assert.AreEqual(result, 2);
        }
    }
}