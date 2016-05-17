using Eurotash.GrimDawn.Core.Analysis.Affinities;
using Eurotash.GrimDawn.Core.Analysis.Search;
using Eurotash.GrimDawn.Core.Build.Devotions;
using Eurotash.GrimDawn.Core.Data;
using Eurotash.GrimDawn.Core.Data.Devotions;
using Eurotrash.GrimDawn.WinFormsFrontEnd.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Search
{
    public partial class ConstellationsTreeView : UserControl
    {
        private Font _boldFont; 

        public ConstellationsTreeView()
        {
            InitializeComponent();

            _boldFont = new Font(_treeView.Font, FontStyle.Bold);
        }

        public void Clear()
        {
            _treeView.BeginUpdate();
            _treeView.Nodes.Clear();
            _treeView.EndUpdate();
        }

        public void AddRange(IEnumerable<Constellation> constellations, SearchCriteria criteria = null)
        {
            try
            {
                _treeView.BeginUpdate();

                foreach (var constellation in constellations)
                    Add(constellation, false, criteria);
            }
            finally
            {
                _treeView.EndUpdate();

                if (_treeView.Nodes.Count > 0)
                    _treeView.Nodes[0].EnsureVisible();
            }
        }

        public void Add(Constellation constellation)
        {
            Add(constellation, true);
        }

        private void Add(Constellation constellation, bool suspendLayout, SearchCriteria criteria = null)
        {
            try
            {
                if (suspendLayout)
                    _treeView.BeginUpdate();

                var node = new TreeNode();

                string requirements = String.Join(", ", constellation.Requirements.Select(item => item.ToString()));

                node.Text = String.Format("{0}: {1}", constellation.Name, requirements);

                node.Tag = constellation;

                AddStars(constellation, node, criteria);

                _treeView.Nodes.Add(node);
            }
            finally
            {
                if (suspendLayout)
                {
                    _treeView.ResumeLayout();
                    _treeView.EndUpdate();
                }
            }
        }

        private void AddStars(Constellation constellation, TreeNode parentNode, SearchCriteria criteria = null)
        {
            foreach (var star in constellation.Stars)
            {
                var node = new TreeNode();

                node.Text = star.Index.ToString();
                node.Tag = star;

                AddStatisticBonuses(star, node, criteria);

                parentNode.Nodes.Add(node);
            }
        }

        private void AddStatisticBonuses(Star star, TreeNode parentNode, SearchCriteria criteria = null)
        {
            foreach (var statisticBonus in star.StatisticsBonuses)
            {
                var node = new TreeNode();
                node.Text = statisticBonus.Text;

                if (criteria != null && SearchHelper.IsMatch(statisticBonus, criteria))
                    node.NodeFont = _boldFont;

                parentNode.Nodes.Add(node);
            }
        }

        #region TreeView check logic

        private void _treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.ByKeyboard && e.Action != TreeViewAction.ByMouse)
                return;

            bool isLeafNode = (e.Node.Nodes.Count == 0);
            bool isStarNode = (!isLeafNode && e.Node.Parent != null);

            // Don't allow leaf nodes to be changed individually
            if (isLeafNode)
            {
                e.Node.Checked = !e.Node.Checked;
            }
            else
            {
                // If a mid-level node was ticked individually, check and tick 
                // parent node if necessary
                if (isStarNode && e.Node.Checked && !e.Node.Parent.Checked)
                    e.Node.Parent.Checked = true;

                CheckChildren(e.Node);
                UpdateSelectionStatistics();
            }
        }

        private void UpdateSelectionStatistics()
        {
            var nodes = _treeView.Nodes.Cast<TreeNode>().Where(item => item.Checked).ToArray();

            var selections = nodes.Select(item => new ConstellationSelection(item.Tag as Constellation, 
                item.Nodes.Cast<TreeNode>().Where(starNode => starNode.Checked).Select(starNode => starNode.Tag as Star)
                )).ToArray();

            //_constellationSelectionControl.SetDataSource(selections);
        }

        private static void CheckChildren(TreeNode node)
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                childNode.Checked = node.Checked;
                CheckChildren(childNode);
            }
        }

        #endregion

        private void _expandAllButton_Click(object sender, EventArgs e)
        {
            _treeView.BeginUpdate();
            _treeView.SuspendLayout();
            _treeView.ExpandAll();
            _treeView.ResumeLayout();
            _treeView.EndUpdate();
        }

        private void _collapseAllButton_Click(object sender, EventArgs e)
        {
            _treeView.CollapseAll();
        }

        TreeNode _nodeToAddToBuild = null;

        private void _treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.Node == null || e.Node.Nodes.Count == 0)
                return;

            _nodeToAddToBuild = e.Node;
            var screenLocation = this.PointToScreen(e.Location);
            _contextMenuStrip.Show(screenLocation);
        }

        private void addToBuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_nodeToAddToBuild != null && AddToBuild != null)
            {
                var star = _nodeToAddToBuild.Tag as Star;
                var constellation = _nodeToAddToBuild.Tag as Constellation;

                if (star != null)
                    constellation = _nodeToAddToBuild.Parent.Tag as Constellation;

                var action = new DevotionSelectionAction(constellation, star);

                AddToBuild(action);
            }
        }

        public event Action<DevotionSelectionAction> AddToBuild;

        private void _treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            var constellation = e.Node.Tag as Constellation;

            if (constellation == null)
            {
                e.DrawDefault = true;
            }
            else
            {
                var size = e.Graphics.MeasureString(constellation.Name, _treeView.Font);
                
                e.Graphics.DrawString(constellation.Name, _treeView.Font, Brushes.Black, e.Bounds.Location);



                var image = AffinityImageCache.CreateImage(new AffinitySet(constellation.Requirements), _treeView.Font);

                e.Graphics.DrawImageUnscaled(image, new Point((int)size.Width + e.Bounds.Left + 5, e.Bounds.Top));

                
            }
        }
    }
}
