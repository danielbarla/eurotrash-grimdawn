using Eurotrash.GrimDawn.Core.Data.Devotions;
using System;
using System.Linq;
using System.Text;

namespace Eurotrash.GrimDawn.Core.Analysis.Affinities
{
    public class AffinitySet
    {
        private int[] _affinities = new int[5];

        public AffinitySet()
        {

        }

        public AffinitySet(int ascendant = 0, int chaos = 0, int eldritch = 0, int order = 0, int primordial = 0)
        {
            _affinities[(int)AffinityType.Ascendant] = ascendant;
            _affinities[(int)AffinityType.Chaos] = chaos;
            _affinities[(int)AffinityType.Eldritch] = eldritch;
            _affinities[(int)AffinityType.Order] = order;
            _affinities[(int)AffinityType.Primordial] = primordial;
        }

        public AffinitySet(Affinity[] affinities)
        {
            foreach (var affinity in affinities)
            {
                var type = GetAffinityType(affinity.Name);

                _affinities[(int)type] = affinity.Value;
            }
        }

        private AffinityType GetAffinityType(string affinityName)
        {
            switch(affinityName)
            {
                case "Ascendant":
                    return AffinityType.Ascendant;
                case "Chaos":
                    return AffinityType.Chaos;
                case "Eldritch":
                    return AffinityType.Eldritch;
                case "Order":
                    return AffinityType.Order;
                case "Primordial":
                    return AffinityType.Primordial;
                default:
                    throw new ApplicationException("Unknown affinity type: " + affinityName);
            }
        }

        public int Ascendant { get { return _affinities[(int)AffinityType.Ascendant]; } }

        public int Chaos { get { return _affinities[(int)AffinityType.Chaos]; } }

        public int Eldritch { get { return _affinities[(int)AffinityType.Eldritch]; } }

        public int Order { get { return _affinities[(int)AffinityType.Order]; } }

        public int Primordial { get { return _affinities[(int)AffinityType.Primordial]; } }

        public int this[AffinityType affinityType]
        {
            get { return _affinities[(int)affinityType]; }
        }

        public override string ToString()
        {
            var text = new StringBuilder();

            for (int type = 0; type <= 4; type++)
            {
                if (_affinities[type] != 0)
                {
                    if (text.Length > 0)
                        text.Append(", ");

                    text.Append(_affinities[type]);
                    text.Append(" ");
                    text.Append(((AffinityType)type).ToString());
                }
            }

            return text.ToString();
        }

        public AffinitySet Add(AffinitySet other)
        {
            int ascendant = this.Ascendant + other.Ascendant;
            int chaos = this.Chaos + other.Chaos;
            int eldritch = this.Eldritch + other.Eldritch;
            int order = this.Order + other.Order;
            int primordial = this.Primordial + other.Primordial;

            return new AffinitySet(ascendant, chaos, eldritch, order, primordial);
        }

        internal AffinitySet Subtract(AffinitySet other)
        {
            int ascendant = this.Ascendant - other.Ascendant;
            int chaos = this.Chaos - other.Chaos;
            int eldritch = this.Eldritch - other.Eldritch;
            int order = this.Order - other.Order;
            int primordial = this.Primordial - other.Primordial;

            return new AffinitySet(ascendant, chaos, eldritch, order, primordial);
        }

        public AffinitySet ExtractNegatives()
        {
            return new AffinitySet(this.Ascendant < 0 ? this.Ascendant : 0,
                                   this.Chaos < 0 ? this.Chaos : 0,
                                   this.Eldritch < 0 ? this.Eldritch : 0,
                                   this.Order < 0 ? this.Order : 0,
                                   this.Primordial < 0 ? this.Primordial : 0);
        }

        public bool IsEmpty
        {
            get { return !_affinities.Any(item => item != 0); }
        }

        internal bool SharesAffinitiesWith(AffinitySet other)
        {
            if (this.Ascendant > 0 && other.Ascendant != 0)
                return true;

            if (this.Chaos > 0 && other.Chaos != 0)
                return true;

            if (this.Eldritch > 0 && other.Eldritch != 0)
                return true;

            if (this.Order > 0 && other.Order != 0)
                return true;

            if (this.Primordial > 0 && other.Primordial != 0)
                return true;

            return false;
        }
    }

    public enum AffinityType
    {
        Ascendant = 0,
        Chaos = 1,
        Eldritch = 2,
        Order = 3,
        Primordial = 4
    }

}
