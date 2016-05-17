using Eurotash.GrimDawn.Core.Analysis.Search;
using Eurotash.GrimDawn.Core.Analysis.StatisticBonuses;
using Eurotash.GrimDawn.Core.Build.Devotions;
using Eurotash.GrimDawn.Core.Data;
using Eurotash.GrimDawn.Core.Data.Devotions;
using Eurotrash.GrimDawn.WinFormsFrontEnd.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Search
{
    public partial class ConstellationSearchControl : UserControl
    {
        public ConstellationSearchControl()
        {
            InitializeComponent();
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {
            string[] searchTerms = _effectsTextBox.Text
                                                  .Split(',')
                                                  .Select(item => item.Trim())
                                                  .Where(item => !String.IsNullOrWhiteSpace(item))
                                                  .ToArray();

            var criteria = new SearchCriteria() { SearchTerms = searchTerms };

            Search(Context.GrimDawnDataContext.Constellations, criteria);
        }

        private void Search(Constellation[] data, SearchCriteria criteria)
        {
            var constellations = SearchHelper.Find(data, criteria);

            _constellationsTreeView.Clear();
            _constellationsTreeView.AddRange(constellations, criteria);
        }

        public event Action<DevotionSelectionAction> AddToBuild;

        private void _constellationsTreeView_AddToBuild(DevotionSelectionAction action)
        {
            if (AddToBuild != null)
                AddToBuild(action);
        }
    }
}
