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
    public class ContainerTests
    {
        [TestMethod()]
        public void ContainerTest()
        {
            var c = new Container.Container<int>();
            Assert.IsNotNull(c);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var c = new Container.Container<int>();
            c.Insert(2);
            c.Insert(3);
            c.Delete(3);
            Assert.IsNotNull(c);
        }

        [TestMethod()]
        public void InsertTest()
        {
            var c = new Container.Container<int>();
            c.Insert(2);
            c.Insert(3);
            Assert.IsNotNull(c);
        }
    }
}