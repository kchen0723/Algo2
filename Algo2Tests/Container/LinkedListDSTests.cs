using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Container.Tests
{
    [TestClass()]
    public class LinkedListDSTests
    {
        [TestMethod()]
        public void DeleteTest()
        {
            LinkedListDS<int> linkedListDS = new LinkedListDS<int>(new int[] { 4, 5, 7, 8, 9 });
            linkedListDS.Delete(8);
            Assert.AreEqual(4, linkedListDS.Count);
        }
    }
}