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
    public class LongestPalindromeTests
    {
        [TestMethod()]
        public void GetLongestPalindromeSubsetTest()
        {
            var actual = LongestPalindrome.GetLongestPalindromeSubset("array");
            Assert.AreEqual(4, actual);
        }
    }
}