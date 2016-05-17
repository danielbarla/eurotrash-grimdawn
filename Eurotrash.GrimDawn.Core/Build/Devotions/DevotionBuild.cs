using System;
using System.Linq;
using System.Collections.Generic;
using Eurotrash.GrimDawn.Core.Data.Devotions;
using Eurotrash.GrimDawn.Core.Analysis.Constellations;
using Eurotrash.GrimDawn.Core.Analysis.Affinities;
using System.Runtime.Serialization;
using Eurotrash.GrimDawn.Core.Data;

namespace Eurotrash.GrimDawn.Core.Build.Devotions
{
    [DataContract]
    public class DevotionBuild
    {
        #region Constructors

        public DevotionBuild()
        {
            Actions = new List<DevotionSelectionAction>();
        }

        public DevotionBuild(IEnumerable<DevotionSelectionAction> baseBuild)
        {
            Actions = new List<DevotionSelectionAction>(baseBuild);

            this.UpdateActions();
        }

        #endregion

        #region Properties

        [DataMember]
        public List<DevotionSelectionAction> Actions { get; set; }

        public int ActionCount
        {
            get
            {
                return Actions.Count;
            }
        }

        public AffinitySet TotalAffinitiesGained
        {
            get
            {
                if (this.ActionCount == 0)
                    return new AffinitySet();
                else
                    return this.Actions.Last().AffinitiesGainedAfterAction;
            }
        }

        public int TotalPointsSpent
        {
            get { return this.Actions.Sum(item => item.PointsSpent); }
        }

        #endregion

        #region Action List Modifications

        public void AddAction(DevotionSelectionAction action)
        {
            Actions.Add(action);

            UpdateActions();
        }

        public void MergeBuild(DevotionBuild other, int index = -1)
        {
            if (index == -1)
                Actions.AddRange(other.Actions);
            else
            {
                var list = new List<DevotionSelectionAction>();
                list.AddRange(Actions.Take(index));
                list.AddRange(other.Actions);
                list.AddRange(Actions.Skip(index));

                Actions = list;
            }

            UpdateActions();
        }

        public void RemoveAction(DevotionSelectionAction action)
        {
            Actions.Remove(action);
            UpdateActions();
        }

        private void UpdateActions()
        {
            var affinitiesGained = new AffinitySet();
            int index = 1;
            foreach (var action in Actions)
            {
                action.BuildIndex = index;
                action.AffinitiesGainedBeforeAction = affinitiesGained;
                action.Validate();

                affinitiesGained = affinitiesGained.Add(action.AffinitiesGainedByAction);
                action.AffinitiesGainedAfterAction = affinitiesGained;

                index++;
            }
        }

        #endregion

        #region Solution Finder Logic

        public IEnumerable<DevotionBuild> FindPossibleSolutions(int index, ConstellationCatalogue constellations)
        {
            int maxDepth = 4;
            int maxItems = 200;

            var list = Actions.Take(index).ToArray();
            var itemToFix = list[index - 1];
            var buildBase = new DevotionBuild(list.Take(index - 1));

            var items = GenerateSolutions(constellations, buildBase, itemToFix.AffinityRequirements, maxDepth).Take(maxItems).ToArray();

            return items;
        }

        private static IEnumerable<DevotionBuild> GenerateSolutions(ConstellationCatalogue constellations, DevotionBuild initialBuild, AffinitySet requirementsToReach, int maxDepth)
        {
            List<DevotionBuild> currentBuilds = new List<DevotionBuild>();
            currentBuilds.Add(initialBuild);

            int depth = 0;
            while (depth < maxDepth)
            {
                List<DevotionBuild> nextBuilds = new List<DevotionBuild>();

                foreach (var build in currentBuilds)
                    nextBuilds.AddRange(GenerateNextSolutions(constellations, build));

                var workingSolutions = nextBuilds.Where(item => item.TotalAffinitiesGained.Subtract(requirementsToReach).ExtractNegatives().IsEmpty).ToArray();

                var lookup = new HashSet<DevotionBuild>();

                foreach (var workingSolution in workingSolutions)
                {
                    if (!HasRedundantSteps(workingSolution, initialBuild, requirementsToReach))
                        yield return workingSolution.Skip(initialBuild.ActionCount);

                    lookup.Add(workingSolution);
                }

                nextBuilds = nextBuilds.Where(item => !lookup.Contains(item)).ToList();
                
                currentBuilds = nextBuilds;
                depth++;
            }
        }

