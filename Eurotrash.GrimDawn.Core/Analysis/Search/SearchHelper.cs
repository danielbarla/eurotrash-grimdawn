using Eurotrash.GrimDawn.Core.Data;
using Eurotrash.GrimDawn.Core.Data.Devotions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Eurotrash.GrimDawn.Core.Analysis.Search
{
    public static class SearchHelper
    {
        public static Constellation[] Find(Constellation[] data, SearchCriteria criteria)
        {
            var constellations = data.Where(constellation => IsMatch(constellation, criteria))
                                     .OrderBy(constellation => constellation.RequirementTotal)
                                     .ToArray();

            return constellations;
        }

        public static bool IsMatch(StatisticBonus bonus, SearchCriteria criteria)
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

        public static bool IsMatch(Star star, SearchCriteria criteria)
        {
            return star.StatisticsBonuses.Any(bonus => IsMatch(bonus, criteria));
        }

        public static bool IsMatch(Constellation constellation, SearchCriteria criteria)
        {
            return StringContains(constellation.Name, criteria.SearchTerms) || constellation.Stars.Any(star => IsMatch(star, criteria));
        }
    }
}
