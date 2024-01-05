using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Pramp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Pramp.Tests
{
    [TestClass()]
    public class ReverseWordsTests
    {
        [TestMethod()]
        public void ReverseTest()
        {
            var words = "hello world pao";
            var result = ReverseWords.Reverse(words);
            Assert.AreEqual("pao world hello", result);
        }
    }
}