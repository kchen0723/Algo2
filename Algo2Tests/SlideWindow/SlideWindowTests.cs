using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.SlideWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.SlideWindow.Tests
{
    [TestClass()]
    public class SlideWindowTests
    {
        [TestMethod()]
        public void GetMinCoverTest()
        {
            var actual = SlideWindow.GetMinCover("GetMinCover", "Mov");
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void HasPermutationTest()
        {
            var actual = SlideWindow.HasPermutation("GetMinCover", "niM");
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void HasPermutationByBitXORTest()
        {
            var actual = SlideWindow.HasPermutationByBitXOR("GetMinCover", "niM");
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void PermutationStartIndexesTest()
        {
            var actual = SlideWindow.PermutationStartIndexes("GetMinCovMnier", "niM");
            Assert.IsNotNull(actual);
        }
    }
}