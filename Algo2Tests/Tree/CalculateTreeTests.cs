using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tree.Tests
{
    [TestClass()]
    public class CalculateTreeTests
    {
        [TestMethod()]
        public void SerializeTest()
        {
            var root = CreateCalculateTree();
            var actual = CalculateTree.Serialize(root);
            Assert.IsNull(actual);
        }

        private TreeNode<string> CreateCalculateTree()
        {
            var eight = new TreeNode<string>() { NodeValue = "8" };
            var four = new TreeNode<string>() { NodeValue = "4" };
            var divid = new TreeNode<string>() { NodeValue = "/", Left = eight, Right = four };

            var first = new TreeNode<string>() { NodeValue = "1" };
            var add = new TreeNode<string>() { NodeValue = "+", Left = first, Right = divid };

            var five = new TreeNode<string>() { NodeValue = "5" };
            var three = new TreeNode<string>() { NodeValue = "3" };
            var minus = new TreeNode<string>() { NodeValue = "-", Left = five, Right = three };

            var multiple = new TreeNode<string>() { NodeValue = "*", Left = add, Right = minus };
            return multiple;
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            var str = "(1+8/4)*(5-3)";
            var root = CalculateTree.Deserialize<string>(str);
            Assert.IsNull(root);
        }

        [TestMethod()]
        public void CalculateTreeValueTest()
        {
            var str = "(1+8/4)*(5-3)";
            var root = CalculateTree.Deserialize<string>(str);
            var actual = CalculateTree.CalculateTreeValue(root);
            Assert.AreEqual(6, actual);
        }
    }
}