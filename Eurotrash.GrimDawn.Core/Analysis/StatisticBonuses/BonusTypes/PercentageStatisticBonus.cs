using Eurotash.GrimDawn.Core.Data.Devotions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Eurotash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes
{
    public class PercentageStatisticBonus : StatisticBonusBase
    {
        public PercentageStatisticBonus(int percentage, string category, IEnumerable<StatisticBonus> sourceBonuses)
        {
            this.Percentage = percentage;
            this.Category = category;

            this.BonusType = String.Format("Percentage bonus to " + category);
            this.Text = String.Format("{0}{1}% {2}", this.Percentage >= 0 ? "+" : "", this.Percentage, this.Category);

            base._sourceBonuses.AddRange(sourceBonuses);
        }

        public int Percentage { get; set; }

        public string Category { get; set; }

        public override IStatisticBonus StackWith(IStatisticBonus other)
        {
            var that = other as PercentageStatisticBonus;

            if (that == null || that.Category != this.Category)
                throw new ApplicationException("Cannot stack two bonuses with different types!");

            return new PercentageStatisticBonus(this.Percentage + that.Percentage, this.Category, this.SourceBonuses.Union(other.SourceBonuses));
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
