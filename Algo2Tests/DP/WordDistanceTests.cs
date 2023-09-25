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
    public class WordDistanceTests
    {
        [TestMethod()]
        public void GetInsertDeleteDistanceTest()
        {
            var result = WordDistance.GetInsertDeleteDistance("dog", "frog");
            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void GetEditDistanceTest()
        {
            var result = WordDistance.GetEditDistance("dog", "frog");
            Assert.AreEqual(2, result);
        }
    }
}