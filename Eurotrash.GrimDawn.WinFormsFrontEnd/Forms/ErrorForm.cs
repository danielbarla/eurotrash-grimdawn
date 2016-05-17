using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Forms
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        public void SetException(Exception exception)
        {
            _messageLabel.Text = exception.Message;

            var text = new StringBuilder();

            AddDetails(exception, text);

            _errorDetailsTextBox.Text = text.ToString();
        }

        private void AddDetails(Exception exception, StringBuilder text)
        {
            text.AppendLine(String.Format("Message: {0}", exception.Message));
            text.AppendLine(String.Format("Stack trace: {0}", exception.StackTrace.ToString()));

            text.AppendLine();

            if (exception.InnerException != null)
            {
                text.AppendLine("Inner exception...");
                AddDetails(exception.InnerException, text);
            }
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _copyToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_errorDetailsTextBox.Text);
        }

        private void _exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }
    }
}
