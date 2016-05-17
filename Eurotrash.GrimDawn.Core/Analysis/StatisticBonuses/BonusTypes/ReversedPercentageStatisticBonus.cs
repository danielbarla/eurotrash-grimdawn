using Eurotrash.GrimDawn.Core.Data.Devotions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes
{
    public class ReversedPercentageStatisticBonus : StatisticBonusBase
    {
        public ReversedPercentageStatisticBonus(int percentage, string category, IEnumerable<StatisticBonus> sourceBonuses)
        {
            this.Percentage = percentage;
            this.Category = category;

            this.BonusType = String.Format("Reversed percentage bonus to " + category);
            this.Text = String.Format("{0} {1}%", this.Category, this.Percentage);

            base._sourceBonuses.AddRange(sourceBonuses);
        }

        public int Percentage { get; set; }

        public string Category { get; set; }

        public override IStatisticBonus StackWith(IStatisticBonus other)
        {
            var that = other as ReversedPercentageStatisticBonus;

            if (that == null || that.Category != this.Category)
                throw new ApplicationException("Cannot stack two bonuses with different types!");

            return new ReversedPercentageStatisticBonus(this.Percentage + that.Percentage, this.Category, this.SourceBonuses.Union(other.SourceBonuses));
        }

        public override int OrderingValue
        {
            get
            {
                return this.Percentage;
            }
        }
    }
}
