using Eurotrash.GrimDawn.Core.Analysis.Affinities;
using Eurotrash.GrimDawn.Core.Data.Devotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Eurotrash.GrimDawn.Core.Build.Devotions
{
    [DataContract]
    public class DevotionSelectionAction
    {
        public DevotionSelectionAction()
        {

        }

        public DevotionSelectionAction(Constellation constellation, Star star, DevotionSelectionActionType actionType = DevotionSelectionActionType.Add)
        {
            this.Constellation = constellation;
            this.Star = star;

            this.ConstellationName = constellation.Name;
            this.StarIndex = (star != null) ? (int?)star.Index : null;

            this.ActionType = actionType;
        }

        [DataMember]
        public DevotionSelectionActionType ActionType { get; set; }

        [DataMember]
        public string ConstellationName { get; set; }

        [DataMember]
        public int? StarIndex { get; set; }

        public Constellation Constellation { get; set; }

        public Star Star { get; set; }

        public int PointsSpent
        {
            get
            {
                return (this.StarIndex != null) ? 1 : this.Constellation.Stars.Length;
            }
        }

        public int PointsSpentAfterAction
        {
            get; set;
        }

        public override string ToString()
        {
            if (this.StarIndex == null)
                return String.Format("Add constellation: {0}", this.ConstellationName);
            else
                return String.Format("Add star {0} of constellation: {1}", this.StarIndex, this.ConstellationName);
        }

        public int BuildIndex { get; set; }

        public AffinitySet AffinitiesGainedBeforeAction { get; set; }

        public AffinitySet AffinitiesGainedByAction
        {
            get
            {
                if (this.Star != null)
                {
                    var starWithBonus = this.Star.StatisticsBonuses.FirstOrDefault(item => item.AffinityBonuses != null && item.AffinityBonuses.Length > 0);

                    if (starWithBonus != null)
                        return new AffinitySet(starWithBonus.AffinityBonuses);
                    else 
                        return new AffinitySet();
                }
                else
                    return new AffinitySet(this.Constellation.CompletionBonuses);
            }
        }

        public AffinitySet AffinitiesGainedAfterAction { get; set; }

        public AffinitySet AffinityRequirementGap { get; set; }

        public AffinitySet AffinityRequirements { get; set; }

        public string Comments { get; set; }

        internal void Validate()
        {
            this.AffinityRequirements = new AffinitySet(this.Constellation.Requirements);

            var affinityGap = this.AffinitiesGainedBeforeAction.Subtract(this.AffinityRequirements).ExtractNegatives();

            this.AffinityRequirementGap = affinityGap;

            if (this.AffinityRequirementGap.IsEmpty)
            {
                this.Comments = String.Empty;
                this.HasValidationProblem = false;
            }
            else
            {
                this.Comments = String.Format("Missed requirements by: {0}", affinityGap.ToString());
                this.HasValidationProblem = true;
            }
        }

        public bool HasValidationProblem { get; private set; }
    }

    public enum DevotionSelectionActionType { Add, Remove }
}
