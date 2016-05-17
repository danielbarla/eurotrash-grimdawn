using Eurotash.GrimDawn.Core.Build;
using Eurotrash.GrimDawn.WinFormsFrontEnd.Common;
using Eurotrash.GrimDawn.WinFormsFrontEnd.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Eurotrash.GrimDawn.WinFormsFrontEnd
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Text = String.Format(this.Text, Eurotash.GrimDawn.Core.VersionInfo.ShortVersion);
        }

        State _state;

        GrimDawnBuild _build;

        string _currentFileName;

        private void MainForm_Load(object sender, EventArgs e)
        {
            _state = State.Load();

            _build = LoadOrCreateBuild();
            _constellationsControl.SetDataSource(_build);

            RebuildRecentFiles();
            UpdateControls();
        }

        #region Menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _build = new GrimDawnBuild();
            _constellationsControl.SetDataSource(_build);

            _currentFileName = null;

            UpdateControls();
        }

        private GrimDawnBuild LoadOrCreateBuild()
        {
            foreach (string file in _state.RecentFiles)
            {
                if (!File.Exists(file))
                    continue;

                _currentFileName = file;

                return GrimDawnBuild.Load(file, Context.GrimDawnDataContext);
            }

            return new GrimDawnBuild();
        }

        private void UpdateControls()
        {
            bool fileNameIsKnown = _currentFileName != null;

            saveToolStripMenuItem.Enabled = fileNameIsKnown;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Grim Dawn Build Files (*.gdbuild)|*.gdbuild";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _build.Save(dialog.FileName);

                    _state.AddRecentFile(dialog.FileName);
                    RebuildRecentFiles();

                    _currentFileName = dialog.FileName;
                    UpdateControls();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _build.Save(_currentFileName);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Grim Dawn Build Files (*.gdbuild)|*.gdbuild";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _currentFileName = dialog.FileName;
                    _build = GrimDawnBuild.Load(dialog.FileName, Context.GrimDawnDataContext);

                    _state.AddRecentFile(dialog.FileName);
                    RebuildRecentFiles();
                    _constellationsControl.SetDataSource(_build);
                }
            }
        }

        private void RebuildRecentFiles()
        {
            recentFilesToolStripMenuItem.DropDownItems.Clear();

            int index = 1;
            foreach (string file in _state.RecentFiles)
            {
                var item = new ToolStripMenuItem();

                string text = GetShortenedPath(index, file);

                item.Text = text;
                item.AutoSize = true;
                item.Tag = file;
                item.Click += RecentFileItem_Click;

                recentFilesToolStripMenuItem.DropDownItems.Add(item);

                index++;
            }
        }

        private string GetShortenedPath(int index, string file)
        {
            const int maxLength = 60;

            if (file.Length > maxLength + 3)
            {
                string firstPart = file.Substring(0, 3);

                string endPart = file.Substring(file.Length - maxLength);

                return String.Format("{0} {1}...{2}", index, firstPart, endPart);
            }
            else
            {
                return String.Format("{0} {1}", index, file);
            }
        }

        private void RecentFileItem_Click(object sender, EventArgs e)
        {
            string file = ((ToolStripMenuItem)sender).Tag as string;

            if (File.Exists(file))
            {
                _build = GrimDawnBuild.Load(file, Context.GrimDawnDataContext);

                _state.AddRecentFile(file); // Move item back to top
                _constellationsControl.SetDataSource(_build);
            }
        }

        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Eurotrash.GrimDawn.WinFormsFrontEnd.Forms.AboutForm().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
