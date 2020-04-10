using SoundBoard.Properties;

namespace SoundBoard
{
	partial class PlaybackSettingsDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaybackSettingsDialog));
			this.CancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this._loopPlayback = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this._volume = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this._startPos = new System.Windows.Forms.TrackBar();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this._volume)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._startPos)).BeginInit();
			this.SuspendLayout();
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Location = new System.Drawing.Point(209, 201);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 8;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(290, 201);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 7;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Loop playback";
			// 
			// _loopPlayback
			// 
			this._loopPlayback.AutoSize = true;
			this._loopPlayback.Location = new System.Drawing.Point(144, 15);
			this._loopPlayback.Name = "_loopPlayback";
			this._loopPlayback.Size = new System.Drawing.Size(15, 14);
			this._loopPlayback.TabIndex = 11;
			this._loopPlayback.UseVisualStyleBackColor = true;
			this._loopPlayback.CheckedChanged += new System.EventHandler(this._loopPlayback_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Volume";
			// 
			// _volume
			// 
			this._volume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._volume.LargeChange = 10;
			this._volume.Location = new System.Drawing.Point(12, 47);
			this._volume.Maximum = 100;
			this._volume.Name = "_volume";
			this._volume.Size = new System.Drawing.Size(353, 45);
			this._volume.TabIndex = 9;
			this._volume.TickFrequency = 25;
			this._volume.TickStyle = System.Windows.Forms.TickStyle.Both;
			this._volume.Scroll += new System.EventHandler(this._volume_Scroll);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Start Position";
			// 
			// _startPos
			// 
			this._startPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._startPos.LargeChange = 10;
			this._startPos.Location = new System.Drawing.Point(12, 124);
			this._startPos.Maximum = 100;
			this._startPos.Name = "_startPos";
			this._startPos.Size = new System.Drawing.Size(353, 45);
			this._startPos.TabIndex = 9;
			this._startPos.TickFrequency = 60000;
			this._startPos.TickStyle = System.Windows.Forms.TickStyle.Both;
			this._startPos.Scroll += new System.EventHandler(this._startPos_Scroll);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(144, 98);
			this.textBox1.MaxLength = 12;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(76, 20);
			this.textBox1.TabIndex = 14;
			this.textBox1.Text = "0.000 s";
			this.textBox1.WordWrap = false;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
			// 
			// PlaybackSettingsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 236);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._loopPlayback);
			this.Controls.Add(this._startPos);
			this.Controls.Add(this._volume);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OkButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PlaybackSettingsDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sound Playback Settings";
			((System.ComponentModel.ISupportInitialize)(this._volume)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._startPos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox _loopPlayback;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar _volume;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar _startPos;
		private System.Windows.Forms.TextBox textBox1;
	}
}