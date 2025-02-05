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
    public class SubArraySumTests
    {
        [TestMethod()]
        public void SubArraySumCountTest()
        {
            var arr = new int[] {3, 5, 2, -2, 4, 1};
            var actual = SubArraySum.SubArraySumCount(arr, 8);
            Assert.AreEqual(2, actual);
        }
    }
}