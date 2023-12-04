using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Pramp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Pramp.Tests
{
    [TestClass()]
    public class SpiralCopyTests
    {
        [TestMethod()]
        public void ProcessSpiralCopyTest()
        {
            int[,] arr = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            var result = SpiralCopy.ProcessSpiralCopy(arr);
            Assert.AreEqual(result.Length, arr.Length);
        }
    }
}