namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Build
{
    partial class DevotionPathControl
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
            this._listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._buttonPanel = new System.Windows.Forms.Panel();
            this._moveDownButton = new System.Windows.Forms.Button();
            this._moveUpButton = new System.Windows.Forms.Button();
            this._fixProblemsButton = new System.Windows.Forms.Button();
            this._setCurrentButton = new System.Windows.Forms.Button();
            this._removeButton = new System.Windows.Forms.Button();
            this._buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _listView
            // 
            this._listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this._listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listView.FullRowSelect = true;
            this._listView.Location = new System.Drawing.Point(0, 0);
            this._listView.Name = "_listView";
            this._listView.OwnerDraw = true;
            this._listView.Size = new System.Drawing.Size(708, 212);
            this._listView.TabIndex = 0;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            this._listView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this._listView_DrawColumnHeader);
            this._listView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this._listView_DrawItem);
            this._listView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this._listView_DrawSubItem);
            this._listView.SelectedIndexChanged += new System.EventHandler(this._listView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 22;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Devotion Selection";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Points";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Affinities";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Comments";
            this.columnHeader5.Width = 300;
            // 
            // _buttonPanel
            // 
            this._buttonPanel.Controls.Add(this._moveDownButton);
            this._buttonPanel.Controls.Add(this._moveUpButton);
            this._buttonPanel.Controls.Add(this._fixProblemsButton);
            this._buttonPanel.Controls.Add(this._setCurrentButton);
            this._buttonPanel.Controls.Add(this._removeButton);
            this._buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonPanel.Location = new System.Drawing.Point(0, 212);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(708, 38);
            this._buttonPanel.TabIndex = 1;
            // 
            // _moveDownButton
            // 
            this._moveDownButton.Image = global::Eurotrash.GrimDawn.WinFormsFrontEnd.Properties.Resources.arrow_down;
            this._moveDownButton.Location = new System.Drawing.Point(382, 6);
            this._moveDownButton.Name = "_moveDownButton";
            this._moveDownButton.Size = new System.Drawing.Size(98, 25);
            this._moveDownButton.TabIndex = 4;
            this._moveDownButton.Text = "Move Down";
            this._moveDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._moveDownButton.UseVisualStyleBackColor = true;
            this._moveDownButton.Click += new System.EventHandler(this._moveDownButton_Click);
            // 
            // _moveUpButton
            // 
            this._moveUpButton.Image = global::Eurotrash.GrimDawn.WinFormsFrontEnd.Properties.Resources.arrow_up;
            this._moveUpButton.Location = new System.Drawing.Point(291, 6);
            this._moveUpButton.Name = "_moveUpButton";
            this._moveUpButton.Size = new System.Drawing.Size(85, 25);
            this._moveUpButton.TabIndex = 3;
            this._moveUpButton.Text = "Move Up";
            this._moveUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._moveUpButton.UseVisualStyleBackColor = true;
            this._moveUpButton.Click += new System.EventHandler(this._moveUpButton_Click);
            // 
            // _fixProblemsButton
            // 
            this._fixProblemsButton.Image = global::Eurotrash.GrimDawn.WinFormsFrontEnd.Properties.Resources.wand;
            this._fixProblemsButton.Location = new System.Drawing.Point(184, 6);
            this._fixProblemsButton.Name = "_fixProblemsButton";
            this._fixProblemsButton.Size = new System.Drawing.Size(101, 25);
            this._fixProblemsButton.TabIndex = 2;
            this._fixProblemsButton.Text = "Fix Problems...";
            this._fixProblemsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._fixProblemsButton.UseVisualStyleBackColor = true;
            this._fixProblemsButton.Click += new System.EventHandler(this._fixProblemsButton_Click);
            // 
            // _setCurrentButton
            // 
            this._setCurrentButton.Image = global::Eurotrash.GrimDawn.WinFormsFrontEnd.Properties.Resources.anchor;
            this._setCurrentButton.Location = new System.Drawing.Point(84, 6);
            this._setCurrentButton.Name = "_setCurrentButton";
            this._setCurrentButton.Size = new System.Drawing.Size(94, 25);
            this._setCurrentButton.TabIndex = 1;
            this._setCurrentButton.Text = "Set Current";
            this._setCurrentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._setCurrentButton.UseVisualStyleBackColor = true;
            this._setCurrentButton.Click += new System.EventHandler(this._setCurrentButton_Click);
            // 
            // _removeButton
            // 
            this._removeButton.Image = global::Eurotrash.GrimDawn.WinFormsFrontEnd.Properties.Resources.delete;
            this._removeButton.Location = new System.Drawing.Point(3, 6);
            this._removeButton.Name = "_removeButton";
            this._removeButton.Size = new System.Drawing.Size(75, 25);
            this._removeButton.TabIndex = 0;
            this._removeButton.Text = "Remove";
            this._removeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._removeButton.UseVisualStyleBackColor = true;
            this._removeButton.Click += new System.EventHandler(this._removeButton_Click);
            // 
            // DevotionPathControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._listView);
            this.Controls.Add(this._buttonPanel);
            this.Name = "DevotionPathControl";
            this.Size = new System.Drawing.Size(708, 250);
            this._buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel _buttonPanel;
        private System.Windows.Forms.Button _removeButton;
        private System.Windows.Forms.Button _setCurrentButton;
        private System.Windows.Forms.Button _fixProblemsButton;
        private System.Windows.Forms.Button _moveUpButton;
        private System.Windows.Forms.Button _moveDownButton;
    }
}
