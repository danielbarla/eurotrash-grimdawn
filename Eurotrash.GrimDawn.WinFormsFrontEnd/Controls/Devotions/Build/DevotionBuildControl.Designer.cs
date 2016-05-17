namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Build
{
    partial class DevotionBuildControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevotionBuildControl));
            this._statisticBonusesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this._devotionPathControl = new Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Build.DevotionPathControl();
            this._tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this._tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _statisticBonusesListView
            // 
            this._statisticBonusesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this._statisticBonusesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._statisticBonusesListView.Location = new System.Drawing.Point(3, 3);
            this._statisticBonusesListView.Name = "_statisticBonusesListView";
            this._statisticBonusesListView.Size = new System.Drawing.Size(711, 225);
            this._statisticBonusesListView.TabIndex = 0;
            this._statisticBonusesListView.UseCompatibleStateImageBehavior = false;
            this._statisticBonusesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Effect";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Bonus Source(s)";
            this.columnHeader2.Width = 400;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._devotionPathControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 184);
            this.panel1.TabIndex = 1;
            // 
            // _devotionPathControl
            // 
            this._devotionPathControl.CurrentIndex = null;
            this._devotionPathControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._devotionPathControl.Location = new System.Drawing.Point(0, 0);
            this._devotionPathControl.Name = "_devotionPathControl";
            this._devotionPathControl.Size = new System.Drawing.Size(725, 184);
            this._devotionPathControl.TabIndex = 0;
            this._devotionPathControl.CurrentIndexChanged += new System.EventHandler(this._devotionPathControl_CurrentIndexChanged);
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this.tabPage1);
            this._tabControl.Controls.Add(this.tabPage2);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.ImageList = this._imageList;
            this._tabControl.Location = new System.Drawing.Point(0, 184);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(725, 258);
            this._tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._statisticBonusesListView);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(717, 231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Statistics Bonuses";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(717, 231);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Abilities Granted";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "Chart-Line.png");
            this._imageList.Images.SetKeyName(1, "User-Zorro.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Not implemented yet";
            // 
            // DevotionBuildControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this.panel1);
            this.Name = "DevotionBuildControl";
            this.Size = new System.Drawing.Size(725, 442);
            this.panel1.ResumeLayout(false);
            this._tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _statisticBonusesListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevotionPathControl _devotionPathControl;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList _imageList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
    }
}
