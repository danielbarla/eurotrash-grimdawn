using Eurotash.GrimDawn.Core.Analysis.Affinities;
using Eurotash.GrimDawn.Core.Data.Devotions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eurotash.GrimDawn.Core.Analysis.Constellations
{
    public class ConstellationCatalogue : IEnumerable<Constellation>
    {
        Constellation[] _constellations;

        Dictionary<string, Constellation> _constellationsByName;

        public ConstellationCatalogue(string file)
        {
            string json = File.ReadAllText(file);
            var data = JsonConvert.DeserializeObject<List<Constellation>>(json);

            _constellations = data.ToArray();
            Index();
        }

        public ConstellationCatalogue(Constellation[] constellations)
        {
            _constellations = constellations;
            Index();
        }

        private void Index()
        {
            _constellationsByName = _constellations.ToDictionary(item => item.Name);
        }

        public IEnumerable<Constellation> GetConstellationsAvailable(AffinitySet availableAffinities)
        {
            foreach (var constellation in _constellations)
            {
                var difference = availableAffinities.Subtract(new AffinitySet(constellation.Requirements));

                bool meetsRequirements = difference.ExtractNegatives().IsEmpty;

                if (meetsRequirements)
                    yield return constellation;
            }
        }

        public Constellation this[string name]
        {
            get
            {
                return _constellationsByName[name];
            }
        }


        public IEnumerator<Constellation> GetEnumerator()
        {
            return (IEnumerator<Constellation>)_constellations.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _constellations.GetEnumerator();
        }
    }
}
