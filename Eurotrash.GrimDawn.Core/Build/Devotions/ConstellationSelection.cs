using Eurotash.GrimDawn.Core.Data.Devotions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eurotash.GrimDawn.Core.Build.Devotions
{
    public class ConstellationSelection
    {
        private List<StarSelection> _stars = new List<StarSelection>();

        public ConstellationSelection(Constellation constellation, IEnumerable<Star> stars)
        {
            this.Constellation = constellation;
            _stars.AddRange(stars.Select(item => new StarSelection(item)));
        }

        public Constellation Constellation { get; private set; }

        public IEnumerable<StarSelection> Stars { get { return _stars; } }
    }
}
