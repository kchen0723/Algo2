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
    public class EnvelopNestTests
    {
        [TestMethod()]
        public void MaxNestCountTest()
        {
            var r0 = new Rectangle { Width = 1, Height = 13 };
            var r1 = new Rectangle { Width = 5, Height = 4 };
            var r2 = new Rectangle { Width = 6, Height = 4 };
            var r3 = new Rectangle { Width = 6, Height = 7 };
            var r4 = new Rectangle { Width = 2, Height = 3 };
            var r5 = new Rectangle { Width = 3, Height = 10 };
            var rectangles = new Rectangle[] { r0, r1, r2, r3, r4, r5};
            var actual = EnvelopNest.MaxNestCount(rectangles);  //{2, 3} => {5, 4} => {6, 7}
            Assert.AreEqual(3, actual);
        }
    }
}