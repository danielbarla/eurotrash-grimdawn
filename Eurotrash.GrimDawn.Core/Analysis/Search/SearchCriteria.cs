namespace Eurotrash.GrimDawn.Core.Analysis.Search
{
    /// <summary>
    /// Represents the search criteria specified by the user.
    /// </summary>
    /// <remarks>
    /// Currently not particularly useful, but if other options (such as case-
    /// sensitivity, etc) are added, it will serve as a way to group together
    /// these parameters nicely.
    /// </remarks>
    public class SearchCriteria
    {
        public string[] SearchTerms { get; set; }
    }
}
