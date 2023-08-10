using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.TwentyfourGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}