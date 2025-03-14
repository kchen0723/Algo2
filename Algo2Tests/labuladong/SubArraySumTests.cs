﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.labuladong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.labuladong.Tests
{
    [TestClass()]
    public class SubArraySumTests
    {
        [TestMethod()]
        public void SubArraySumCountTest()
        {
            var arr = new int[] { 3, 5, 2, -2, 4, 1 };
            var actual = SubArraySum.SubArraySumCount(arr, 8);
            Assert.AreEqual(2, actual);
        }

        [TestMethod()]
        public void SubArraySumCountByDirectoryTest()
        {
            var arr = new int[] { 3, 5, 2, -2, 4, 1 };
            var actual = SubArraySum.SubArraySumCountByDirectory(arr, 8);
            Assert.AreEqual(2, actual);
        }

        [TestMethod()]
        public void GetMaxSubArraySumTest()
        {
            var arr = new int[] { -2, 5, 3, -6, 4, -8, 6 };
            var actual = SubArraySum.GetMaxSubArraySum(arr);
            Assert.AreEqual(8, actual);
        }
    }
}