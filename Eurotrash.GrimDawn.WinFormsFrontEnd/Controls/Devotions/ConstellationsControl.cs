using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd.Controls
{
    public partial class ConstellationsControl : UserControl
    {
        public ConstellationsControl()
        {
            InitializeComponent();
        }

        private void _constellationSearchControl_AddToBuild(Eurotrash.GrimDawn.Core.Build.Devotions.DevotionSelectionAction obj)
        {
            _devotionBuildControl.AddDevotionSelectionAction(obj);
        }

        internal void SetDataSource(Eurotrash.GrimDawn.Core.Build.GrimDawnBuild build)
        {
            _devotionBuildControl.SetDataSource(build);
        }
    }
}
