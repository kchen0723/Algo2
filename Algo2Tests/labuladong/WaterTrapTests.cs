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
    public class WaterTrapTests
    {
        [TestMethod()]
        public void TrapTest()
        {
            var arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
            var actual = WaterTrap.Trap(arr);
            Assert.AreEqual(6, actual);
        }
    }
}