﻿using Eurotash.GrimDawn.Core.Build.Devotions;
using Eurotash.GrimDawn.Core.Data;
using Eurotash.GrimDawn.Core.Data.Devotions;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Eurotash.GrimDawn.Core.Build
{
    public class GrimDawnBuild
    {
        public GrimDawnBuild()
        {
            this.Devotions = new DevotionBuild();
        }

        public DevotionBuild Devotions { get; set; }

        public void Save(string filename)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);

            File.WriteAllText(filename, json);
        }

        public static GrimDawnBuild Load(string file, GrimDawnDataContext context)
        {
            string json = File.ReadAllText(file);
            
            var build = JsonConvert.DeserializeObject<GrimDawnBuild>(json);

            build.Initialise(context);

            return build;
        }

        private void Initialise(GrimDawnDataContext context)
        {
            this.Devotions.Initialise(context);
        }
    }
}
