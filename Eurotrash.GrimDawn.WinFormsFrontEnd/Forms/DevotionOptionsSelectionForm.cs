using Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses;
using Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes;
using Eurotrash.GrimDawn.Core.Build.Devotions;
using Eurotrash.GrimDawn.WinFormsFrontEnd.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Forms
{
    public partial class DevotionOptionsSelectionForm : Form
    {
        public DevotionOptionsSelectionForm()
        {
            InitializeComponent();
        }

        IEnumerable<DevotionBuild> _options;

        Dictionary<DevotionBuild, Image> _images;

        internal void Populate(IEnumerable<DevotionBuild> options)
        {
            _options = options.OrderBy(item => item.TotalPointsSpent);
            _images = new Dictionary<DevotionBuild, Image>();

            PopulateListView();

            UpdateControls();
        }

        private void PopulateListView()
        {
            try
            {
                _listView.BeginUpdate();

                _listView.Items.Clear();

                int index = 1;
                foreach (var build in _options)
                {
                    var listViewItem = new ListViewItem();

                    listViewItem.Tag = build;
                    listViewItem.UseItemStyleForSubItems = false;

                    listViewItem.Text = index.ToString();

                    var image = AffinityImageCache.CreateImage(build.TotalAffinitiesGained, _listView.Font);
                    _images[build] = image;

                    int pointsSpent = build.Actions.Sum(item => item.PointsSpent);
                    listViewItem.SubItems.Add(pointsSpent.ToString());
                    listViewItem.SubItems.Add(GetSummary(build));
                    listViewItem.SubItems.Add("");
                    listViewItem.SubItems.Add(GetStatisticsBonuses(build));

                    bool satisfiesFilter = SatisfiesFilter(listViewItem);

                    if (satisfiesFilter)
                        _listView.Items.Add(listViewItem);

                    index++;
                }
            }
            finally
            {
                _listView.EndUpdate();
            }
        }

        private bool SatisfiesFilter(ListViewItem listViewItem)
        {
            if (String.IsNullOrEmpty(_filterTextBox.Text))
                return true;

            if (listViewItem.SubItems[2].Text.IndexOf(_filterTextBox.Text, StringComparison.InvariantCultureIgnoreCase) != -1)
                return true;

            return false;
        }

        private string GetStatisticsBonuses(DevotionBuild build)
        {
            var statisticsBonuses = build.Actions.SelectMany(item => item.Constellation.Stars)
                                                  .Where(item => !item.GrantsSkill)
                                                  .SelectMany(item => item.StatisticsBonuses)
                                                  .ToArray();

            var analysed = statisticsBonuses.Select(item => StatisticBonusParser.Parse(item.Text, item));

            var bonusGroups = analysed.Where(item => !(item is UnknownStatisticBonus))
                                      .GroupBy(item => item.BonusType);

            var text = new StringBuilder();
            foreach (var group in bonusGroups)
            {
                var aggregate = group.Aggregate((a, b) => a.StackWith(b));

                if (text.Length > 0)
                    text.Append(", ");

                text.Append(aggregate.Text);
            }

            foreach (var unknown in analysed.Where(item => item is UnknownStatisticBonus))
            {
                if (text.Length > 0)
                    text.Append(", ");

                text.Append(unknown.Text);
            }

            return text.ToString();
        }

        private string GetSummary(DevotionBuild build)
        {
            var text = new StringBuilder();

            foreach (var action in build.Actions)
            {
                if (text.Length > 0)
                    text.Append(", ");

                text.Append(action.ConstellationName);
            }

            return text.ToString();
        }

        private void _listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void _listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var build = e.Item.Tag as DevotionBuild;
                var image = _images[build];

                var bounds = new Rectangle(e.Bounds.Left, e.Bounds.Top, Math.Min(image.Width, e.Bounds.Width), Math.Min(image.Height, e.Bounds.Height));

                e.Graphics.DrawImageUnscaledAndClipped(image, bounds);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void _acceptButton_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void Accept()
        {
            this.SelectedBuild = _listView.SelectedItems[0].Tag as DevotionBuild;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void _listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void UpdateControls()
        {
            bool itemIsSelected = _listView.SelectedItems.Count > 0;

            _acceptButton.Enabled = itemIsSelected;
        }

        public DevotionBuild SelectedBuild { get; set; }

        private void _listView_DoubleClick(object sender, EventArgs e)
        {
            if (_listView.SelectedItems.Count > 0)
                Accept();
        }

        private void _filterTimer_Tick(object sender, EventArgs e)
        {
            _filterTimer.Stop();

            PopulateListView();
        }

        private void _filterTextBox_TextChanged(object sender, EventArgs e)
        {
            _filterTimer.Stop();
            _filterTimer.Start();
        }
    }
}
