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
            var src = "11+5.2-23*(0.4+23)";
            var actual = Calculate.GetTokens(src);
        }
    }
}