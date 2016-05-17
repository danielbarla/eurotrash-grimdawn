using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eurotash.GrimDawn.Core.Analysis.Affinities;

namespace Eurotrash.GrimDawn.Test
{
    [TestClass]
    public class AffinitySetTest
    {
        [TestMethod]
        public void AffinitySetStackingTest()
        {
            var set1 = new AffinitySet(chaos: 4);

            Assert.AreEqual(4, set1.Chaos);
            Assert.AreEqual("4 Chaos", set1.ToString());

            var set2 = new AffinitySet(chaos: 1, eldritch: 10);

            var set3 = set1.Add(set2);

            Assert.AreEqual(5, set3.Chaos);
            Assert.AreEqual(10, set3.Eldritch);
            Assert.AreEqual("5 Chaos, 10 Eldritch", set3.ToString());
        }
    }
}
