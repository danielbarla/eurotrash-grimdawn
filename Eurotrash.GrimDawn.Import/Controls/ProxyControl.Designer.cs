namespace Eurotrash.GrimDawn.Import.Controls
{
    partial class ProxyControl
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
            this._useProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this._proxyTextBox = new System.Windows.Forms.TextBox();
            this._credentialsNoneRadioButton = new System.Windows.Forms.RadioButton();
            this._credentialsDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this._credentialsManualRadioButton = new System.Windows.Forms.RadioButton();
            this._usernameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._testProxyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _useProxyCheckBox
            // 
            this._useProxyCheckBox.AutoSize = true;
            this._useProxyCheckBox.Location = new System.Drawing.Point(3, 3);
            this._useProxyCheckBox.Name = "_useProxyCheckBox";
            this._useProxyCheckBox.Size = new System.Drawing.Size(74, 17);
            this._useProxyCheckBox.TabIndex = 0;
            this._useProxyCheckBox.Text = "Use Proxy";
            this._useProxyCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proxy:";
            // 
            // _proxyTextBox
            // 
            this._proxyTextBox.Location = new System.Drawing.Point(3, 44);
            this._proxyTextBox.Name = "_proxyTextBox";
            this._proxyTextBox.Size = new System.Drawing.Size(117, 20);
            this._proxyTextBox.TabIndex = 2;
            this._proxyTextBox.Text = "http://[proxy]:[port]";
            // 
            // _credentialsNoneRadioButton
            // 
            this._credentialsNoneRadioButton.AutoSize = true;
            this._credentialsNoneRadioButton.Checked = true;
            this._credentialsNoneRadioButton.Location = new System.Drawing.Point(6, 82);
            this._credentialsNoneRadioButton.Name = "_credentialsNoneRadioButton";
            this._credentialsNoneRadioButton.Size = new System.Drawing.Size(94, 17);
            this._credentialsNoneRadioButton.TabIndex = 3;
            this._credentialsNoneRadioButton.TabStop = true;
            this._credentialsNoneRadioButton.Text = "No Credentials";
            this._credentialsNoneRadioButton.UseVisualStyleBackColor = true;
            // 
            // _credentialsDefaultRadioButton
            // 
            this._credentialsDefaultRadioButton.AutoSize = true;
            this._credentialsDefaultRadioButton.Location = new System.Drawing.Point(6, 105);
            this._credentialsDefaultRadioButton.Name = "_credentialsDefaultRadioButton";
            this._credentialsDefaultRadioButton.Size = new System.Drawing.Size(114, 17);
            this._credentialsDefaultRadioButton.TabIndex = 4;
            this._credentialsDefaultRadioButton.Text = "Default Credentials";
            this._credentialsDefaultRadioButton.UseVisualStyleBackColor = true;
            // 
            // _credentialsManualRadioButton
            // 
            this._credentialsManualRadioButton.AutoSize = true;
            this._credentialsManualRadioButton.Location = new System.Drawing.Point(6, 128);
            this._credentialsManualRadioButton.Name = "_credentialsManualRadioButton";
            this._credentialsManualRadioButton.Size = new System.Drawing.Size(118, 17);
            this._credentialsManualRadioButton.TabIndex = 5;
            this._credentialsManualRadioButton.Text = "Manual Credentials:";
            this._credentialsManualRadioButton.UseVisualStyleBackColor = true;
            // 
            // _usernameTextBox
            // 
            this._usernameTextBox.Location = new System.Drawing.Point(3, 171);
            this._usernameTextBox.Name = "_usernameTextBox";
            this._usernameTextBox.Size = new System.Drawing.Size(117, 20);
            this._usernameTextBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username:";
            // 
            // _passwordTextBox
            // 
            this._passwordTextBox.Location = new System.Drawing.Point(3, 219);
            this._passwordTextBox.Name = "_passwordTextBox";
            this._passwordTextBox.Size = new System.Drawing.Size(117, 20);
            this._passwordTextBox.TabIndex = 9;
            this._passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password:";
            // 
            // _testProxyButton
            // 
            this._testProxyButton.Location = new System.Drawing.Point(6, 245);
            this._testProxyButton.Name = "_testProxyButton";
            this._testProxyButton.Size = new System.Drawing.Size(114, 25);
            this._testProxyButton.TabIndex = 10;
            this._testProxyButton.Text = "Test Connection";
            this._testProxyButton.UseVisualStyleBackColor = true;
            this._testProxyButton.Click += new System.EventHandler(this._testProxyButton_Click);
            // 
            // ProxyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._testProxyButton);
            this.Controls.Add(this._passwordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._usernameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._credentialsManualRadioButton);
            this.Controls.Add(this._credentialsDefaultRadioButton);
            this.Controls.Add(this._credentialsNoneRadioButton);
            this.Controls.Add(this._proxyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._useProxyCheckBox);
            this.Name = "ProxyControl";
            this.Size = new System.Drawing.Size(131, 279);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _useProxyCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _proxyTextBox;
        private System.Windows.Forms.RadioButton _credentialsNoneRadioButton;
        private System.Windows.Forms.RadioButton _credentialsDefaultRadioButton;
        private System.Windows.Forms.RadioButton _credentialsManualRadioButton;
        private System.Windows.Forms.TextBox _usernameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _passwordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button _testProxyButton;
    }
}
