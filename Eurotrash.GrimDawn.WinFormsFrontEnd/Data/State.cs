using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Data
{
    public class State
    {
        public State()
        {
            this.RecentFiles = new List<string>();
        }

        public List<string> RecentFiles { get; set; }

        public void AddRecentFile(string recentFile)
        {
            if (RecentFiles.Contains(recentFile))
                RecentFiles.Remove(recentFile);

            RecentFiles.Insert(0, recentFile);
            
            const int maxFileCount = 10;

            if (RecentFiles.Count > maxFileCount)
                RecentFiles = RecentFiles.Take(maxFileCount).ToList();

            Save();
        }

        #region Load / Save

        public void Save(string file = "state.json")
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);

            File.WriteAllText(file, json);
        }

        public static State Load(string file = "state.json")
        {
            if (File.Exists(file))
            {
                try
                {
                    string json = File.ReadAllText(file);

                    return JsonConvert.DeserializeObject<State>(json);
                }
                catch
                {
                    return new State();
                }
            }
            
            return new State();
        }

        #endregion
    }
}
