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
    public class StringCrossTests
    {
        [TestMethod()]
        public void GetCrossNumberTest()
        {
            var arr = new string[] { "dig", "lot", "dog", "bot", "dot" };
            var result = StringCross.GetCrossNumberByBackTracking(arr, "bot");
            Assert.AreEqual(result, 3);
        }
    }
}