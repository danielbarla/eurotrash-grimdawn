using Eurotrash.GrimDawn.Core.Data.Devotions;
using System.Collections.Generic;

namespace Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses
{
    /// <summary>
    /// Basic interface for a statistics bonus object, implemented by the 
    /// various concrete classes in /BonusTypes.
    /// </summary>
    public interface IStatisticBonus
    {
        /// <summary>
        /// Represents the distinct category that this bonus falls into.  
        /// Bonuses belonging to the same category can be stacked / added
        /// together, e.g. two +5% to Physical Damage bonuses can become
        /// a single +10%.
        /// </summary>
        string BonusType { get; }

        /// <summary>
        /// The full, human-readable text version of the bonus.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Returns the result of the addition of this bonus with the passed in
        /// other bonus.
        /// </summary>
        /// <remarks>
        /// This method should also keep an aggregate of bonus sources for 
        /// future reference.
        /// </remarks>
        IStatisticBonus StackWith(IStatisticBonus other);

        /// <summary>
        /// Where bonus sources were specified, this returns all bonus sources
        /// (in case of aggregation, there will be 2+).
        /// </summary>
        IEnumerable<StatisticBonus> SourceBonuses { get; }

        /// <summary>
        /// A value representing the importance of the statistics bonus. 
        /// </summary>
        /// <remarks>
        /// At the moment, this generally just returns the single number 
        /// associated with the bonus (e.g. +50% just becomes 50), allowing us 
        /// to eyeball which types of bonues have roughly become the most 
        /// prominent ones for our build.
        /// 
        /// In future, some heuristics / multipliers could be put in place to
        /// weight things differently.  E.g. +%Fire damage is probably (much)
        /// less important / valuable than the equivalent -%Fire resistence 
        /// debuff.  The latter should be weighted to become more prominent.
        /// </remarks>
        int OrderingValue { get; }
    }
}
