using System;
using System.ActionPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionPatternTest
{
    [TestClass]
    public class ActionPatternTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            1.Pattern(1, x => Assert.AreEqual(1, x));

            1.Pattern(0, x => Assert.Fail());
            1.Pattern(2, x => Assert.Fail());
        }

        [TestMethod]
        public void TestMethod2()
        {
            1.Pattern(x => x == 1, x => Assert.AreEqual(1, x));
            1.Pattern(x => x == 0, x => Assert.Fail());
            1.Pattern(x => x == 2, x => Assert.Fail());
        }
        [TestMethod]
        public void TestMethod3()
        {
            1.Match(ActionPattern
                .Pattern(1, x => Assert.AreEqual(1, x))
                .Pattern(0, x => Assert.Fail())
                .Pattern(2, x => Assert.Fail()))();
        }

        [TestMethod]
        public void TestMethod4()
        {
            1.Match(ActionPattern<int>
                .Pattern(x => x == 1, x => Assert.AreEqual(1, x))
                .Pattern(x => x == 0, x => Assert.Fail())
                .Pattern(x => x == 2, x => Assert.Fail()))();
        }

        [TestMethod]
        public void TestMethod5()
        {
            1.Match(ActionPattern<int>
                .Pattern(x => x == 0, x => Assert.Fail())
                .Default(x => Assert.AreEqual(1, x)))();
        }

        [TestMethod]
        public void TestMethod6()
        {
            ((string)null).Match(ActionPattern
                .Pattern(string.Empty, x => Assert.Fail())
                .CatchNull(x => Assert.AreEqual(default(string), x))
                .Default(x => Assert.Fail()))();
        }

        [TestMethod]
        public void TestMethod7()
        {
            string.Empty.Match(ActionPattern<string>
                .Select(x => x.Length)
                .Pattern(string.Empty.Length, x => Assert.AreEqual(string.Empty.Length, x))
                .CatchNull(x => Assert.Fail())
                .Default(x => Assert.Fail()))();

            ((string)null).Match(ActionPattern<string>
                .Select(x => x.Length)
                .Pattern(0, x => Assert.Fail())
                .CatchNull(x => Assert.AreEqual(default(int), x))
                .Default(x => Assert.Fail()))();
        }

        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual(string.Empty.Length,
                string.Empty.Match(ActionPattern
                    .Pattern(string.Empty, x => x.Length))());
        }
    }
}
