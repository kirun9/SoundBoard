namespace SoundBoard
{
	partial class ServerSettingsDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerSettingsDialog));
			this.CancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this._portNumber = new System.Windows.Forms.NumericUpDown();
			this._localhost = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this._customFileLocation = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.FileSelectButton = new System.Windows.Forms.Button();
			this._filesLocation = new System.Windows.Forms.TextBox();
			this.PlaceFiles = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this._portNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Location = new System.Drawing.Point(209, 149);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 6;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(290, 149);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 5;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Listening Port";
			// 
			// _portNumber
			// 
			this._portNumber.Location = new System.Drawing.Point(144, 13);
			this._portNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this._portNumber.Name = "_portNumber";
			this._portNumber.Size = new System.Drawing.Size(140, 20);
			this._portNumber.TabIndex = 0;
			this._portNumber.Value = new decimal(new int[] {
            13590,
            0,
            0,
            0});
			// 
			// _localhost
			// 
			this._localhost.AutoSize = true;
			this._localhost.Location = new System.Drawing.Point(144, 40);
			this._localhost.Name = "_localhost";
			this._localhost.Size = new System.Drawing.Size(15, 14);
			this._localhost.TabIndex = 1;
			this._localhost.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Only Local Access";
			// 
			// _customFileLocation
			// 
			this._customFileLocation.AutoSize = true;
			this._customFileLocation.Location = new System.Drawing.Point(144, 60);
			this._customFileLocation.Name = "_customFileLocation";
			this._customFileLocation.Size = new System.Drawing.Size(15, 14);
			this._customFileLocation.TabIndex = 2;
			this._customFileLocation.UseVisualStyleBackColor = true;
			this._customFileLocation.CheckedChanged += new System.EventHandler(this._customFileLocation_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Use files from location:";
			// 
			// FileSelectButton
			// 
			this.FileSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FileSelectButton.Location = new System.Drawing.Point(331, 80);
			this.FileSelectButton.Name = "FileSelectButton";
			this.FileSelectButton.Size = new System.Drawing.Size(34, 20);
			this.FileSelectButton.TabIndex = 13;
			this.FileSelectButton.Text = "•••";
			this.FileSelectButton.UseVisualStyleBackColor = true;
			this.FileSelectButton.Click += new System.EventHandler(this.FileSelectButton_Click);
			// 
			// _filesLocation
			// 
			this._filesLocation.Location = new System.Drawing.Point(53, 80);
			this._filesLocation.Name = "_filesLocation";
			this._filesLocation.Size = new System.Drawing.Size(272, 20);
			this._filesLocation.TabIndex = 12;
			// 
			// PlaceFiles
			// 
			this.PlaceFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.PlaceFiles.Enabled = false;
			this.PlaceFiles.Location = new System.Drawing.Point(290, 106);
			this.PlaceFiles.Name = "PlaceFiles";
			this.PlaceFiles.Size = new System.Drawing.Size(75, 23);
			this.PlaceFiles.TabIndex = 6;
			this.PlaceFiles.Text = "Place Files";
			this.PlaceFiles.UseVisualStyleBackColor = true;
			this.PlaceFiles.Click += new System.EventHandler(this.PlaceFiles_Click);
			// 
			// ServerSettingsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 184);
			this.Controls.Add(this.FileSelectButton);
			this.Controls.Add(this._filesLocation);
			this.Controls.Add(this.label3);
			this.Controls.Add(this._customFileLocation);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._localhost);
			this.Controls.Add(this._portNumber);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PlaceFiles);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OkButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ServerSettingsDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ServerSettings";
			((System.ComponentModel.ISupportInitialize)(this._portNumber)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown _portNumber;
		private System.Windows.Forms.CheckBox _localhost;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox _customFileLocation;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button FileSelectButton;
		internal System.Windows.Forms.TextBox _filesLocation;
		private System.Windows.Forms.Button PlaceFiles;
	}
}