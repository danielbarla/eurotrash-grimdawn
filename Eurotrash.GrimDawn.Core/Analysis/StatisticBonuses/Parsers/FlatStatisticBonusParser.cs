using Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes;
using Eurotash.GrimDawn.Core.Data.Devotions;
using System;
using System.Text.RegularExpressions;

namespace Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.Parsers
{
    internal class FlatStatisticBonusParser : IStatisticBonusParser
    {
        private Regex _parserRegex = new Regex(@"^\s*([+-]*\d+)\s+(.+)$");

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

            return new FlatStatisticBonus(percentage, categoryPart, new [] { sourceBonus });
        }
    }
}
