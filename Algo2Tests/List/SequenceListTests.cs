﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.List.Tests
{
    [TestClass()]
    public class SequenceListTests
    {
        private SequenceList<int> CreateList()
        {
            var linkedList = new SequenceList<int>();
            linkedList.Append(1);
            linkedList.Append(2);
            return linkedList;
        }

        [TestMethod()]
        public void AppendTest()
        {
            CreateList();
        }

        [TestMethod()]
        public void ClearTest()
        {
            var list = CreateList();
            list.Clear();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var list = CreateList();
            list.Delete(2);
        }

        [TestMethod()]
        public void FindTest()
        {
            var list = CreateList();
            list.Find(1);
        }

        [TestMethod()]
        public void InsertTest()
        {
            var list = CreateList();
            list.InsertAfter(1, 5);
        }

        [TestMethod()]
        public void TraverseRecursiveTest()
        {
            var list = CreateList();
            list.TraverseRecursive((item) => Console.WriteLine(item));
        }

        [TestMethod()]
        public void TraverseIterationTest()
        {
            var list = CreateList();
            list.TraverseIteration((item) => Console.WriteLine(item));
        }
    }
}