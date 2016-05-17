using Eurotrash.GrimDawn.Core.Data.Devotions;
using System;

namespace Eurotrash.GrimDawn.Core.Build.Devotions
{
    public class StarSelection
    {
        public StarSelection(Star star)
        {
            this.Star = star;
        }

        public Star Star { get; private set; }
    }
}
