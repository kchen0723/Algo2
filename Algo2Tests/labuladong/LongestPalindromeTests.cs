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
        public void GetLongestPalindromeStringTest()
        {
            var actual = LongestPalindrome.GetLongestPalindromeString("aacxycaa");
            Assert.AreEqual("aa", actual);
        }

        [TestMethod()]
        public void GetLongestPalindromeStringDp()
        {
            var actual = LongestPalindrome.GetLongestPalindromeStringDp("aacxycaa");
            Assert.AreEqual("aa", actual);
        }

        [TestMethod()]
        public void GetLongestPalindromeSubsetDp()
        {
            var actual = LongestPalindrome.GetLongestPalindromeSubsetDp("babb");
            Assert.AreEqual(3, actual);
        }
    }
}