        private DevotionBuild Skip(int count)
        {
            if (count == 0)
                return this.Clone();
            else
            {
                var actions = Actions.Skip(count);
                var build = new DevotionBuild(actions);

                return build;
            }
        }

        private static bool HasRedundantSteps(DevotionBuild workingSolution, DevotionBuild initialBuild, AffinitySet originalGap)
        {
            var stepsAdded = workingSolution.Actions.Skip(initialBuild.ActionCount).ToArray();

            if (stepsAdded.Length <= 1)
                return false;

            for (int i = 0; i < stepsAdded.Length - 1; i++)
            {
                var step = stepsAdded[i];
                var nextStep = stepsAdded[i + 1];

                bool hasIntrinsicValue = step.AffinitiesGainedByAction.SharesAffinitiesWith(originalGap);

                if (hasIntrinsicValue)
                    return false;

                var nextStepRequirements = new AffinitySet(nextStep.Constellation.Requirements);

                if (nextStepRequirements.IsEmpty)
                    return true;

                var nextStepAffinitiesWithoutCurrentStep = nextStep.AffinitiesGainedBeforeAction.Subtract(step.AffinitiesGainedByAction);

                bool stillSatisfiesRequirements = nextStepRequirements.Subtract(nextStepAffinitiesWithoutCurrentStep).IsEmpty;

                if (stillSatisfiesRequirements)
                    return true;
            }

            return false;
        }

        private static IEnumerable<DevotionBuild> GenerateNextSolutions(ConstellationCatalogue constellations, DevotionBuild build)
        {
            var affinities = new AffinitySet();

            if (build.ActionCount > 0)
                affinities = build.Actions.Last().AffinitiesGainedAfterAction;

            foreach (var constellation in constellations.GetConstellationsAvailable(affinities))
            {
                // Avoid duplicate actions
                if (build.Actions.Any(item => item.Star == null && item.ConstellationName == constellation.Name))
                    continue;

                var completionBonus = new AffinitySet(constellation.CompletionBonuses);

                if (completionBonus.IsEmpty)
                {
                    // Check stars for bonuses
                    foreach (var star in constellation.Stars.Where(item => item.StatisticsBonuses.Length > 0))
                    {
                        if (build.Actions.Any(item => item.Star == star))
                            continue;

                        var action = new DevotionSelectionAction(constellation, star);

                        var solution = build.Clone();
                        solution.AddAction(action);

                        yield return solution;
                    }
                }
                else
                {
                    // Use entire constellation
                    var action = new DevotionSelectionAction(constellation, null);

                    var solution = build.Clone();
                    solution.AddAction(action);

                    yield return solution;
                }
            }
        }

        #endregion

        #region Utility Methods

        private DevotionBuild Clone()
        {
            return new DevotionBuild(Actions);
        }

        public override string ToString()
        {
            return String.Join("\r\n", Actions.Select(item => item.ToString()));
        }

        #endregion

        internal void Initialise(GrimDawnDataContext context)
        {
            foreach (var action in this.Actions)
            {
                action.Constellation = context.Constellations.First(item => item.Name == action.ConstellationName);

                if (action.StarIndex != null)
                    action.Star = action.Constellation.Stars[action.StarIndex.Value - 1];
            }

            UpdateActions();

            foreach (var action in this.Actions)
            {
                action.Validate();
            }
        }
    }
}
