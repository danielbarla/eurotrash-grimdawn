using Eurotash.GrimDawn.Core.Data.Devotions;
using System;
using System.Collections.Generic;

namespace Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes
{
    public class StatisticBonusBase : IStatisticBonus
    {
        protected List<StatisticBonus> _sourceBonuses = new List<StatisticBonus>();

        public string BonusType { get; protected set; }

        public string Text { get; protected set; }

        public virtual IStatisticBonus StackWith(IStatisticBonus other)
        {
            throw new NotImplementedException("Base class does not implement the stack method - override on child class");
        }

        public override string ToString()
        {
            return this.Text;
        }

        public System.Collections.Generic.IEnumerable<Data.Devotions.StatisticBonus> SourceBonuses
        {
            get { return _sourceBonuses; }
        }

        public virtual int OrderingValue
        {
            get { throw new NotImplementedException(); }
        }
    }
}
