namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Forms
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.label1 = new System.Windows.Forms.Label();
            this._errorDetailsTextBox = new System.Windows.Forms.TextBox();
            this._closeButton = new System.Windows.Forms.Button();
            this._copyToClipboardButton = new System.Windows.Forms.Button();
            this._messageLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "An unexpected error has occurred:";
            // 
            // _errorDetailsTextBox
            // 
            this._errorDetailsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._errorDetailsTextBox.Location = new System.Drawing.Point(12, 108);
            this._errorDetailsTextBox.Multiline = true;
            this._errorDetailsTextBox.Name = "_errorDetailsTextBox";
            this._errorDetailsTextBox.ReadOnly = true;
            this._errorDetailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._errorDetailsTextBox.Size = new System.Drawing.Size(658, 190);
            this._errorDetailsTextBox.TabIndex = 1;
            // 
            // _closeButton
            // 
            this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._closeButton.Location = new System.Drawing.Point(420, 304);
            this._closeButton.Name = "_closeButton";
            this._closeButton.Size = new System.Drawing.Size(122, 25);
            this._closeButton.TabIndex = 2;
            this._closeButton.Text = "Close and Continue";
            this._closeButton.UseVisualStyleBackColor = true;
            this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
            // 
            // _copyToClipboardButton
            // 
            this._copyToClipboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._copyToClipboardButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._copyToClipboardButton.Location = new System.Drawing.Point(260, 304);
            this._copyToClipboardButton.Name = "_copyToClipboardButton";
            this._copyToClipboardButton.Size = new System.Drawing.Size(154, 25);
            this._copyToClipboardButton.TabIndex = 3;
            this._copyToClipboardButton.Text = "Copy Details to Clipboard";
            this._copyToClipboardButton.UseVisualStyleBackColor = true;
            this._copyToClipboardButton.Click += new System.EventHandler(this._copyToClipboardButton_Click);
            // 
            // _messageLabel
            // 
            this._messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._messageLabel.Location = new System.Drawing.Point(50, 38);
            this._messageLabel.Name = "_messageLabel";
            this._messageLabel.Size = new System.Drawing.Size(608, 31);
            this._messageLabel.TabIndex = 4;
            this._messageLabel.Text = "[message]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "It is recommended that you restart the application.";
            // 
            // _exitButton
            // 
            this._exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._exitButton.Location = new System.Drawing.Point(548, 304);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(122, 25);
            this._exitButton.TabIndex = 6;
            this._exitButton.Text = "Exit Application";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this._exitButton_Click);
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._exitButton;
            this.ClientSize = new System.Drawing.Size(682, 339);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._messageLabel);
            this.Controls.Add(this._copyToClipboardButton);
            this.Controls.Add(this._closeButton);
            this.Controls.Add(this._errorDetailsTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErrorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "An error has occurred...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _errorDetailsTextBox;
        private System.Windows.Forms.Button _closeButton;
        private System.Windows.Forms.Button _copyToClipboardButton;
        private System.Windows.Forms.Label _messageLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _exitButton;
    }
}