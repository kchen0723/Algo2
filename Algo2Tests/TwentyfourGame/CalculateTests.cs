using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.TwentyfourGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Algo2.TwentyfourGame.Tests
{
    [TestClass()]
    public class CalculateTests
    {
        [TestMethod()]
        public void GetTokensTest()
        {
            var src = "1+2-3*(4+5)";
            var tokens = Calculate.GetTokens(src);
            var postfix = Calculate.ParseToPostfixExpression(tokens);
            var actual = Calculate.CalculatePostfixExpression(postfix);
        }

        [TestMethod()]
        public void CalcualteTest()
        {
            var src = "1+((3*((9-3)*4-10)/(6-4)+1)+2)/3+5";
            var actual = Calculate.Calcualte(src);
            Assert.AreEqual(14, actual);
        }
    }
}