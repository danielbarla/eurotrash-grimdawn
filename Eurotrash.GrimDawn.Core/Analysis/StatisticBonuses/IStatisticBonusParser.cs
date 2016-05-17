using Eurotash.GrimDawn.Core.Data.Devotions;
namespace Eurotash.GrimDawn.Core.Analysis.StatisticBonuses
{
    internal interface IStatisticBonusParser
    {
        IStatisticBonus TryParse(string text, StatisticBonus sourceBonus);
    }
}
