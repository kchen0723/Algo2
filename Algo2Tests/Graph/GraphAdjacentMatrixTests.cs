using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph.Tests
{
    [TestClass()]
    public class GraphAdjacentMatrixTests
    {
        [TestMethod()]
        public void IsBiPartiteTest()
        {
            var graph = new GraphAdjacentMatrix(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            var actual = graph.IsBiPartite();
            Assert.IsTrue(actual);
            actual = graph.IsBiPartiteBfs();
            Assert.IsTrue(actual);
        }

        private GraphAdjacentMatrix CreateGraphForTestingMap()
        {
            var result = new GraphAdjacentMatrix(6);
            result.AddEdge(0, 1, 1);
            result.AddEdge(0, 2, 12);
            result.AddEdge(1, 2, 9);
            result.AddEdge(1, 3, 3);
            result.AddEdge(1, 5, 17, true);
            result.AddEdge(2, 4, 5);
            result.AddEdge(3, 2, 4);
            result.AddEdge(3, 4, 13);
            result.AddEdge(3, 5, 15);
            result.AddEdge(4, 0, 7);
            result.AddEdge(4, 5, 4);
            return result;
        }

        [TestMethod()]
        public void FindShortestPathByBackTrackingTest()
        {
            var graph = CreateGraphForTestingMap();
            var actual = graph.FindShortestPathByBackTracking(0, 5);
            Assert.AreEqual(17, actual);
        }

        [TestMethod()]
        public void FloydAlgorithmTest()
        {
            var graph = CreateGraphForTestingMap();
            var actual = graph.FloydAlgorithm();

        }
    }
}