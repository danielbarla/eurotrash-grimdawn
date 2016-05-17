using System;
using System.Linq;

namespace Eurotash.GrimDawn.Core.Data.Devotions
{
    public class Constellation
    {
        public Constellation()
        {
        }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Quote { get; set; }

        public Affinity[] Requirements { get; set; }

        public Affinity[] CompletionBonuses { get; set; }

        public int RequirementTotal
        {
            get { return this.Requirements.Sum(item => item.Value); }
        }

        public Star[] Stars { get; set; }

        public override string ToString()
        {
            return String.Format("{0}\n{1}", this.Name, String.Join("\n", this.Stars.Select(item => item.ToString())));
        }

        public void Initialise()
        {
            foreach (var star in this.Stars)
            {
                star.Constellation = this;
                star.Initialise();
            }
        }
    }
}
