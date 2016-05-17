using Newtonsoft.Json;
using System;
using System.Linq;

namespace Eurotash.GrimDawn.Core.Data.Devotions
{
    public class Star
    {
        public Star()
        {
        }

        public int Index { get; set; }

        public StatisticBonus[] StatisticsBonuses { get; set; }

        public bool GrantsSkill { get; set; }

        [JsonIgnore]
        public Constellation Constellation { get; set; }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Index, String.Join("\n   ", this.StatisticsBonuses.Select(item => item.ToString())));
        }

        internal void Initialise()
        {
            foreach (var bonus in this.StatisticsBonuses)
                bonus.Star = this;
        }
    }
}
