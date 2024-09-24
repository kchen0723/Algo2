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
    public class IndexesOfItemsWeightTests
    {
        [TestMethod()]
        public void GetIndicesOfItemWeightsTest()
        {
            var arr = new int[] { 4, 6, 10, 15, 16 };
            var result = IndexesOfItemsWeight.GetIndicesOfItemWeights(arr, 21);
            Assert.IsNotNull(result);
        }
    }
}