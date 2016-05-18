using Eurotrash.GrimDawn.Core.Data.Devotions;

namespace Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses
{
    internal interface IStatisticBonusParser
    {
        IStatisticBonus TryParse(string text, StatisticBonus sourceBonus);
    }
}
