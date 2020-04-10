namespace SoundBoard
{
	partial class ItemDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDialog));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this._FilePath = new System.Windows.Forms.TextBox();
			this._SoundName = new System.Windows.Forms.TextBox();
			this.FileSelectButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "File Location";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Sound Name";
			// 
			// _FilePath
			// 
			this._FilePath.Location = new System.Drawing.Point(88, 10);
			this._FilePath.Name = "_FilePath";
			this._FilePath.Size = new System.Drawing.Size(237, 20);
			this._FilePath.TabIndex = 0;
			this._FilePath.TextChanged += new System.EventHandler(this.FilePath_TextChanged);
			this._FilePath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NodeDialog_KeyUp);
			// 
			// _SoundName
			// 
			this._SoundName.Location = new System.Drawing.Point(88, 35);
			this._SoundName.Name = "_SoundName";
			this._SoundName.Size = new System.Drawing.Size(237, 20);
			this._SoundName.TabIndex = 2;
			this._SoundName.TextChanged += new System.EventHandler(this.SoundName_TextChanged);
			this._SoundName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NodeDialog_KeyUp);
			// 
			// FileSelectButton
			// 
			this.FileSelectButton.Location = new System.Drawing.Point(331, 9);
			this.FileSelectButton.Name = "FileSelectButton";
			this.FileSelectButton.Size = new System.Drawing.Size(34, 20);
			this.FileSelectButton.TabIndex = 1;
			this.FileSelectButton.Text = "•••";
			this.FileSelectButton.UseVisualStyleBackColor = true;
			this.FileSelectButton.Click += new System.EventHandler(this.FileSelectButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Enabled = false;
			this.OkButton.Location = new System.Drawing.Point(290, 72);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 3;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Location = new System.Drawing.Point(209, 72);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 4;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// ItemDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 107);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.FileSelectButton);
			this.Controls.Add(this._SoundName);
			this.Controls.Add(this._FilePath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ItemDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sound Creator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button FileSelectButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancelButton;
		internal System.Windows.Forms.TextBox _SoundName;
		internal System.Windows.Forms.TextBox _FilePath;
	}
}