namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Search
{
    partial class ConstellationsTreeView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._treeView = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._collapseAllButton = new System.Windows.Forms.Button();
            this._expandAllButton = new System.Windows.Forms.Button();
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToBuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _treeView
            // 
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this._treeView.Location = new System.Drawing.Point(0, 0);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(749, 449);
            this._treeView.TabIndex = 0;
            this._treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._treeView_AfterCheck);
            this._treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this._treeView_DrawNode);
            this._treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeView_NodeMouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._treeView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 482);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._collapseAllButton);
            this.panel2.Controls.Add(this._expandAllButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(749, 33);
            this.panel2.TabIndex = 0;
            // 
            // _collapseAllButton
            // 
            this._collapseAllButton.Location = new System.Drawing.Point(84, 3);
            this._collapseAllButton.Name = "_collapseAllButton";
            this._collapseAllButton.Size = new System.Drawing.Size(75, 25);
            this._collapseAllButton.TabIndex = 1;
            this._collapseAllButton.Text = "Collapse All";
            this._collapseAllButton.UseVisualStyleBackColor = true;
            this._collapseAllButton.Click += new System.EventHandler(this._collapseAllButton_Click);
            // 
            // _expandAllButton
            // 
            this._expandAllButton.Location = new System.Drawing.Point(3, 3);
            this._expandAllButton.Name = "_expandAllButton";
            this._expandAllButton.Size = new System.Drawing.Size(75, 25);
            this._expandAllButton.TabIndex = 0;
            this._expandAllButton.Text = "Expand All";
            this._expandAllButton.UseVisualStyleBackColor = true;
            this._expandAllButton.Click += new System.EventHandler(this._expandAllButton_Click);
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToBuildToolStripMenuItem});
            this._contextMenuStrip.Name = "_contextMenuStrip";
            this._contextMenuStrip.Size = new System.Drawing.Size(141, 26);
            // 
            // addToBuildToolStripMenuItem
            // 
            this.addToBuildToolStripMenuItem.Name = "addToBuildToolStripMenuItem";
            this.addToBuildToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addToBuildToolStripMenuItem.Text = "&Add to build";
            this.addToBuildToolStripMenuItem.Click += new System.EventHandler(this.addToBuildToolStripMenuItem_Click);
            // 
            // ConstellationsTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ConstellationsTreeView";
            this.Size = new System.Drawing.Size(749, 482);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _expandAllButton;
        private System.Windows.Forms.Button _collapseAllButton;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToBuildToolStripMenuItem;
    }
}
