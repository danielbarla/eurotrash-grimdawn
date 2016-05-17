using System;

namespace Eurotash.GrimDawn.Core.Data.Devotions
{
    public class Affinity
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public override string ToString()
        {
            return String.Format("{0}: {1}", this.Name, this.Value);
        }
    }
}
