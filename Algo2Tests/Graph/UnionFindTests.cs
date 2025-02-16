using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph.Tests
{
    [TestClass()]
    public class UnionFindTests
    {
        //给你⼀个数组 equations ，装着若⼲字符串表⽰的算式。每个算式
        //equations[i] ⻓度都是 4，⽽且只有这两种情况： a==b 或者 a!=b ，其
        //中 a,b 可以是任意⼩写字⺟。你写⼀个算法，如果 equations 中所有算
        //式都不会互相冲突，返回 true，否则返回 false。
        //⽐如说，输⼊ ["a==b","b!=c","c==a"] ，算法返回 false，因为这三个算式
        //不可能同时正确
        [TestMethod()]
        public void UnionFindTest()
        {
            var equations = new string[] { "a==b", "b!=c", "c==a"};
            var result = EquationPossible(equations);
            Assert.AreEqual(false, result);
        }

        private bool EquationPossible(string[] equations)
        {
            UnionFind uf = new UnionFind(26);
            foreach (string equation in equations)
            {
                if (equation[1] == '=')
                {
                    var p = equation[0];
                    var q = equation[3]; 
                    uf.Union(p - 'a', q - 'a');
                }
            }
            foreach (string equation in equations)
            {
                if (equation[1] == '!')
                {
                    var p = equation[0];
                    var q = equation[3];
                    if (uf.IsConnected(p - 'a', q - 'a'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}