using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.List.Tests
{
    [TestClass()]
    public class LinkedListDSTests
    {
        [TestMethod()]
        public void AppendTest()
        {
            CreateLinkedList();
        }

        private LinkedListDS<int> CreateLinkedList()
        {
            var linkedList = new LinkedListDS<int>();
            linkedList.Append(1);
            linkedList.Append(2);
            return linkedList; 
        }

        [TestMethod()]
        public void ClearTest()
        {
            var linkedList = CreateLinkedList();
            linkedList.Clear();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var linkedList = CreateLinkedList();
            linkedList.Delete(1);
        }

        [TestMethod()]
        public void FindTest()
        {
            var linkedList = CreateLinkedList();
            linkedList.Find(1);
        }

        [TestMethod()]
        public void InsertTest()
        {
            var linkedList = CreateLinkedList();
            linkedList.Insert(1, 4);
        }
    }
}