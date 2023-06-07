﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2;
using Algo2.BinarySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.BinarySearch.Tests
{
    [TestClass()]
    public class BinarySearchTests
    {
        [TestMethod()]
        public void FindInSortedUniqueArrayTest()
        {
            var arr = Utility.ArrayHelper.CreateUniquueSortedList(12, 25).ToArray();
            var actual = BinarySearch.FindInSortedUniqueArray(arr, 16);
            //Assert.AreEqual(4, actual);
        }
    }
}