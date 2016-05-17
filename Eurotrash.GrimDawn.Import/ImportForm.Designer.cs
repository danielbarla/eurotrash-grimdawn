namespace Eurotrash.GrimDawn.Import
{
    partial class ImportForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this._tabControl = new System.Windows.Forms.TabControl();
            this._devotionsTabPage = new System.Windows.Forms.TabPage();
            this._devotionsImportControl = new Eurotrash.GrimDawn.Import.Controls.DevotionsImportControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._instructionsTextBox = new System.Windows.Forms.TextBox();
            this._tabControl.SuspendLayout();
            this._devotionsTabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._devotionsTabPage);
            this._tabControl.Controls.Add(this.tabPage1);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(971, 471);
            this._tabControl.TabIndex = 0;
            // 
            // _devotionsTabPage
            // 
            this._devotionsTabPage.Controls.Add(this._devotionsImportControl);
            this._devotionsTabPage.Location = new System.Drawing.Point(4, 22);
            this._devotionsTabPage.Name = "_devotionsTabPage";
            this._devotionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._devotionsTabPage.Size = new System.Drawing.Size(963, 445);
            this._devotionsTabPage.TabIndex = 0;
            this._devotionsTabPage.Text = "Devotions";
            this._devotionsTabPage.UseVisualStyleBackColor = true;
            // 
            // _devotionsImportControl
            // 
            this._devotionsImportControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._devotionsImportControl.Location = new System.Drawing.Point(3, 3);
            this._devotionsImportControl.Name = "_devotionsImportControl";
            this._devotionsImportControl.Size = new System.Drawing.Size(957, 439);
            this._devotionsImportControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._instructionsTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(963, 445);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Instructions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _instructionsTextBox
            // 
            this._instructionsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._instructionsTextBox.Location = new System.Drawing.Point(3, 3);
            this._instructionsTextBox.Multiline = true;
            this._instructionsTextBox.Name = "_instructionsTextBox";
            this._instructionsTextBox.ReadOnly = true;
            this._instructionsTextBox.Size = new System.Drawing.Size(957, 439);
            this._instructionsTextBox.TabIndex = 0;
            this._instructionsTextBox.Text = resources.GetString("_instructionsTextBox.Text");
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 471);
            this.Controls.Add(this._tabControl);
            this.Name = "ImportForm";
            this.Text = "Eurotrash.GrimDawn Import Form";
            this._tabControl.ResumeLayout(false);
            this._devotionsTabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _devotionsTabPage;
        private Controls.DevotionsImportControl _devotionsImportControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox _instructionsTextBox;
    }
}

