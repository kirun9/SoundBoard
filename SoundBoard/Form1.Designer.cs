namespace SoundBoard
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importFilesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseAllSoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.openInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.List = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.itemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.nodeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.importFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionToolStripMenuItem,
            this.serverToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(702, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Enabled = false;
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.saveAsToolStripMenuItem.Text = "Save As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// actionToolStripMenuItem
			// 
			this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.pauseAllSoundsToolStripMenuItem});
			this.actionToolStripMenuItem.Enabled = false;
			this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
			this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.actionToolStripMenuItem.Text = "Action";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemToolStripMenuItem,
            this.nodeToolStripMenuItem,
            this.importFilesToolStripMenuItem1});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.addToolStripMenuItem.Text = "Add";
			// 
			// itemToolStripMenuItem
			// 
			this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
			this.itemToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.itemToolStripMenuItem.Text = "Item";
			this.itemToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
			// 
			// nodeToolStripMenuItem
			// 
			this.nodeToolStripMenuItem.Name = "nodeToolStripMenuItem";
			this.nodeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.nodeToolStripMenuItem.Text = "Node";
			this.nodeToolStripMenuItem.Click += new System.EventHandler(this.nodeToolStripMenuItem_Click);
			// 
			// importFilesToolStripMenuItem1
			// 
			this.importFilesToolStripMenuItem1.Name = "importFilesToolStripMenuItem1";
			this.importFilesToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
			this.importFilesToolStripMenuItem1.Text = "Import Files";
			this.importFilesToolStripMenuItem1.Click += new System.EventHandler(this.importFilesToolStripMenuItem1_Click);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
			// 
			// pauseAllSoundsToolStripMenuItem
			// 
			this.pauseAllSoundsToolStripMenuItem.Name = "pauseAllSoundsToolStripMenuItem";
			this.pauseAllSoundsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.pauseAllSoundsToolStripMenuItem.Text = "Pause All Sounds";
			this.pauseAllSoundsToolStripMenuItem.Click += new System.EventHandler(this.pauseAllSoundsToolStripMenuItem_Click);
			// 
			// serverToolStripMenuItem
			// 
			this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripSeparator2,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator3,
            this.openInBrowserToolStripMenuItem});
			this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
			this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.serverToolStripMenuItem.Text = "Server";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.optionsToolStripMenuItem.Text = "Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.startToolStripMenuItem.Text = "Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Enabled = false;
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
			// 
			// openInBrowserToolStripMenuItem
			// 
			this.openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
			this.openInBrowserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openInBrowserToolStripMenuItem.Text = "Open in browser";
			this.openInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem_Click);
			// 
			// List
			// 
			this.List.ContextMenuStrip = this.contextMenuStrip1;
			this.List.Dock = System.Windows.Forms.DockStyle.Fill;
			this.List.Enabled = false;
			this.List.ImageIndex = 0;
			this.List.ImageList = this.imageList1;
			this.List.Location = new System.Drawing.Point(0, 24);
			this.List.Name = "List";
			this.List.SelectedImageIndex = 0;
			this.List.ShowNodeToolTips = true;
			this.List.Size = new System.Drawing.Size(702, 624);
			this.List.TabIndex = 1;
			this.List.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.List_AfterSelect);
			this.List.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.List_NodeMouseClick);
			this.List.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.List_NodeMouseDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.importFilesToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem1});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(137, 92);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// addToolStripMenuItem1
			// 
			this.addToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemToolStripMenuItem1,
            this.nodeToolStripMenuItem1});
			this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
			this.addToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
			this.addToolStripMenuItem1.Text = "Add";
			// 
			// itemToolStripMenuItem1
			// 
			this.itemToolStripMenuItem1.Name = "itemToolStripMenuItem1";
			this.itemToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
			this.itemToolStripMenuItem1.Text = "Item";
			this.itemToolStripMenuItem1.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
			// 
			// nodeToolStripMenuItem1
			// 
			this.nodeToolStripMenuItem1.Name = "nodeToolStripMenuItem1";
			this.nodeToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
			this.nodeToolStripMenuItem1.Text = "Node";
			this.nodeToolStripMenuItem1.Click += new System.EventHandler(this.nodeToolStripMenuItem_Click);
			// 
			// importFilesToolStripMenuItem
			// 
			this.importFilesToolStripMenuItem.Name = "importFilesToolStripMenuItem";
			this.importFilesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.importFilesToolStripMenuItem.Text = "Import Files";
			this.importFilesToolStripMenuItem.Click += new System.EventHandler(this.importFilesToolStripMenuItem1_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.editToolStripMenuItem.Text = "Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// removeToolStripMenuItem1
			// 
			this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
			this.removeToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
			this.removeToolStripMenuItem1.Text = "Remove";
			this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "files-and-folders.png");
			this.imageList1.Images.SetKeyName(1, "play-button.png");
			this.imageList1.Images.SetKeyName(2, "pause-button.png");
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(702, 648);
			this.Controls.Add(this.List);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sound Board";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pauseAllSoundsToolStripMenuItem;
		private System.Windows.Forms.TreeView List;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem nodeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem importFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem importFilesToolStripMenuItem1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem;
	}
}

