using Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.Parsers;
using Eurotash.GrimDawn.Core.Data.Devotions;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eurotash.GrimDawn.Core.Analysis.StatisticBonuses
{
    public static class StatisticBonusParser
    {
        private static IStatisticBonusParser[] _parsers = new IStatisticBonusParser[] {
            new PercentageStatisticBonusParser(),
            new FlatStatisticBonusParser(),
            new ReversedPercentageStatisticBonusParser(),
            new UnknownStatisticBonusParser()
        };

        public static IStatisticBonus Parse(string text, StatisticBonus sourceBonus = null)
        {
            foreach (var parser in _parsers)
            {
                var result = parser.TryParse(text, sourceBonus);

                if (result != null)
                    return result;
            }

            throw new ApplicationException("No parser could be found for statistics item text: " + text);
        }
    }
}
