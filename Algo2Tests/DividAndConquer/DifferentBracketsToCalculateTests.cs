using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.DividAndConquer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DividAndConquer.Tests
{
    [TestClass()]
    public class DifferentBracketsToCalculateTests
    {
        [TestMethod()]
        public void AddDifferentBracketsToCalculateTest()
        {
            var str = "2*3-5+8/3+10";
            var actual = DifferentBracketsToCalculate.AddDifferentBracketsToCalculate(str);
            Assert.IsNotNull(actual);
        }
    }
}