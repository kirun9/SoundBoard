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
	public partial class NodeDialog : Form
	{
		public string NodeName
		{
			get
			{
				return _NodeName.Text;
			}
			set
			{
				_NodeName.Text = value;
				_NodeName.Invalidate();
			}
		}

		public NodeDialog()
		{
			InitializeComponent();
		}

		private void NodeName_TextChanged(Object sender, EventArgs e)
		{
			button1.Enabled = _NodeName.Text.Length > 0;
		}

		private void NodeDialog_KeyUp(Object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				button1.PerformClick();
			}
		}
	}
}
