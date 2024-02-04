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
    public class MonotonicStackTests
    {
        [TestMethod()]
        public void GetNextGreaterNumbersTest()
        {
            var arr = new List<int>() { 2, 1, 2, 4, 3};
            var result = MonotonicStack.GetNextGreaterNumbers(arr);
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public void GetNextGreaterNumbersTest2()
        {
            var arr = new List<int>() {73, 74, 75, 71, 69, 72, 76, 73};
            var result = MonotonicStack.GetNextGreaterNumberDistance(arr);
            Assert.IsNotNull(result);
        }
    }
}