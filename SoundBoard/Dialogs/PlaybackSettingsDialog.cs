using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace SoundBoard
{
	public partial class PlaybackSettingsDialog : Form
	{
		private delegate void MaxPos(double maxPos, double value);

		public int Volume { get => _volume.Value; set => _volume.Value = value; }
		public bool LoopPlayback { get => _loopPlayback.Checked; set => _loopPlayback.Checked = value; }
		public double StartPos { get => (_startPos.Value / 1000D); set => _startPos.Value = (int)(value * 1000); }

		Thread mediaThread;

		private TreeNode Node;

		public PlaybackSettingsDialog(TreeNode node)
		{
			InitializeComponent();
			Node = node;
			var tag = Node.Tag as NodeTag;
			LoopPlayback = tag.PlaybackSettings.Repeat;
			Volume = tag.PlaybackSettings.Volume;
			var player = new WindowsMediaPlayer();
			textBox1.Enabled = false;
			_startPos.Enabled = false;
			player.OpenStateChange += (state) =>
			{
				if (((WMPOpenState)state) == WMPOpenState.wmposMediaOpen)
				{
					UpdatePosSlider(player.currentMedia.duration, tag.PlaybackSettings.StartPos);
					player.controls.stop();
					player.controls.pause();
				}
			};
			player.URL = tag.Path;
		}

		private void UpdatePosSlider(double maxPos, double value)
		{
			Invoke(new MaxPos(_updatePosSlider), maxPos, value);
		}

		private void _updatePosSlider(double maxPos, double value)
		{
			_startPos.Maximum = (int)(maxPos * 1000);
			_startPos.TickFrequency = _startPos.Maximum > 70000 ? 60000 : 10000;
			_startPos.Enabled = true;
			_startPos.Value = (int)(value * 1000);
			textBox1.Text = (_startPos.Value/1000D) + " s";
			textBox1.Enabled = true;
		}

		private void _loopPlayback_CheckedChanged(Object sender, EventArgs e)
		{
			if (Visible)
			{
				var tag = Node.Tag as NodeTag;
				if (LoopPlayback) tag.Player.settings.setMode("loop", true);
				tag.Player.settings.volume = Volume;
			}
		}

		private void _volume_Scroll(Object sender, EventArgs e)
		{
			if (Visible)
			{
				var tag = Node.Tag as NodeTag;
				tag.Player.settings.volume = Volume;
			}
		}

		private void textBox1_TextChanged(Object sender, EventArgs e)
		{
			if (Visible)
			{
				var translated = Double.Parse(textBox1.Text.Substring(0, (textBox1.Text.EndsWith(" s") ? textBox1.Text.Length - 2 : textBox1.Text.Length)).Replace('.', ','));
				if (translated > _startPos.Maximum) translated = _startPos.Maximum;
				if (translated < 0) translated = 0;
				_startPos.Value = (int)(translated * 1000);
			}
		}

		private void _startPos_Scroll(Object sender, EventArgs e)
		{
			if (Visible)
			{
				var translated = (_startPos.Value / 1000D);
				textBox1.Text = translated + " s";
			}
		}

		private void textBox1_Leave(Object sender, EventArgs e)
		{
			if (!textBox1.Text.EndsWith(" s")) textBox1.Text += " s";
		}
	}
}
