using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.TwentyfourGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algo2.TwentyfourGame.Tests
{
    [TestClass()]
    public class CalculatorRecusiveTests
    {
        [TestMethod()]
        public void ToFloatTest()
        {
            var result = CalculatorRecusive.ToFloat("987.77");
            if (Math.Abs(result - 987.77) < 0.001)
            {
                Console.WriteLine("success");
            }
        }

        [TestMethod()]
        public void CalculateTest()
        {
            string input = "9-10+11";
            var actual = CalculatorRecusive.Calculate(input);
            Assert.AreEqual(10, actual);

            input = "1+((9-3)*4-10)/(6-4)+1";
            actual = CalculatorRecusive.Calculate(input);
            Assert.AreEqual(9, actual);

            input = "1+((3*((9-3)*4-10)/(6-4)+1)+2)/3+5";
            actual = CalculatorRecusive.Calculate(input);
            Assert.AreEqual(14, actual);
        }

        [TestMethod()]
        public void CalcuateByTokensTest()
        {
            string input = "9-10+11";
            var actual = CalculatorRecusive.CalcuateByTokens(input);
            Assert.AreEqual(10, actual);

            input = "1+((9-3)*4-10)/(6-4)+1";
            actual = CalculatorRecusive.CalcuateByTokens(input);
            Assert.AreEqual(9, actual);

            input = "1+((3*((9-3)*4-10)/(6-4)+1)+2)/3+5";
            actual = CalculatorRecusive.CalcuateByTokens(input);
            Assert.AreEqual(14, actual);
        }
    }
}