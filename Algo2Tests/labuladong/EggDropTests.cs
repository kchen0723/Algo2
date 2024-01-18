using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.labuladong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Algo2.labuladong.Tests
{
    [TestClass()]
    public class EggDropTests
    {
        [TestMethod()]
        public void GetMinTryTest()
        {
            var actual = EggDrop.GetMinTry(2, 5);
            Assert.AreEqual(3, actual);
        }

        [TestMethod()]
        public void GetMinDropTest()
        {
            var actual = EggDrop.GetMinDrop(2, 5);
            Assert.AreEqual(14, actual);
        }
    }
}