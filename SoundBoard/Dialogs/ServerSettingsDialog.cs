using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoard
{
	public partial class ServerSettingsDialog : Form
	{
		public string FilesLocation { get => _filesLocation.Text; set => _filesLocation.Text = value; }
		public bool LocalHostOnly { get => _localhost.Checked; set => _localhost.Checked = value; }
		public bool CustomFilesLocation { get => _customFileLocation.Checked; set => _customFileLocation.Checked = value; }
		public ushort Port { get => (ushort)_portNumber.Value; set => _portNumber.Value = value; }


		public ServerSettingsDialog()
		{
			InitializeComponent();
		}

		private void PlaceFiles_Click(Object sender, EventArgs e)
		{
			if (CustomFilesLocation && FilesLocation != "")
			{
				File.WriteAllText(Path.Combine(FilesLocation, "index.html"), Properties.Resources.index);
				File.WriteAllText(Path.Combine(FilesLocation, "navbar.css"), Properties.Resources.navbar);
				File.WriteAllText(Path.Combine(FilesLocation, "script.js"), Properties.Resources.script);
				File.WriteAllText(Path.Combine(FilesLocation, "soundboard.css"), Properties.Resources.soundboard);
			}
		}

		private void FileSelectButton_Click(Object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
			dialog.ShowNewFolderButton = true;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_filesLocation.Text = dialog.SelectedPath;
				PlaceFiles.Enabled = _filesLocation.Text.Length > 0 && _customFileLocation.Checked;
			}
		}

		private void _customFileLocation_CheckedChanged(Object sender, EventArgs e)
		{
			_filesLocation.Enabled = FileSelectButton.Enabled = PlaceFiles.Enabled = _customFileLocation.Checked;
			PlaceFiles.Enabled = _filesLocation.Text.Length > 0 && _customFileLocation.Checked;
		}

		private void _filesLocation_TextChanged(Object sender, EventArgs e)
		{
			PlaceFiles.Enabled = _filesLocation.Text.Length > 0 && _customFileLocation.Checked;
		}
	}
}
