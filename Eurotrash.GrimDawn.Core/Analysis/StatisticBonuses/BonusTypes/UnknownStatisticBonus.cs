using System;

namespace Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes
{
    public class UnknownStatisticBonus : IStatisticBonus
    {
        public string BonusType { get { return "Unknown bonus"; } }

        public string Text { get; set; }

        public IStatisticBonus StackWith(IStatisticBonus other)
        {
            // TODO: figure out an elegant way to deal with stacking unknown elements
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<Data.Devotions.StatisticBonus> SourceBonuses
        {
            get { yield return this.SourceBonus; }
        }

        public Data.Devotions.StatisticBonus SourceBonus { get; set; }

        public int OrderingValue
        {
            get { return Int32.MinValue; }
        }
    }
}
