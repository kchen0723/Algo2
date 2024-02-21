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
    public class ChessQueenTests
    {
        [TestMethod()]
        public void SolveNQueenTest()
        {
            var result = ChessQueen.SolveNQueen(1);
            Assert.AreEqual(1, result.Count);

            result = ChessQueen.SolveNQueen(2);
            Assert.AreEqual(0, result.Count);

            result = ChessQueen.SolveNQueen(3);
            Assert.AreEqual(0, result.Count);

            result = ChessQueen.SolveNQueen(4);
            Assert.AreEqual(2, result.Count);

            result = ChessQueen.SolveNQueen(5);
            Assert.AreEqual(10, result.Count);

            result = ChessQueen.SolveNQueen(6);
            Assert.AreEqual(4, result.Count);

            result = ChessQueen.SolveNQueen(7);
            Assert.AreEqual(40, result.Count);

            result = ChessQueen.SolveNQueen(8);
            Assert.AreEqual(92, result.Count);
        }
    }
}