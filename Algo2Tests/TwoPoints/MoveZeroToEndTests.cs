using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.TwoPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.TwoPoints.Tests
{
    [TestClass()]
    public class MoveZeroToEndTests
    {
        [TestMethod()]
        public void MoveTest()
        {
            var arr = new int[] { 1, 10, 0, 2, 8, 3, 0, 0, 6, 4, 0, 5, 7, 0 };
            MoveZeroToEnd.Move(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}