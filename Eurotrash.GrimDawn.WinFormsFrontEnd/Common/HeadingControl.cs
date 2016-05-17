using System;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Common
{
    public partial class HeadingControl : UserControl
    {
        public HeadingControl()
        {
            InitializeComponent();
        }

        public string HeadingText
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
    }
}
