using Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes;
using Eurotrash.GrimDawn.Core.Data.Devotions;
using System;
using System.Text.RegularExpressions;

namespace Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.Parsers
{
    /// <summary>
    /// Parser for the PercentageStatisticBonus class.
    /// </summary>
    internal class PercentageStatisticBonusParser : IStatisticBonusParser
    {
        /// <example>
        /// "+5% Physical Damage"
        /// "5% Physical Damage"
        /// "-5% Fire Damage"
        /// </example>
        private Regex _parserRegex = new Regex(@"^\s*([+-]*\d+)[%]\s+(.+)$");

        public IStatisticBonus TryParse(string text, StatisticBonus sourceBonus)
        {
            var match = _parserRegex.Match(text);

            if (!match.Success)
                return null;

            string percentagePart = match.Groups[1].Value;
            string categoryPart = match.Groups[2].Value;

            int percentage = 0;
            if (!Int32.TryParse(percentagePart, out percentage))
                return null;

            return new PercentageStatisticBonus(percentage, categoryPart, new [] { sourceBonus });
        }
    }
}
