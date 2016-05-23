using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eurotrash.GrimDawn.Core.Build.Devotions;
using Eurotrash.GrimDawn.WinFormsFrontEnd.Common;
using Eurotrash.GrimDawn.Core.Analysis.Constellations;
using Eurotrash.GrimDawn.WinFormsFrontEnd.Forms;
using Eurotrash.GrimDawn.Core.Build;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Build
{
    public partial class DevotionPathControl : UserControl
    {
        public DevotionPathControl()
        {
            InitializeComponent();

            UpdateControls();

            _boldFont = new Font(_listView.Font, FontStyle.Bold);
        }

        GrimDawnBuild _build = new GrimDawnBuild();

        bool _hasValidationProblems = false;

        ListViewItem _currentItem = null;

        Font _boldFont;

        internal void SetDataSource(GrimDawnBuild build)
        {
            _build = build;
            RebuildListView();
        }

        private void UpdateControls()
        {
            bool itemIsSelected = _listView.SelectedItems.Count > 0;

            var selectedItem = itemIsSelected ? _listView.SelectedItems[0] : null;

            _removeButton.Enabled = itemIsSelected;
            _moveDownButton.Enabled = itemIsSelected && (selectedItem.Index != _listView.Items.Count - 1);
            _moveUpButton.Enabled = itemIsSelected && (selectedItem.Index != 0);
            _fixProblemsButton.Enabled = _hasValidationProblems;
            _setCurrentButton.Enabled = itemIsSelected && (selectedItem != _currentItem);
        }

        internal void AddDevotionSelectionAction(DevotionSelectionAction action)
        {
            _build.Devotions.AddAction(action);

            UpdateValidations();

            AddListViewItem(action);
            UpdateControls();
        }

        private void UpdateValidations()
        {
            _hasValidationProblems = _build.Devotions.Actions.Any(item => item.HasValidationProblem);
        }

        private void AddListViewItem(DevotionSelectionAction action)
        {
            var listViewNode = new ListViewItem();

            listViewNode.Tag = action;

            listViewNode.Text = action.BuildIndex.ToString();
            listViewNode.SubItems.Add(action.ToString());
            listViewNode.SubItems.Add(action.PointsSpent.ToString());
            listViewNode.SubItems.Add(action.AffinitiesGainedAfterAction.ToString());
            listViewNode.SubItems.Add(action.Comments);

            listViewNode.UseItemStyleForSubItems = false;

            _listView.Items.Add(listViewNode);
        }

        #region Custom ListView Draw

        private void _listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var action = e.Item.Tag as DevotionSelectionAction;

                var image = AffinityImageCache.CreateImage(action.AffinitiesGainedByAction, _listView.Font);

                e.Graphics.DrawImageUnscaledAndClipped(image, e.Bounds);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void _listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void _listView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        #endregion

        private void _listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void _moveUpButton_Click(object sender, EventArgs e)
        {
            int index = _listView.SelectedItems[0].Index;

            SwapItems(index, index - 1);
        }

        private void _moveDownButton_Click(object sender, EventArgs e)
        {
            int index = _listView.SelectedItems[0].Index;

            SwapItems(index, index + 1);
        }

        private void SwapItems(int itemIndex, int otherItemIndex)
        {
            _build.Devotions.SwapActions(itemIndex, otherItemIndex);

            UpdateValidations();
            RebuildListView();
        }

        private void _removeButton_Click(object sender, EventArgs e)
        {
            _build.Devotions.RemoveAction(this.SelectedAction);

            UpdateValidations();
            RebuildListView();
        }

        private void _setCurrentButton_Click(object sender, EventArgs e)
        {
            SetCurrent(_listView.SelectedItems[0]);
        }

        private void SetCurrent(ListViewItem listViewItem)
        {
            if (_currentItem != null)
                ResetItemStyle(_currentItem);

            SetCurrentItemStyle(listViewItem);

            _currentItem = listViewItem;

            OnCurrentIndexChanged(listViewItem.Index);
        }

        private void SetCurrentItemStyle(ListViewItem listViewItem)
        {
            SetListViewItemFont(listViewItem, _boldFont);
        }

        private void ResetItemStyle(ListViewItem listViewItem)
        {
            SetListViewItemFont(listViewItem, _listView.Font);
        }

        private void SetListViewItemFont(ListViewItem listViewItem, Font font)
        {
            listViewItem.Font = font;
            foreach (System.Windows.Forms.ListViewItem.ListViewSubItem subItem in listViewItem.SubItems)
                subItem.Font = font;
        }

        private void _fixProblemsButton_Click(object sender, EventArgs e)
        {
            var firstProblem = _build.Devotions.Actions.First(item => item.HasValidationProblem);
            int index = firstProblem.BuildIndex;

            var options = _build.Devotions.FindPossibleSolutions(index, new ConstellationCatalogue(Context.GrimDawnDataContext.Constellations));

            using (var form = new DevotionOptionsSelectionForm())
            {
                form.Populate(options);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _build.Devotions.MergeBuild(form.SelectedBuild, index - 1);
                    RebuildListView();
                }
            }
        }

        private void RebuildListView()
        {
            try
            {
                _listView.EndUpdate();
                _listView.Items.Clear();

                foreach (var action in _build.Devotions.Actions)
                    AddListViewItem(action);

                if (_listView.Items.Count > 0)
                {
                    int index = _listView.Items.Count - 1;
                    SetCurrent(_listView.Items[index]);
                }
                else
                {
                    OnCurrentIndexChanged(null);
                }
            }
            finally
            {
                _listView.EndUpdate();
            }

            UpdateControls();
        }

        private void OnCurrentIndexChanged(int? index)
        {
            this.CurrentIndex = index;

            if (this.CurrentIndexChanged != null)
                this.CurrentIndexChanged(this, null);
        }

        public DevotionSelectionAction SelectedAction
        {
            get
            {
                if (_listView.SelectedItems.Count == 0)
                    return null;
                else
                    return _listView.SelectedItems[0].Tag as DevotionSelectionAction;
            }
        }

        public event EventHandler CurrentIndexChanged;

        public int? CurrentIndex { get; set; }
    }
}
