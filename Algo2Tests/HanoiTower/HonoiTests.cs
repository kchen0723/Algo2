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
    public class HanoiTests
    {
        [TestMethod()]
        public void SolveTest()
        {
            var source = new HanoiEntity() { Name = "Source", Data = new Stack<int>(new int[] { 3, 2, 1 }) };
            var target = new HanoiEntity() { Name = "Target" };
            var auxiliary = new HanoiEntity() { Name = "Auxiliary" };
            Hanoi.SolveByRecursive(source, auxiliary, target);
        }

        [TestMethod()]
        public void SolveByIterationTest()
        {
            var source = new HanoiEntity() { Name = "Source", Data = new Stack<int>(new int[] { 3, 2, 1 }) };
            var target = new HanoiEntity() { Name = "Target" };
            var auxiliary = new HanoiEntity() { Name = "Auxiliary" };
            Hanoi.SolveByIteration(source, auxiliary, target);
        }
    }
}