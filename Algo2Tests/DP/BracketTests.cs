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
    public class BracketTests
    {
        [TestMethod()]
        public void IsValidTest()
        {
            var brackets = "((())()()))))()()";
            var actual = Bracket.IsValid(brackets);
            Assert.AreEqual(false, actual);
        }

        [TestMethod()]
        public void GetLongestCountTest()
        {
            var brackets = "((())()()))(((((())))))";
            var actual = Bracket.GetLongestCount(brackets);
            Assert.AreEqual(12, actual);
        }
    }
}