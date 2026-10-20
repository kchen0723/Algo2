using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.GreedyAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.GreedyAlgorithm.Tests
{
    [TestClass()]
    public class RadioCoverTests
    {
        [TestMethod()]
        public void MinConverTest()
        {
            HashSet<string> first = new HashSet<string>() { "北京", "上海", "天津"};
            HashSet<string> second = new HashSet<string>() { "广州", "北京", "深圳" };
            HashSet<string> third = new HashSet<string>() { "成都", "上海", "杭州" };
            HashSet<string> fouth = new HashSet<string>() { "上海", "天津" };
            HashSet<string> fifth = new HashSet<string>() { "杭州", "大连" };

            RadioCover rc = new RadioCover();
            var actual = rc.MinConver(new List<HashSet<string>> { first, second, third, fouth, fifth });
            Assert.AreEqual(actual.Count, 4);
        }
    }
}