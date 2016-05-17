using Eurotrash.GrimDawn.Core.Data.Devotions;
using System.Collections.Generic;
namespace Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses
{
    public interface IStatisticBonus
    {
        string BonusType { get; }

        string Text { get; }

        IStatisticBonus StackWith(IStatisticBonus other);

        IEnumerable<StatisticBonus> SourceBonuses { get; }

        int OrderingValue { get; }
    }
}
