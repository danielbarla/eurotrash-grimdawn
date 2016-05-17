using Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes;
using Eurotrash.GrimDawn.Core.Data.Devotions;
using System;

namespace Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.Parsers
{
    internal class UnknownStatisticBonusParser : IStatisticBonusParser
    {
        public IStatisticBonus TryParse(string text, StatisticBonus bonus)
        {
            return new UnknownStatisticBonus() { Text = text, SourceBonus = bonus };
        }
    }
}
