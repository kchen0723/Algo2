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
    public class TimePlannerTests
    {
        [TestMethod()]
        public void GetMeetingPlannerTest()
        {
            var slotA = new int[,] { { 10, 30 }, { 60, 70 }, { 120, 140 } };
            var slotB = new int[,] { { 15, 20 }, { 61, 78 }, { 130, 200 } };
            var result = TimePlanner.GetMeetingPlanner(slotA, slotB, 8);
            Assert.AreEqual(result, 61);
        }
    }
}