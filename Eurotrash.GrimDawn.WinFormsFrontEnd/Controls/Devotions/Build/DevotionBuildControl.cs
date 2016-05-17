using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses;
using Eurotrash.GrimDawn.Core.Data;
using Eurotrash.GrimDawn.Core.Analysis.StatisticBonuses.BonusTypes;
using Eurotrash.GrimDawn.Core.Build.Devotions;
using Eurotrash.GrimDawn.Core.Build;
using System.Text;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Build
{
    public partial class DevotionBuildControl : UserControl
    {
        public DevotionBuildControl()
        {
            InitializeComponent();
        }

        GrimDawnBuild _build;

        internal void AddDevotionSelectionAction(DevotionSelectionAction action)
        {
            _devotionPathControl.AddDevotionSelectionAction(action);
        }

        internal void SetDataSource(GrimDawnBuild build)
        {
            _build = build;
            _devotionPathControl.SetDataSource(build);
        }

        internal void SetDataSource(IEnumerable<ConstellationSelection> selections)
        {
            try
            {
                _statisticBonusesListView.BeginUpdate();
                _statisticBonusesListView.Items.Clear();

                var statisticsBonuses = selections.SelectMany(item => item.Stars)
                                                  .Where(item => !item.Star.GrantsSkill)
                                                  .SelectMany(item => item.Star.StatisticsBonuses)
                                                  .ToArray();

                var analysed = statisticsBonuses.Select(item => StatisticBonusParser.Parse(item.Text, item));

                var bonusGroups = analysed.Where(item => !(item is UnknownStatisticBonus))
                                          .GroupBy(item => item.BonusType);

                foreach (var group in bonusGroups)
                {
                    var aggregate = group.Aggregate((a, b) => a.StackWith(b));

                    var item = new ListViewItem();
                    item.Text = aggregate.Text;

                    _statisticBonusesListView.Items.Add(item);
                }
            }
            finally
            {
                _statisticBonusesListView.EndUpdate();
            }
        }

        private void _devotionPathControl_CurrentIndexChanged(object sender, EventArgs e)
        {
            UpdateStatistics(_build, _devotionPathControl.CurrentIndex);
        }

        private void UpdateStatistics(GrimDawnBuild build, int? index)
        {
            try
            {
                _statisticBonusesListView.BeginUpdate();
                _statisticBonusesListView.Items.Clear();

                if (index == null)
                    return;

                var actions = build.Devotions.Actions.Take(index.Value + 1);

                var constellationStars = actions.Where(item => item.Star == null)
                                                .SelectMany(item => item.Constellation.Stars);

                var individualStars = actions.Where(item => item.Star != null)
                                             .Select(item => item.Star);

                var allStars = constellationStars.Union(individualStars);

                var statisticsBonuses = allStars.Where(item => !item.GrantsSkill)
                                                .SelectMany(item => item.StatisticsBonuses)
                                                .ToArray();

                var analysed = statisticsBonuses.Select(item => StatisticBonusParser.Parse(item.Text, item));

                var bonusGroups = analysed.Where(item => !(item is UnknownStatisticBonus))
                                          .GroupBy(item => item.BonusType);

                var aggregates = bonusGroups.Select(group => group.Aggregate((a, b) => a.StackWith(b)))
                                            .OrderByDescending(item => item.OrderingValue);

                foreach (var aggregate in aggregates)
                {
                    var item = new ListViewItem();
                    item.Text = aggregate.Text;

                    string sources = GetSources(aggregate);
                    item.SubItems.Add(sources);

                    _statisticBonusesListView.Items.Add(item);
                }
            }
            finally
            {
                _statisticBonusesListView.EndUpdate();
            }
        }

        private string GetSources(IStatisticBonus aggregate)
        {
            var text = new StringBuilder();

            foreach (var source in aggregate.SourceBonuses)
            {
                if (text.Length > 0)
                    text.Append(", ");

                text.Append(String.Format("{0} {1}: {2}", source.Star.Constellation.Name, source.Star.Index, source.Text));
            }

            return text.ToString();
        }
    }
}
