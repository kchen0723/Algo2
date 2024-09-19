using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Algo2.Tree.Tests
{
    [TestClass()]
    public class BinarySearchTreeTests
    {
        [TestMethod()]
        public void FindTest()
        {
            List<int> lists = new List<int> { 7, 5, 9, 3, 6, 8 };
            BinarySearchTree<int> bt = new BinarySearchTree<int>();
            foreach (var item in lists)
            {
                bt.Insert(item);
            }
            var result = bt.Find(8);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void FindMaxNodeWhichIsSmallerThanTargetTest()
        {
            List<int> lists = new List<int> { 20, 9, 25, 5, 12, 11, 14 };
            BinarySearchTree<int> bt = new BinarySearchTree<int>();
            foreach (var item in lists)
            {
                bt.Insert(item);
            }
            var actual = bt.FindMaxNodeWhichIsSmallerThanTarget(77);
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void IsValidTest()
        {
            TreeNode<int> five = new TreeNode<int>() { NodeValue = 5 };
            TreeNode<int> three = new TreeNode<int>() { NodeValue = 3 };
            TreeNode<int> seven = new TreeNode<int>() { NodeValue = 7, Left = three, Right = five };

            TreeNode<int> six = new TreeNode<int>() { NodeValue = 6 };
            TreeNode<int> eight = new TreeNode<int>() { NodeValue = 8, Left = six };

            TreeNode<int> nine = new TreeNode<int>() { NodeValue = 9, Left = seven, Right = eight };

            BinarySearchTree<int> bt = new BinarySearchTree<int>() { Root = nine };
            var result = BinarySearchTree<int>.IsValid(bt);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void IsValidTest2()
        {
            List<int> lists = new List<int> { 7, 5, 9, 3, 6, 8 };
            BinarySearchTree<int> bt = new BinarySearchTree<int>();
            foreach (var item in lists)
            {
                bt.Insert(item);
            }
            var result = BinarySearchTree<int>.IsValid(bt);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void IsValidBst()
        {
            TreeNode<int> six = new TreeNode<int>() { NodeValue = 6 };
            TreeNode<int> twenty = new TreeNode<int>() { NodeValue = 20 };
            TreeNode<int> fifteen = new TreeNode<int>() { NodeValue = 15, Left = six, Right = twenty };

            TreeNode<int> five = new TreeNode<int>() { NodeValue = 5 };
            TreeNode<int> ten = new TreeNode<int>() { NodeValue = 10, Left = five, Right = fifteen };

            BinarySearchTree<int> bt = new BinarySearchTree<int>() { Root = ten };
            var result = BinarySearchTree<int>.IsValidBst(bt.Root, null, null);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void FindLargestSmallerKeyTest()
        {
            List<int> lists = new List<int> { 20, 9, 25, 5, 12, 11, 14 };
            BinarySearchTree<int> bt = new BinarySearchTree<int>();
            foreach (var item in lists)
            {
                bt.Insert(item);
            }
            var actual = bt.FindLargestSmallerKey(bt.Root, 13);
            Assert.AreEqual(20, actual);
        }
    }
}