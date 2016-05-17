namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls
{
    partial class ConstellationsControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._devotionBuildControl = new Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Build.DevotionBuildControl();
            this.headingControl1 = new Eurotrash.GrimDawn.WinFormsFrontEnd.Common.HeadingControl();
            this._constellationSearchControl = new Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Search.ConstellationSearchControl();
            this.headingControl2 = new Eurotrash.GrimDawn.WinFormsFrontEnd.Common.HeadingControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._devotionBuildControl);
            this.splitContainer1.Panel1.Controls.Add(this.headingControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._constellationSearchControl);
            this.splitContainer1.Panel2.Controls.Add(this.headingControl2);
            this.splitContainer1.Size = new System.Drawing.Size(915, 512);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 0;
            // 
            // _devotionBuildControl
            // 
            this._devotionBuildControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._devotionBuildControl.Location = new System.Drawing.Point(0, 28);
            this._devotionBuildControl.Name = "_devotionBuildControl";
            this._devotionBuildControl.Size = new System.Drawing.Size(500, 484);
            this._devotionBuildControl.TabIndex = 1;
            // 
            // headingControl1
            // 
            this.headingControl1.BackColor = System.Drawing.Color.DimGray;
            this.headingControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headingControl1.HeadingText = "Devotions Build";
            this.headingControl1.Location = new System.Drawing.Point(0, 0);
            this.headingControl1.Name = "headingControl1";
            this.headingControl1.Size = new System.Drawing.Size(500, 28);
            this.headingControl1.TabIndex = 0;
            // 
            // _constellationSearchControl
            // 
            this._constellationSearchControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._constellationSearchControl.Location = new System.Drawing.Point(0, 28);
            this._constellationSearchControl.Name = "_constellationSearchControl";
            this._constellationSearchControl.Size = new System.Drawing.Size(411, 484);
            this._constellationSearchControl.TabIndex = 2;
            this._constellationSearchControl.AddToBuild += new System.Action<Eurotrash.GrimDawn.Core.Build.Devotions.DevotionSelectionAction>(this._constellationSearchControl_AddToBuild);
            // 
            // headingControl2
            // 
            this.headingControl2.BackColor = System.Drawing.Color.DimGray;
            this.headingControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.headingControl2.HeadingText = "Search";
            this.headingControl2.Location = new System.Drawing.Point(0, 0);
            this.headingControl2.Name = "headingControl2";
            this.headingControl2.Size = new System.Drawing.Size(411, 28);
            this.headingControl2.TabIndex = 1;
            // 
            // ConstellationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConstellationsControl";
            this.Size = new System.Drawing.Size(915, 512);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Common.HeadingControl headingControl1;
        private Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Build.DevotionBuildControl _devotionBuildControl;
        private Common.HeadingControl headingControl2;
        private Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Search.ConstellationSearchControl _constellationSearchControl;
    }
}
