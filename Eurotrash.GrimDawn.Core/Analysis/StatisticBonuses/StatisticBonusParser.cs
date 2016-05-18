using Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.Parsers;
using Eurotrash.GrimDawn.Core.Data.Devotions;
using System;

namespace Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses
{
    /// <summary>
    /// Parses statistics bonus text (e.g. "+50% Acid Damage"), and returns an
    /// IStatisticBonus object, which can then be used for aggregating bonuses,
    /// etc.
    /// </summary>
    public static class StatisticBonusParser
    {
        /// <summary>
        /// A simple registry of parsers, in order of precedence.  Order is
        /// very important, because the first one that finds a match will 
        /// return a result.  Therefore we go from most specific to least
        /// specific, with Unknown..() always returning a very generic, not
        /// particularly useful object.
        /// </summary>
        private static IStatisticBonusParser[] _parsers = new IStatisticBonusParser[] {
            new PercentageStatisticBonusParser(),
            new FlatStatisticBonusParser(),
            new ReversedPercentageStatisticBonusParser(),
            new UnknownStatisticBonusParser()
        };

        /// <summary>
        /// Returns an IStatisticBonus object representing the passed in text,
        /// by trying parsers from most specific to least specific.
        /// </summary>
        /// <param name="text">The statistics bonus text to parse.</param>
        /// <param name="sourceBonus">The DTO from which the bonus originates.
        /// This is used to keep tract of the source of the bonus, on screens
        /// where aggregated results are shown.
        /// </param>
        public static IStatisticBonus Parse(string text, StatisticBonus sourceBonus = null)
        {
            foreach (var parser in _parsers)
            {
                var result = parser.TryParse(text, sourceBonus);

                if (result != null)
                    return result;
            }

            // We should never hit this line, as the last parser will take text
            // of any format and return an object.
            throw new ApplicationException("No parser could be found for statistics item text: " + text);
        }
    }
}
