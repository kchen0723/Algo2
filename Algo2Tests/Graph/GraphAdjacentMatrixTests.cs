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
    }
}