using Newtonsoft.Json;
using System;

namespace Eurotrash.GrimDawn.Core.Data.Devotions
{
    public class StatisticBonus
    {
        public StatisticBonus()
        {
        }

        public string Text { get; set; }

        public Affinity[] AffinityBonuses { get; set; }

        [JsonIgnore]
        public Star Star { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
