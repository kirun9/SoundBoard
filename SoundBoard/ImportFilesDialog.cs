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
	public partial class ImportFilesDialog : Form
	{
		public ImportFilesDialog()
		{
			InitializeComponent();
			checkBox1.Checked = false;
		}

		private void checkBox1_CheckedChanged(Object sender, EventArgs e)
		{
			NodeName.Visible = label2.Enabled = checkBox1.Checked;
		}

		private void SelectFiles_Click(Object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.CheckPathExists = true;
			dialog.DefaultExt = "mp3";
			dialog.Filter = "All Files|*.*|All Supported Formats|*.asf;*.wma;*.wmv;*.wm;*.asx;*.wax;*.wvx;*.wmx;*.wpl;*.dvr-ms;*.wmd;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mid;*.midi;*.rmi;*.aif;*.aifc;*.aiff;*.au;*.snd;*.wav;*.cda;*.ivf;*.wmz;*.wms;*.mov;*.m4a;*.mp4;*.m4v;*.mp4v;*.3g2;*.3gp2;*.3gp;*.3gpp;*.aac;*.adt;*.adts;*.m2ts;|Windows Media formats|*.asf;*.wma;*.wmv;*.wm|Windows Media Metafiles|*.asx;*.wax;*.wvx;*.wmx;*.wpl|Microsoft Digital Video Recording|*.dvr-ms|Windows Media Download Package|*.wmd|Audio Visual Interleave|*.avi|Moving Pictures Experts Group|*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u|Musical Instrument Digital Interface|*.mid;*.midi;*.rmi|Audio Interchange File Format|*.aif;*.aifc;*.aiff|Sun Microsystems and NeXT|*.au;*.snd|Audio for Windows|*.wav|CD Audio Track|*.cda|Indeo Video Technology|*.ivf|Windows Media Player Skins|*.wmz;*.wms|QuickTime Movie file|*.mov|MP4 Audio file|*.m4a|MP4 Video file|*.mp4;*.m4v;*.mp4v;*.3g2;*.3gp2;*.3gp;*.3gpp|Windows audio file|*.aac;*.adt;*.adts|MPEG-2 TS Video file|*.m2ts|Free Lossless Audio Codec|*.flac";
			dialog.FilterIndex = 1;
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			dialog.Multiselect = true;
			dialog.SupportMultiDottedExtensions = true;
			dialog.Title = "Select sound file";
			dialog.ValidateNames = true;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				FilePaths.Lines = dialog.FileNames;
				NodeName.Text = System.IO.Path.GetDirectoryName(dialog.FileName);
			}
		}

		private void FilePaths_TextChanged(Object sender, EventArgs e)
		{
			OkButton.Enabled = FilePaths.Text.Length > 0 && (NodeName.Text.Length > 0 && checkBox1.Checked);
		}

		private void NodeName_TextChanged(Object sender, EventArgs e)
		{
			OkButton.Enabled = FilePaths.Text.Length > 0 && (NodeName.Text.Length > 0 && checkBox1.Checked);
		}
	}
}
