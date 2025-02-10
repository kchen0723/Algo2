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
    public class StringSearchTests
    {
        [TestMethod()]
        public void BruteSearchTest()
        {
            var actual = StringSearch.BruteSearch("abcabaabcabac", "abaa");
            Assert.AreEqual(3, actual);
        }

        [TestMethod()]
        public void KmpSearchTest()
        {
            var actual = StringSearch.KmpSearch("abcabaabaaacabac", "aabaaa");
            Assert.AreEqual(5, actual);

            actual = StringSearch.KmpSearch("abcabaabaaacabac", "abaa");
            Assert.AreEqual(3, actual);

            actual = StringSearch.KmpSearch("a", "a");
            Assert.AreEqual(0, actual);
        }
    }
}