using Eurotrash.GrimDawn.Import.Common;
using System;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.Import.Controls
{
    public partial class ProxyControl : UserControl
    {
        public ProxyControl()
        {
            InitializeComponent();

            HookupUIEvents();
            UpdateControls();
        }

        private void HookupUIEvents()
        {
            _credentialsNoneRadioButton.CheckedChanged += UIElementChanged;
            _credentialsDefaultRadioButton.CheckedChanged += UIElementChanged;
            _credentialsManualRadioButton.CheckedChanged += UIElementChanged;
            _useProxyCheckBox.CheckedChanged += UIElementChanged;
            _proxyTextBox.TextChanged += UIElementChanged;
            _usernameTextBox.TextChanged += UIElementChanged;
            _passwordTextBox.TextChanged += UIElementChanged;
        }

        private void UpdateProxySettings()
        {
            ProxySettings.UseProxy = _useProxyCheckBox.Checked;
            ProxySettings.ProxyAddress = _proxyTextBox.Text;
            ProxySettings.CredentialsMode = GetCredentialsMode();
            ProxySettings.Username = _usernameTextBox.Text;
            ProxySettings.Password = _passwordTextBox.Text;
        }

        private ProxyCredentialsMode GetCredentialsMode()
        {
            if (_credentialsNoneRadioButton.Checked)
                return ProxyCredentialsMode.None;

            if (_credentialsDefaultRadioButton.Checked)
                return ProxyCredentialsMode.Default;

            return ProxyCredentialsMode.Manual;
        }

        /// <summary>
        /// Implements the business rules for enabling / disabling parts of the proxy settings UI.
        /// </summary>
        private void UpdateControls()
        {
            bool useProxy = _useProxyCheckBox.Checked;

            _proxyTextBox.Enabled = useProxy;
            _credentialsNoneRadioButton.Enabled = useProxy;
            _credentialsDefaultRadioButton.Enabled = useProxy;
            _credentialsManualRadioButton.Enabled = useProxy;

            bool manualAuthentication = _credentialsManualRadioButton.Checked;

            _usernameTextBox.Enabled = useProxy && manualAuthentication;
            _passwordTextBox.Enabled = useProxy && manualAuthentication;
        }

        /// <summary>
        /// Generic handler for any UI changes.  Updates the global proxy settings and re-applies
        /// UI enabling / disabling rules.
        /// </summary>
        private void UIElementChanged(object sender, EventArgs e)
        {
            UpdateProxySettings();
            UpdateControls();
        }

        private void _testProxyButton_Click(object sender, EventArgs e)
        {
            try
            {
                HttpHelper.GetString("http://grimdawn.wikia.com/wiki/Constellation");

                MessageBox.Show("Successfully retrieved the Constellation page.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                string errorDetails = GetDeepestErrorMessage(exc);

                string message = String.Format("An error occurred while accessing the Constellation page from the Grim Dawn Wiki:\r\n\r\n{0}", errorDetails);

                MessageBox.Show(message, "Error retrieving Wiki page", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDeepestErrorMessage(Exception exc)
        {
            while (exc.InnerException != null)
                exc = exc.InnerException;

            return exc.Message;
        }
    }
}
