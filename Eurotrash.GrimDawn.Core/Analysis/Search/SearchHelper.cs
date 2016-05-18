using Eurotrash.GrimDawn.Core.Data.Devotions;
using System.Globalization;
using System.Linq;

namespace Eurotrash.GrimDawn.Core.Analysis.Search
{
    /// <summary>
    /// Performs a search on the specified Constellation[], by checking against
    /// the SearchCriteria provided.
    /// </summary>
    /// <remarks>
    /// At the moment searches are defined as:
    ///   - Case insensitive
    ///   - The search "terms" (words) are treated as being separated by OR 
    ///     operators.
    ///   - The terms can match the name of the constellation or any of the 
    ///     statistic bonuses under the stars of that constellation.
    ///   - If a match is found, the entire constellation is returned.
    ///   - The results are ordered by the sum of their affinity requirements.
    /// </remarks>
    public static class SearchHelper
    {
        public static Constellation[] Find(Constellation[] data, SearchCriteria criteria)
        {
            var constellations = data.Where(constellation => IsConstallationMatchForCriteria(constellation, criteria))
                                     .OrderBy(constellation => constellation.RequirementTotal)
                                     .ToArray();

            return constellations;
        }

        public static bool IsConstallationMatchForCriteria(Constellation constellation, SearchCriteria criteria)
        {
            return StringContains(constellation.Name, criteria.SearchTerms) || constellation.Stars.Any(star => IsStarMatchForCriteria(star, criteria));
        }

        public static bool IsStarMatchForCriteria(Star star, SearchCriteria criteria)
        {
            return star.StatisticsBonuses.Any(bonus => IsStatisticBonusMatchForCriteria(bonus, criteria));
        }

        public static bool IsStatisticBonusMatchForCriteria(StatisticBonus bonus, SearchCriteria criteria)
        {
            foreach (string term in criteria.SearchTerms)
            {
                if (StringContains(bonus.Text, term))
                    return true;
            }

            return false;
        }

        private static bool StringContains(string text, string snippet)
        {
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(text, snippet, CompareOptions.IgnoreCase) >= 0;
        }

        private static bool StringContains(string text, params string[] snippets)
        {
            return snippets.Any(item => StringContains(text, item));
        }
    }
}
