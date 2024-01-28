using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.labuladong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Algo2.labuladong.Tests
{
    [TestClass()]
    public class LeastRecentlyUsedTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var cache = new LeastRecentlyUsed<int, int>();
            cache.Put(1, 1);
            cache.Put(2, 2);
            var restult = 0;
            cache.Get(1, ref restult);
            cache.Put(3, 3);
            cache.Get(2, ref restult);
            cache.Put(1, 4);
        }
    }
}