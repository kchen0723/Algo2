﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Tree.Tests
{
    [TestClass()]
    public class BinarySearchTreeTests
    {
        [TestMethod()]
        public void FindTest()
        {
            TreeNode<int> five = new TreeNode<int>() { NodeValue = 5 };
            TreeNode<int> three = new TreeNode<int>() { NodeValue = 3 };
            TreeNode<int> seven = new TreeNode<int>() { NodeValue = 7, Left = three, Right = five };

            TreeNode<int> six = new TreeNode<int>() { NodeValue = 6 };
            TreeNode<int> eight = new TreeNode<int>() { NodeValue = 8, Left = six };

            TreeNode<int> nine = new TreeNode<int>() { NodeValue = 9, Left = seven, Right = eight };

            BinarySearchTree<int> bt = new BinarySearchTree<int>() { Root = nine };
            var result = bt.Find(3);
            result = bt.FindMaxNodeWhichIsSmallerThanTarget(9);
            Assert.IsNotNull(result);
        }
    }
}