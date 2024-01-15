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
    public class WeightRandomTests
    {
        [TestMethod()]
        public void GetRandomValueTest()
        {
            var arr = new float[] { 1, 2, 3, 4.5f };
            var actual = WeightRandom.GetRandomValue(arr);
        }
    }
}