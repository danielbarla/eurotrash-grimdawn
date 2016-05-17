namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Search
{
    partial class ConstellationSearchControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._effectsTextBox = new System.Windows.Forms.TextBox();
            this._tipLabel = new System.Windows.Forms.Label();
            this._constellationsTreeView = new Eurotrash.GrimDawn.WinFormsFrontEnd.Controls.Search.ConstellationsTreeView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._searchButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._effectsTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 74);
            this.panel1.TabIndex = 0;
            // 
            // _searchButton
            // 
            this._searchButton.Location = new System.Drawing.Point(16, 37);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(75, 25);
            this._searchButton.TabIndex = 2;
            this._searchButton.Text = "Search";
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this._searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search:";
            // 
            // _effectsTextBox
            // 
            this._effectsTextBox.Location = new System.Drawing.Point(105, 6);
            this._effectsTextBox.Name = "_effectsTextBox";
            this._effectsTextBox.Size = new System.Drawing.Size(207, 20);
            this._effectsTextBox.TabIndex = 0;
            this._effectsTextBox.Text = "Fire";
            // 
            // _tipLabel
            // 
            this._tipLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._tipLabel.AutoSize = true;
            this._tipLabel.BackColor = System.Drawing.Color.White;
            this._tipLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._tipLabel.Location = new System.Drawing.Point(830, 77);
            this._tipLabel.Name = "_tipLabel";
            this._tipLabel.Size = new System.Drawing.Size(127, 13);
            this._tipLabel.TabIndex = 2;
            this._tipLabel.Text = "Right-click to add to build";
            this._tipLabel.Visible = false;
            // 
            // _constellationsTreeView
            // 
            this._constellationsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._constellationsTreeView.Location = new System.Drawing.Point(0, 74);
            this._constellationsTreeView.Name = "_constellationsTreeView";
            this._constellationsTreeView.Size = new System.Drawing.Size(960, 400);
            this._constellationsTreeView.TabIndex = 1;
            this._constellationsTreeView.AddToBuild += new System.Action<Eurotash.GrimDawn.Core.Build.Devotions.DevotionSelectionAction>(this._constellationsTreeView_AddToBuild);
            // 
            // ConstellationSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tipLabel);
            this.Controls.Add(this._constellationsTreeView);
            this.Controls.Add(this.panel1);
            this.Name = "ConstellationSearchControl";
            this.Size = new System.Drawing.Size(960, 474);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _effectsTextBox;
        private System.Windows.Forms.Button _searchButton;
        private ConstellationsTreeView _constellationsTreeView;
        private System.Windows.Forms.Label _tipLabel;
    }
}
