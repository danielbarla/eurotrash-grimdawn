using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eurotash.GrimDawn.Core.Analysis.StatisticBonuses;
using Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes;

namespace Eurotrash.GrimDawn.Test
{
    [TestClass]
    public class StatisticBonusParserTests
    {
        [TestMethod]
        public void ParseAndStackPercentageBonuses()
        {
            var a = StatisticBonusParser.Parse("+50% Acid Damage") as PercentageStatisticBonus;
            var b = StatisticBonusParser.Parse("+20% Acid Damage") as PercentageStatisticBonus;

            var c = a.StackWith(b) as PercentageStatisticBonus;

            Assert.AreEqual(70, c.Percentage);
        }

        [TestMethod]
        public void ParseAndStackNegativePercentageBonuses()
        {
            var a = StatisticBonusParser.Parse("-5% Skill Energy Cost") as PercentageStatisticBonus;
            var b = StatisticBonusParser.Parse("-2% Skill Energy Cost") as PercentageStatisticBonus;

            var c = a.StackWith(b) as PercentageStatisticBonus;

            Assert.AreEqual(-7, c.Percentage);
        }

        [TestMethod]
        public void FlatBonusParser()
        {
            var a = StatisticBonusParser.Parse("+8 Spirit") as FlatStatisticBonus;

            Assert.IsNotNull(a);
        }
        
    }
}
