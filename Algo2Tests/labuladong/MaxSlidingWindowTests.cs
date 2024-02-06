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
    public class MaxSlidingWindowTests
    {
        [TestMethod()]
        public void MaxSldingWindowTest()
        {
            var nums = new List<int>() { 1, 3, 3, -3, 5, 3, 6, 7};
            var result = MaxSlidingWindow.GetMaxSliding(nums, 3);
            Assert.IsNotNull(result);
        }
    }
}