using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.HanoiTower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.HanoiTower.Tests
{
    [TestClass()]
    public class HonoiTests
    {
        [TestMethod()]
        public void SolveTest()
        {
            var source = new HonoiEntity() { Name = "Source", Data = new List<int>() { 1, 2, 3, 4 } };
            var target = new HonoiEntity() { Name = "Target" };
            var help = new HonoiEntity() { Name = "Help" };
            Honoi.Solve(source, help, target);
        }
    }
}