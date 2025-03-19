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
            BinaryTree<int> bt = CreateTestingTree();
            var result = bt.GetLowestCommonAncestorByDp(9, 5);
            Assert.AreEqual(7, result.NodeValue);
        }

        [TestMethod()]
        public void MinTest()
        {
            BinaryTree<int> bt = CreateTestingTree();
            var min = BinaryTree<int>.Min(bt);
            Assert.AreEqual(2, min);
            var max = BinaryTree<int>.Max(bt);
            Assert.AreEqual(9, max);
        }

        private BinaryTree<int> CreateTestingTree()
        {
            TreeNode<int> nine = new TreeNode<int>() { NodeValue = 9 };
            TreeNode<int> six = new TreeNode<int>() { NodeValue = 6, Left = nine };

            TreeNode<int> two = new TreeNode<int>() { NodeValue = 2 };
            TreeNode<int> four = new TreeNode<int>() { NodeValue = 4 };
            TreeNode<int> five = new TreeNode<int>() { NodeValue = 5, Left = two, Right = four };

            TreeNode<int> seven = new TreeNode<int>() { NodeValue = 7, Left = six, Right = five };
            TreeNode<int> three = new TreeNode<int>() { NodeValue = 3 };

            TreeNode<int> eight = new TreeNode<int>() { NodeValue = 8, Left = seven, Right = three };

            BinaryTree<int> bt = new BinaryTree<int>() { Root = eight };
            return bt;
        }

        [TestMethod()]
        public void PreOrderIterationTest()
        {
            BinaryTree<int> bt = CreateTestingTree();
            bt.PreOrderIteration(bt.Root);
        }

        [TestMethod()]
        public void InOrderIterationTest()
        {
            BinaryTree<int> bt = CreateTestingTree();
            bt.InOrderIteration(bt.Root);
        }

        [TestMethod()]
        public void PostOrderIterationTest()
        {
            BinaryTree<int> bt = CreateTestingTree();
            bt.PostOrderIteration(bt.Root);
        }

        [TestMethod()]
        public void FindMaxSpanTest()
        {
            BinaryTree<int> bt = CreateTestingTree();
            var maxSpan = bt.FindMaxSpan(bt);
            Assert.AreEqual(5, maxSpan);
        }

        [TestMethod()]
        public void IsSymmetricTest()
        {
            BinaryTree<int> bt = CreateTestingTree();
            var actual = bt.IsSymmetric(bt);
            Assert.AreEqual(false, actual);
        }
    }
}