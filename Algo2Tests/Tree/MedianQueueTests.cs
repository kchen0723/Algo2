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
    public class MedianQueueTests
    {
        [TestMethod()]
        public void GetMedianTest()
        {
            var mq = new MedianQueue();
            mq.Enque(13);
            mq.Enque(1);
            Assert.AreEqual(7, mq.GetMedian());
            mq.Enque(-10);
            Assert.AreEqual(1, mq.GetMedian());
            mq.Enque(4);
            Assert.AreEqual(2.5, mq.GetMedian());
            mq.Enque(2);
            Assert.AreEqual(2, mq.GetMedian());
        }
    }
}