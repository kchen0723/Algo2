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
    public class BinaryTreeTests
    {
        [TestMethod()]
        public void GetLowestCommonAncestorTest()
        {
            TreeNode<int> nine = new TreeNode<int>() { NodeValue = 9 };
            TreeNode<int> six = new TreeNode<int>() { NodeValue = 6, Left = nine };
            TreeNode<int> five = new TreeNode<int>() { NodeValue = 5 };

            TreeNode<int> seven = new TreeNode<int>() { NodeValue = 7, Left = six, Right = five };
            TreeNode<int> three = new TreeNode<int>() { NodeValue = 3 };

            TreeNode<int> eight = new TreeNode<int>() { NodeValue = 8, Left = seven, Right = three };

            BinaryTree<int> bt = new BinaryTree<int>() { Root = eight };
            var result = bt.GetLowestCommonAncestorByDp(9, 5);
            Assert.AreEqual(7, result.NodeValue);
        }
    }
}