namespace SoundBoard
{
	partial class ImportFilesDialog
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFilesDialog));
			this.FilePaths = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SelectFiles = new System.Windows.Forms.Button();
			this.NodeName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// FilePaths
			// 
			this.FilePaths.AcceptsReturn = true;
			this.FilePaths.Location = new System.Drawing.Point(88, 10);
			this.FilePaths.Multiline = true;
			this.FilePaths.Name = "FilePaths";
			this.FilePaths.Size = new System.Drawing.Size(237, 98);
			this.FilePaths.TabIndex = 0;
			this.toolTip1.SetToolTip(this.FilePaths, "File paths. Each one in new line");
			this.FilePaths.WordWrap = false;
			this.FilePaths.TextChanged += new System.EventHandler(this.FilePaths_TextChanged);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(88, 114);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(86, 17);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Create Node";
			this.toolTip1.SetToolTip(this.checkBox1, "Identificates if separate node should be created for these files. If not selected" +
        ", files will be inserted in selected node or next to selected item");
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "File Paths";
			// 
			// SelectFiles
			// 
			this.SelectFiles.Location = new System.Drawing.Point(331, 9);
			this.SelectFiles.Name = "SelectFiles";
			this.SelectFiles.Size = new System.Drawing.Size(34, 20);
			this.SelectFiles.TabIndex = 1;
			this.SelectFiles.Text = "•••";
			this.SelectFiles.UseVisualStyleBackColor = true;
			this.SelectFiles.Click += new System.EventHandler(this.SelectFiles_Click);
			// 
			// NodeName
			// 
			this.NodeName.Location = new System.Drawing.Point(88, 138);
			this.NodeName.Name = "NodeName";
			this.NodeName.Size = new System.Drawing.Size(237, 20);
			this.NodeName.TabIndex = 3;
			this.NodeName.Visible = false;
			this.NodeName.TextChanged += new System.EventHandler(this.NodeName_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 141);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Node Name";
			this.label2.Visible = false;
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Enabled = false;
			this.OkButton.Location = new System.Drawing.Point(290, 174);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 4;
			this.OkButton.Text = "OK";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Location = new System.Drawing.Point(209, 174);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 5;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// ImportFilesDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 209);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NodeName);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.SelectFiles);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.FilePaths);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ImportFilesDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Import Files";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button SelectFiles;
		internal System.Windows.Forms.TextBox FilePaths;
		internal System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancelButton;
		internal System.Windows.Forms.TextBox NodeName;
	}
}