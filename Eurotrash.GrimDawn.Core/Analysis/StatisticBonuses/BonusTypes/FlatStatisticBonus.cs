using Eurotash.GrimDawn.Core.Data.Devotions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes
{
    public class FlatStatisticBonus : StatisticBonusBase
    {
        public FlatStatisticBonus(int amount, string category, IEnumerable<StatisticBonus> sourceBonuses)
        {
            this.Amount = amount;
            this.Category = category;

            this.BonusType = String.Format("Flat bonus to " + category);
            this.Text = String.Format("{0} {1}", this.Amount, this.Category);

            base._sourceBonuses.AddRange(sourceBonuses);
        }

        public int Amount { get; set; }

        public string Category { get; set; }

        public override IStatisticBonus StackWith(IStatisticBonus other)
        {
            var that = other as FlatStatisticBonus;

            if (that == null || that.Category != this.Category)
                throw new ApplicationException("Cannot stack two bonuses with different types!");

            return new FlatStatisticBonus(this.Amount + that.Amount, this.Category, this.SourceBonuses.Union(other.SourceBonuses));
        }

        public override int OrderingValue
        {
            get
            {
                return this.Amount;
            }
        }
    }
}
