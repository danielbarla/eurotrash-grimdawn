using Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes;
using Eurotash.GrimDawn.Core.Data.Devotions;
using System;

namespace Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.Parsers
{
    internal class UnknownStatisticBonusParser : IStatisticBonusParser
    {
        public IStatisticBonus TryParse(string text, StatisticBonus bonus)
        {
            return new UnknownStatisticBonus() { Text = text, SourceBonus = bonus };
        }
    }
}
