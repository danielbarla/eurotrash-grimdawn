using Eurotrash.GrimDawn.Core.Data.Devotions;
using System;
using System.Linq;
using System.Text;

namespace Eurotrash.GrimDawn.Core.Analysis.Affinities
{
    /// <summary>
    /// An immutable class representing a set of GD affinities.
    /// </summary>
    /// <remarks>
    /// The DTO for affinities, /Data/Affinity.cs, is a simplistic 
    /// representation where each individual affinity is represented by a 
    /// separate object instance, so a typical affinity set is treated as an
    /// array.  This quickly becomes difficult to work with, therefore this
    /// class was created to handle working with affinity sets more natural.
    /// 
    /// This is an immutable class by design.  This is done to simplify 
    /// (potential future) LINQ-queries based on top of this class.
    /// 
    /// The main responsibilities of the class are to be able to add together
    /// two AffinitySets, to subtract them (for requirements checking).
    /// </remarks>
    public class AffinitySet
    {
        /// <summary>
        /// Stores the values of the five possible affinity types, as an array.
        /// </summary>
        private int[] _affinities = new int[5];

        public AffinitySet()
        {

        }

        /// <summary>
        /// A convenience constructor primarily for unit test code.  
        /// </summary>
        public AffinitySet(int ascendant = 0, int chaos = 0, int eldritch = 0, int order = 0, int primordial = 0)
        {
            _affinities[(int)AffinityType.Ascendant] = ascendant;
            _affinities[(int)AffinityType.Chaos] = chaos;
            _affinities[(int)AffinityType.Eldritch] = eldritch;
            _affinities[(int)AffinityType.Order] = order;
            _affinities[(int)AffinityType.Primordial] = primordial;
        }

        /// <summary>
        /// Main constructor from the point of view of the application.  The 
        /// resulting AffinitySet represents the passed in Affinity[].
        /// </summary>
        public AffinitySet(Affinity[] affinities)
        {
            foreach (var affinity in affinities)
            {
                var type = GetAffinityType(affinity.Name);

                _affinities[(int)type] = affinity.Value;
            }
        }

        /// <summary>
        /// Converts the specified affinity name (typically from the DTO object)
        /// to an AffinityType enum.
        /// </summary>
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

        /// <summary>
        /// Returns a new AffinitySet, representing the current one added to 
        /// the passed in one.  Can be used to keep track of affinity totals
        /// in a build.
        /// </summary>
        public AffinitySet Add(AffinitySet other)
        {
            int ascendant = this.Ascendant + other.Ascendant;
            int chaos = this.Chaos + other.Chaos;
            int eldritch = this.Eldritch + other.Eldritch;
            int order = this.Order + other.Order;
            int primordial = this.Primordial + other.Primordial;

            return new AffinitySet(ascendant, chaos, eldritch, order, primordial);
        }

        /// <summary>
        /// Returns a new AffinitySet, represeting the difference between the
        /// current one and the passed in one.  Used in conjunction with 
        /// ExtractNegatives() for requirements checking.
        /// </summary>
        public AffinitySet Subtract(AffinitySet other)
        {
            int ascendant = this.Ascendant - other.Ascendant;
            int chaos = this.Chaos - other.Chaos;
            int eldritch = this.Eldritch - other.Eldritch;
            int order = this.Order - other.Order;
            int primordial = this.Primordial - other.Primordial;

            return new AffinitySet(ascendant, chaos, eldritch, order, primordial);
        }

        /// <summary>
        /// Returns a new AffinitySet with only the affinities that are below
        /// zero in the current one.
        /// </summary>
        public AffinitySet ExtractNegatives()
        {
            return new AffinitySet(this.Ascendant < 0 ? this.Ascendant : 0,
                                   this.Chaos < 0 ? this.Chaos : 0,
                                   this.Eldritch < 0 ? this.Eldritch : 0,
                                   this.Order < 0 ? this.Order : 0,
                                   this.Primordial < 0 ? this.Primordial : 0);
        }

        /// <summary>
        /// Returns true if all affinities are zero.  Typically used for
        /// requiremetns checking.
        /// </summary>
        public bool IsEmpty
        {
            get { return !_affinities.Any(item => item != 0); }
        }

        /// <summary>
        /// Returns true if any of the affinities are greater than zero in both
        /// the current and the passed in AffinitySet.  Can be used as a weak
        /// heuristic when performing searches, as a way of checking whether
        /// our choices are progressing in the right direction.
        /// </summary>
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
    }

    /// <summary>
    /// Represents the five different types of affinities which exist in GD.
    /// </summary>
    public enum AffinityType
    {
        Ascendant = 0,
        Chaos = 1,
        Eldritch = 2,
        Order = 3,
        Primordial = 4
    }
}
