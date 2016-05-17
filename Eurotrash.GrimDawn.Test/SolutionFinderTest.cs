using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eurotrash.GrimDawn.Core.Analysis.Constellations;
using Eurotrash.GrimDawn.Core.Build.Devotions;

namespace Eurotrash.GrimDawn.Test
{
    [TestClass]
    public class SolutionFinderTest
    {
        [TestMethod]
        public void FixSimpleProblem()
        {
            var constellations = new ConstellationCatalogue("constellations.json");

            var build = new DevotionBuild();
            build.AddAction(new DevotionSelectionAction(constellations["Fiend"], null));

            build.FindPossibleSolutions(1, constellations);

            //Assert.AreEqual(70, c.Percentage);
        }

        [TestMethod]
        public void FixMultiStepProblem()
        {
            var constellations = new ConstellationCatalogue("constellations.json");

            var build = new DevotionBuild();
            build.AddAction(new DevotionSelectionAction(constellations["Fiend"], null));

            var firstSolution = build.FindPossibleSolutions(1, constellations).First();

            build.MergeBuild(firstSolution, 0);

            build.AddAction(new DevotionSelectionAction(constellations["Magi"], null));

            var complexSolutions = build.FindPossibleSolutions(3, constellations).Take(5).ToArray();

            //Assert.AreEqual(70, c.Percentage);
        }
    }
}
