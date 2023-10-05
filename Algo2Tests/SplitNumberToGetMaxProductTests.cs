using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tests
{
    [TestClass()]
    public class SplitNumberToGetMaxProductTests
    {
        [TestMethod()]
        public void GetMaxProductBySplitNumberTest()
        {
            var actual = SplitNumberToGetMaxProduct.GetMaxProductBySplitNumber(10);
            Assert.AreEqual(36, actual);
        }
    }
}