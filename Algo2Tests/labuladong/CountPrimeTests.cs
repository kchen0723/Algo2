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
    public class CountPrimeTests
    {
        [TestMethod()]
        public void CountTest()
        {
            var actual = CountPrime.Count(20);
            Assert.AreEqual(8, actual);
        }
    }
}