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
    public class JumpGameTests
    {
        [TestMethod()]
        public void CanJumpTest()
        {
            var nums = new int[] { 3, 0, 0, 1, 4};
            var actual = JumpGame.CanJump(nums);
            Assert.AreEqual(false, actual);
        }
    }
}