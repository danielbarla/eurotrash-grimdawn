namespace Eurotrash.GrimDawn.Import.Controls
{
    partial class DevotionsImportControl
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
            this.proxyControl1 = new Eurotrash.GrimDawn.Import.Controls.ProxyControl();
            this._downloadImagesButton = new System.Windows.Forms.Button();
            this._parseDetailsButton = new System.Windows.Forms.Button();
            this._downloadDetailPagesButton = new System.Windows.Forms.Button();
            this._parseIndexButton = new System.Windows.Forms.Button();
            this._downloadIndexButton = new System.Windows.Forms.Button();
            this._listBox = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.proxyControl1);
            this.panel1.Controls.Add(this._downloadImagesButton);
            this.panel1.Controls.Add(this._parseDetailsButton);
            this.panel1.Controls.Add(this._downloadDetailPagesButton);
            this.panel1.Controls.Add(this._parseIndexButton);
            this.panel1.Controls.Add(this._downloadIndexButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 438);
            this.panel1.TabIndex = 0;
            // 
            // proxyControl1
            // 
            this.proxyControl1.Location = new System.Drawing.Point(3, 158);
            this.proxyControl1.Name = "proxyControl1";
            this.proxyControl1.Size = new System.Drawing.Size(136, 272);
            this.proxyControl1.TabIndex = 5;
            // 
            // _downloadImagesButton
            // 
            this._downloadImagesButton.Location = new System.Drawing.Point(3, 127);
            this._downloadImagesButton.Name = "_downloadImagesButton";
            this._downloadImagesButton.Size = new System.Drawing.Size(152, 25);
            this._downloadImagesButton.TabIndex = 4;
            this._downloadImagesButton.Text = "Debug: Download Images";
            this._downloadImagesButton.UseVisualStyleBackColor = true;
            this._downloadImagesButton.Click += new System.EventHandler(this._downloadImagesButton_Click);
            // 
            // _parseDetailsButton
            // 
            this._parseDetailsButton.Location = new System.Drawing.Point(3, 65);
            this._parseDetailsButton.Name = "_parseDetailsButton";
            this._parseDetailsButton.Size = new System.Drawing.Size(152, 25);
            this._parseDetailsButton.TabIndex = 3;
            this._parseDetailsButton.Text = "3. Parse Details";
            this._parseDetailsButton.UseVisualStyleBackColor = true;
            this._parseDetailsButton.Click += new System.EventHandler(this._parseDetailsButton_Click);
            // 
            // _downloadDetailPagesButton
            // 
            this._downloadDetailPagesButton.Location = new System.Drawing.Point(3, 34);
            this._downloadDetailPagesButton.Name = "_downloadDetailPagesButton";
            this._downloadDetailPagesButton.Size = new System.Drawing.Size(152, 25);
            this._downloadDetailPagesButton.TabIndex = 2;
            this._downloadDetailPagesButton.Text = "2. Download Details";
            this._downloadDetailPagesButton.UseVisualStyleBackColor = true;
            this._downloadDetailPagesButton.Click += new System.EventHandler(this._downloadDetailPagesButton_Click);
            // 
            // _parseIndexButton
            // 
            this._parseIndexButton.Location = new System.Drawing.Point(3, 96);
            this._parseIndexButton.Name = "_parseIndexButton";
            this._parseIndexButton.Size = new System.Drawing.Size(152, 25);
            this._parseIndexButton.TabIndex = 1;
            this._parseIndexButton.Text = "Debug: Parse Index";
            this._parseIndexButton.UseVisualStyleBackColor = true;
            this._parseIndexButton.Click += new System.EventHandler(this._parseIndexButton_Click);
            // 
            // _downloadIndexButton
            // 
            this._downloadIndexButton.Location = new System.Drawing.Point(3, 3);
            this._downloadIndexButton.Name = "_downloadIndexButton";
            this._downloadIndexButton.Size = new System.Drawing.Size(152, 25);
            this._downloadIndexButton.TabIndex = 0;
            this._downloadIndexButton.Text = "1. Download Index";
            this._downloadIndexButton.UseVisualStyleBackColor = true;
            this._downloadIndexButton.Click += new System.EventHandler(this._downloadIndexButton_Click);
            // 
            // _listBox
            // 
            this._listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listBox.FormattingEnabled = true;
            this._listBox.Location = new System.Drawing.Point(160, 0);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(493, 438);
            this._listBox.TabIndex = 1;
            // 
            // DevotionsImportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._listBox);
            this.Controls.Add(this.panel1);
            this.Name = "DevotionsImportControl";
            this.Size = new System.Drawing.Size(653, 438);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _downloadIndexButton;
        private System.Windows.Forms.ListBox _listBox;
        private System.Windows.Forms.Button _parseIndexButton;
        private System.Windows.Forms.Button _downloadDetailPagesButton;
        private System.Windows.Forms.Button _parseDetailsButton;
        private System.Windows.Forms.Button _downloadImagesButton;
        private ProxyControl proxyControl1;
    }
}
