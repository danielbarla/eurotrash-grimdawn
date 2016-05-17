using Eurotrash.GrimDawn.Core.Data;
using Eurotrash.GrimDawn.Core.Data.Devotions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Common
{
    public static class Context
    {
        private static GrimDawnDataContext _context;

        public static GrimDawnDataContext GrimDawnDataContext
        {
            get
            {
                if (_context == null)
                {
                    string json = File.ReadAllText("constellations.json");
                    var data = JsonConvert.DeserializeObject<List<Constellation>>(json);

                    foreach (var constellation in data)
                        constellation.Initialise();

                    _context = new GrimDawnDataContext() {
                         Constellations = data.ToArray()
                    };
                }

                return _context;
            }
        }
    }
}
