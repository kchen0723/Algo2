using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.DP.Tests
{
    [TestClass()]
    public class CommonSubStringTests
    {
        [TestMethod()]
        public void GetLongestCommonSubStringTest()
        {
            var actual = CommonSubString.GetLongestCommonSubString("hong", "konga");
            Assert.AreEqual(3, actual);
        }
    }
}