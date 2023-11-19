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
    public class MatrixTrianglePathTests
    {
        [TestMethod()]
        public void GetMatrixTrianglePathByDpTest()
        {
            var actual = MatrixTrianglePath.GetMatrixTrianglePathByDp(4);
            Assert.AreEqual(14, actual);
        }
    }
}