using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

		}

		private void FileSelectButton_Click(Object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.RootFolder = Environment.SpecialFolder.DesktopDirectory;
			dialog.ShowNewFolderButton = true;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_filesLocation.Text = dialog.SelectedPath;
			}
		}

		private void _customFileLocation_CheckedChanged(Object sender, EventArgs e)
		{
			_filesLocation.Enabled = FileSelectButton.Enabled = PlaceFiles.Enabled = _customFileLocation.Checked;
			PlaceFiles.Enabled = false;
		}
	}
}
