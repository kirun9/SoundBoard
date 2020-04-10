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
	public partial class ItemDialog : Form
	{
		public string FilePath
		{
			get
			{
				return _FilePath.Text;
			}
			set
			{
				_FilePath.Text = value;
				_FilePath.Invalidate();
			}
		}

		public string SoundName
		{
			get
			{
				return _SoundName.Text;
			}
			set
			{
				_SoundName.Text = value;
				_SoundName.Invalidate();
			}
		}

		public ItemDialog()
		{
			InitializeComponent();
		}

		private void FilePath_TextChanged(Object sender, EventArgs e)
		{
			OkButton.Enabled = _FilePath.Text.Length > 0 && _SoundName.Text.Length > 0;
		}

		private void SoundName_TextChanged(Object sender, EventArgs e)
		{
			OkButton.Enabled = _FilePath.Text.Length > 0 && _SoundName.Text.Length > 0;
		}
		private void NodeDialog_KeyUp(Object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				OkButton.PerformClick();
			}
		}

		private void FileSelectButton_Click(Object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.CheckPathExists = true;
			dialog.DefaultExt = "mp3";
			dialog.Filter = "All Files|*.*|All Supported Formats|*.asf;*.wma;*.wmv;*.wm;*.asx;*.wax;*.wvx;*.wmx;*.wpl;*.dvr-ms;*.wmd;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mid;*.midi;*.rmi;*.aif;*.aifc;*.aiff;*.au;*.snd;*.wav;*.cda;*.ivf;*.wmz;*.wms;*.mov;*.m4a;*.mp4;*.m4v;*.mp4v;*.3g2;*.3gp2;*.3gp;*.3gpp;*.aac;*.adt;*.adts;*.m2ts;|Windows Media formats|*.asf;*.wma;*.wmv;*.wm|Windows Media Metafiles|*.asx;*.wax;*.wvx;*.wmx;*.wpl|Microsoft Digital Video Recording|*.dvr-ms|Windows Media Download Package|*.wmd|Audio Visual Interleave|*.avi|Moving Pictures Experts Group|*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u|Musical Instrument Digital Interface|*.mid;*.midi;*.rmi|Audio Interchange File Format|*.aif;*.aifc;*.aiff|Sun Microsystems and NeXT|*.au;*.snd|Audio for Windows|*.wav|CD Audio Track|*.cda|Indeo Video Technology|*.ivf|Windows Media Player Skins|*.wmz;*.wms|QuickTime Movie file|*.mov|MP4 Audio file|*.m4a|MP4 Video file|*.mp4;*.m4v;*.mp4v;*.3g2;*.3gp2;*.3gp;*.3gpp|Windows audio file|*.aac;*.adt;*.adts|MPEG-2 TS Video file|*.m2ts|Free Lossless Audio Codec|*.flac";
			dialog.FilterIndex = 1;
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			dialog.Multiselect = false;
			dialog.SupportMultiDottedExtensions = true;
			dialog.Title = "Select sound file";
			dialog.ValidateNames = true;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				_FilePath.Text = dialog.FileName;
				_SoundName.Text = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
			}
		}
	}
}
