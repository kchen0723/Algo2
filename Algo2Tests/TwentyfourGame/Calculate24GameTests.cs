using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo2.TwentyfourGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.TwentyfourGame.Tests
{
    [TestClass()]
    public class Calculate24GameTests
    {
        [TestMethod()]
        public void GetFormulasTest()
        {
            var result = Calculate24Game.GetFormulas();
            Assert.IsNotNull(result);
        }
    }
}