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
    public class ArrayProductExceptItemItselfTests
    {
        [TestMethod()]
        public void GetArrayProductExceptItemItselfTest()
        {
            var arr = new int[] { 2, 7, 3, 4, 6, 9 };
            var actual = ArrayProductExceptItemItself.GetArrayProductExceptItemItself(arr);
            Assert.IsNotNull(actual);
        }
    }
}