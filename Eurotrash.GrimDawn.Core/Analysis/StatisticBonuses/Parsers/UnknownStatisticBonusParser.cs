using Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes;
using Eurotrash.GrimDawn.Core.Data.Devotions;

namespace Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.Parsers
{
    /// <summary>
    /// A default class for statistics bonuses which cannot be identified.
    /// </summary>
    internal class UnknownStatisticBonusParser : IStatisticBonusParser
    {
        public IStatisticBonus TryParse(string text, StatisticBonus bonus)
        {
            return new UnknownStatisticBonus() { Text = text, SourceBonus = bonus };
        }
    }
}
