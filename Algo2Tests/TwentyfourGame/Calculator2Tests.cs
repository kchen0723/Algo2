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
    public class Calculator2Tests
    {
        [TestMethod()]
        public void CalculateTest()
        {
            string input = "1+((9-3)*4-10)/(6-4)+1";
            var actual = Calculator2.Calculate(input);
            Assert.AreEqual(9, actual);

            input = "1+((3*((9-3)*4-10)/(6-4)+1)+2)/3+5";
            actual = Calculator2.Calculate(input);
            Assert.AreEqual(14, actual);
        }
    }
}