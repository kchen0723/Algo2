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
    public class AwardBudgetCutsTests
    {
        [TestMethod()]
        public void CalculateCapTest()
        {
            var grants = new double[] { 2, 100, 50, 120, 1000 };
            var cap = AwardBudgetCuts.CalculateCap(grants, 190);
            Assert.AreEqual(47, cap);
        }
    }
}