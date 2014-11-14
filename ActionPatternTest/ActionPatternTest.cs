using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tonari.ActionPattern;

namespace ActionPatternTest
{
    [TestClass]
    public class ActionPatternTest
    {
        [TestMethod]
        public void TestMethod3()
        {
            1.Match(ActionPattern<int>
                .Pattern(1, x => Assert.AreEqual(1, x))
                .Pattern(0, x => Assert.Fail())
                .Pattern(2, x => Assert.Fail()));
        }

        [TestMethod]
        public void TestMethod4()
        {
            1.Match(ActionPattern<int>
                .Pattern(x => x == 1, x => Assert.AreEqual(1, x))
                .Pattern(x => x == 0, x => Assert.Fail())
                .Pattern(x => x == 2, x => Assert.Fail()));
        }

        [TestMethod]
        public void TestMethod5()
        {
            1.Match(ActionPattern<int>
                .Pattern(x => x == 0, x => Assert.Fail())
                .Default(x => Assert.AreEqual(1, x)));
        }

        [TestMethod]
        public void TestMethod6()
        {
            ((string)null).Match(ActionPattern<string>
                .Pattern(string.Empty, x => Assert.Fail())
                .CatchNull(x => Assert.AreEqual(default(string), x))
                .Default(x => Assert.Fail()));
        }

        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual(string.Empty.Length,
                string.Empty.Match(ActionPattern<string, int>
                    .Pattern(string.Empty, x => x.Length)));
        }

        [TestMethod]
        public void TestMethod9()
        {
            Assert.AreEqual(string.Empty.Length,
                string.Empty.Match(ActionPattern<string, int, int>
                    .Pattern(string.Empty, (x, y) => x.Length + y), 5), 5);

            Assert.AreEqual(string.Empty.Length + 5,
                string.Empty.Match(ActionPattern<string, int, int>
                    .Pattern(x => x == string.Empty, (x, y) => x.Length + y), 5));
        }

        [TestMethod]
        [ExpectedException(typeof(UndefinedDefaultPatternException))]
        public void TestMethod10()
        {
            var p = ActionPattern<int>
                .Pattern(0, x => { });
            1.Match(p);
        }

        [TestMethod]
        public void TestMethod11()
        {
            var p1 = ActionPattern<string, string>
                .Pattern((x, y) => x == y, (x, y) => Assert.AreEqual(x, y))
                .Default((x, y) => { });
            "m".Match(p1, "m");

            var p2 = ActionPattern<string, string, int>
                .Pattern((x, y) => x == y, (x, y) => x.Length + y.Length)
                .CatchNull((x, y) => 0)
                .Default((x, y) => { Assert.Fail(); return 0; });
            "m".Match(p2, null);
        }

        [TestMethod]
        public void TestMethod12()
        {
            var evenCount = 0;
            var p = ActionPattern<int>
                .Pattern(x => x % 2 == 0, x => ++evenCount)
                .Default(x => { }); ;
            var tracing = Enumerable.Range(0, 5).MatchTrace(p);
            Assert.AreEqual(0, evenCount);
            tracing.ToList();
            Assert.AreEqual(3, evenCount);
        }
    }
}