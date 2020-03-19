using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WMPLib;


namespace SoundBoard
{
	public partial class Form1 : Form
	{

		private List<WindowsMediaPlayer> players = new List<WindowsMediaPlayer>();
		private string Path = @"C:\Users\Krystian\Desktop\New Sound Board List.sbl";
		private HttpListener listener;
		private Thread serverThread;
		private string ActualServerPath = "SoundBoard";


		private delegate void _ClickDelegate(object sender, TreeNodeMouseClickEventArgs args);

		private void ClickNode(TreeNode node)
		{
			Invoke(new _ClickDelegate(List_NodeMouseDoubleClick), null, new TreeNodeMouseClickEventArgs(node, MouseButtons.Left, 2, 0, 0));
		}



		private ServerSettings ServerSettings { get; set; } = new ServerSettings()
		{
			Port = 13590,
			FilesLocation = "",
			LocalHostOnly = true,
			CustomFilesLocation = false,
		};

		public Form1()
		{
			InitializeComponent();
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Soundboard");
			if (key != null)
			{
				ServerSettings = new ServerSettings()
				{
					Port = UInt16.Parse(key.GetValue("Port").ToString()),
					FilesLocation = key.GetValue("FilesLocation").ToString(),
					LocalHostOnly = key.GetValue("LocalHostOnly").ToString() == "1" ? true : false ,
					CustomFilesLocation = key.GetValue("CustomFilesLocation").ToString() == "1" ? true : false
				};
			}
//#if DEBUG
			actionToolStripMenuItem.Enabled = true;
			List.Enabled = true;
			saveAsToolStripMenuItem.Enabled = true;
			saveToolStripMenuItem.Enabled = true;
//#endif
			var root = List.Nodes.Add("SoundBoard", "SoundBoard");
			root.Tag = new MainNodeTag();
			root.ImageIndex = 0;
			root.SelectedImageIndex = 0;
			List.SelectedNode = List.Nodes[0];
			menuStrip1.Visible = true;
			menuStrip1.Enabled = true;
		}

		private void newToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.AddExtension = true;
			dialog.DefaultExt = "sbl";
			dialog.FileName = "New Sound Board List";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			dialog.OverwritePrompt = true;
			dialog.SupportMultiDottedExtensions = true;
			dialog.Title = "Create new sound board list";
			dialog.ValidateNames = true;
			dialog.Filter = "Sound Board List | *.sbl";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				using (StreamWriter writer = new StreamWriter(dialog.OpenFile())) { };
				Path = dialog.FileName;
				Text = System.IO.Path.GetFileNameWithoutExtension(Path);
				actionToolStripMenuItem.Enabled = true;
				List.Nodes.Clear();
				List.Enabled = true;
				saveAsToolStripMenuItem.Enabled = true;
				saveToolStripMenuItem.Enabled = true;
			}
		}

		private void exitToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			stopToolStripMenuItem_Click(null, null);
			Environment.ExitCode = 0;
			Application.Exit();
		}

		private void nodeToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			NodeDialog dialog = new NodeDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (List.SelectedNode.Tag is DirTag || List.SelectedNode.Tag is MainNodeTag)
				{
					var node = List.SelectedNode.Nodes.Add(dialog.NodeName, dialog.NodeName, 0, 0);
					node.Tag = new DirTag();
					List.SelectedNode.Expand();
				}
				else
				{
					var node = List.SelectedNode.Parent.Nodes.Add(dialog.NodeName, dialog.NodeName, 0, 0);
					node.Tag = new DirTag();
				}
			}
		}

		private void removeToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			if (List.SelectedNode.Tag is MainNodeTag) return;
			if (List.SelectedNode.Tag is NodeTag)
			{
				List.SelectedNode.Remove();
				return;
			}
			if (MessageBox.Show("Do you want to remove main node?", "Node removal confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				List.SelectedNode.Remove();
			}
		}

		private void List_AfterSelect(Object sender, TreeViewEventArgs e)
		{
			removeToolStripMenuItem.Enabled = !(e.Node.Tag is MainNodeTag);
		}

		private void List_NodeMouseDoubleClick(Object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Left) {
				if (e.Node.Tag is NodeTag)
				{
					var url = (e.Node.Tag as NodeTag)?.Path ?? "";
					var _players = players.Where((p) => { return p.URL == url; });
					if (_players.Count() > 0)
					{
						foreach (var player in _players)
						{
							player.controls.stop();
							player.controls.pause();
						}
						e.Node.ImageIndex = e.Node.SelectedImageIndex = 1;
						players.RemoveAll((p) => { return p.URL == url && p.playState == WMPPlayState.wmppsStopped; });
					}
					else
					{
						var player = new WindowsMediaPlayer();
						player.URL = url;
						player.controls.play();
						players.Add(player);
						var tag = e.Node.Tag as NodeTag;
						player.PlayStateChange += (state) =>
						{
							if ((WMPPlayState)state == WMPPlayState.wmppsStopped)
							{
								e.Node.ImageIndex = e.Node.SelectedImageIndex = 1;
								
								tag.Playing = false;
								e.Node.Tag = tag;
							}
						};
						e.Node.ImageIndex = e.Node.SelectedImageIndex = 2;
						tag.Playing = true;
						e.Node.Tag = tag;
					}
				}
			}
		}

		private void itemToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			ItemDialog dialog = new ItemDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (List.SelectedNode.Tag is DirTag || List.SelectedNode.Tag is MainNodeTag)
				{
					var n = List.SelectedNode.Nodes.Add(dialog.SoundName, dialog.SoundName, 1, 1);
					n.Tag = new NodeTag() { Path = dialog.FilePath, Playing = false };
					List.SelectedNode.Expand();
				}
				else
				{
					var n = List.SelectedNode.Parent.Nodes.Add(dialog.SoundName, dialog.SoundName, 1, 1);
					n.Tag = new NodeTag() { Path = dialog.FilePath, Playing = false };
				}
			}
		}

		private void saveToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			List<TreeNode> nodes = new List<TreeNode>();
			void appendNodes(TreeNode mainNode)
			{
				nodes.Add(mainNode);
				foreach (TreeNode node in mainNode.Nodes)
				{
					appendNodes(node);
				}
			}

			foreach (TreeNode node in List.Nodes)
			{
				appendNodes(node);
			}
			string output = "";
			foreach (var node in nodes)
			{
				output += node.FullPath + "|" + (node.Tag is MainNodeTag ? "0" : (node.Tag is DirTag ? "1" : (node.Tag is NodeTag ? "2" : ""))) + "|" + (node.Tag is NodeTag tag ? tag.Path : "") + "\n";
			}
			File.WriteAllText(Path, output);
		}

		private void saveAsToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.AddExtension = true;
			dialog.DefaultExt = "sbl";
			dialog.FileName = "New Sound Board List";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			dialog.OverwritePrompt = true;
			dialog.SupportMultiDottedExtensions = true;
			dialog.Title = "Create new sound board list";
			dialog.ValidateNames = true;
			dialog.Filter = "Sound Board List|*.sbl";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				Path = dialog.FileName;
				Text = System.IO.Path.GetFileNameWithoutExtension(Path);
				saveToolStripMenuItem_Click(sender, e);
			}
		}

		private void openToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			TreeNode AddNode(TreeNode node, string key)
			{
				return node.Nodes.ContainsKey(key) ? node.Nodes[key] : node.Nodes.Add(key, key);
			}

			OpenFileDialog dialog = new OpenFileDialog();
			dialog.DefaultExt = "sbl";
			dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			dialog.Multiselect = false;
			dialog.SupportMultiDottedExtensions = false;
			dialog.Title = "Open Sound Board List";
			dialog.ValidateNames = true;
			dialog.Filter = "Sound Board List|*.sbl|All Files|*.*";
			dialog.FilterIndex = 0;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				Path = dialog.FileName;
				Text = System.IO.Path.GetFileNameWithoutExtension(Path);
				
				string[] lines = File.ReadAllLines(Path);

				var root = new TreeNode();
				TreeNode actualNode;

				foreach (var line in lines)
				{
					actualNode = root;
					var splitted = line.Split('|');
					string tagPath = splitted[0];
					string type = splitted[1];
					string soundPath = splitted[2];

					foreach (var pathPart in tagPath.Split('\\'))
					{
						actualNode = AddNode(actualNode, pathPart);
					}
					actualNode.Tag = (type == "0" ? new MainNodeTag() : (type == "1" ? new DirTag() : (type == "2" ? new NodeTag() { Path = soundPath, Playing = false } : new object())));
					actualNode.ImageIndex = actualNode.SelectedImageIndex = (type == "2" ? 1 : 0);
				}
				List.Nodes.Clear();
				foreach (TreeNode node in root.Nodes)
				{
					List.Nodes.Add(node);
				}
			}
		}

		private void pauseAllSoundsToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			foreach (var player in players)
			{
				player.controls.pause();
			}
			players.Clear();
		}

		private void importFilesToolStripMenuItem1_Click(Object sender, EventArgs e)
		{
			ImportFilesDialog dialog = new ImportFilesDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				if (dialog.checkBox1.Checked)
				{
					if (List.SelectedNode.Tag is DirTag || List.SelectedNode.Tag is MainNodeTag)
					{
						var node = List.SelectedNode.Nodes.Add(dialog.NodeName.Text, dialog.NodeName.Text, 0, 0);
						node.Tag = new DirTag();
						List.SelectedNode.Expand();
						foreach (var filePath in dialog.FilePaths.Lines)
						{
							var fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
							var item = node.Nodes.Add(fileName, fileName, 1, 1);
							item.Tag = new NodeTag() { Path = filePath, Playing = false };
						}
					}
					else
					{
						var node = List.SelectedNode.Parent.Nodes.Add(dialog.NodeName.Text, dialog.NodeName.Text, 0, 0);
						node.Tag = new DirTag();
						List.SelectedNode.Expand();
						foreach (var filePath in dialog.FilePaths.Lines)
						{
							var fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
							var item = node.Nodes.Add(fileName, fileName, 1, 1);
							item.Tag = new NodeTag() { Path = filePath, Playing = false };
						}
					}
				}
				else
				{
					if (List.SelectedNode.Tag is DirTag || List.SelectedNode.Tag is MainNodeTag)
					{
						foreach (var filePath in dialog.FilePaths.Lines)
						{
							var fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
							var item = List.SelectedNode.Nodes.Add(fileName, fileName, 1, 1);
							item.Tag = new NodeTag() { Path = filePath, Playing = false };
						}
					}
					else
					{
						foreach (var filePath in dialog.FilePaths.Lines)
						{
							var fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
							var item = List.SelectedNode.Parent.Nodes.Add(fileName, fileName, 1, 1);
							item.Tag = new NodeTag() { Path = filePath, Playing = false };
						}
					}
				}
			}
		}

		private void List_NodeMouseClick(Object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				List.SelectedNode = e.Node;
			}
		}

		private void editToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			if (List.SelectedNode.Tag is NodeTag node)
			{
				ItemDialog dialog = new ItemDialog();
				dialog.FilePath = node.Path;
				dialog.SoundName = List.SelectedNode.Text;
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					List.SelectedNode.Name = List.SelectedNode.Text = dialog.SoundName;
					node.Path = dialog.FilePath;
				}
			}
			else if (List.SelectedNode.Tag is DirTag)
			{
				NodeDialog dialog = new NodeDialog();
				dialog.NodeName = List.SelectedNode.Text;
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					List.SelectedNode.Name = List.SelectedNode.Text = dialog.NodeName;
				}
			}
			else if (List.SelectedNode.Tag is MainNodeTag)
			{
				MessageBox.Show("You cannot edit main node.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}
		}

		private void contextMenuStrip1_Opening(Object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (List.SelectedNode.Tag is MainNodeTag)
			{
				editToolStripMenuItem.Visible = false;
				editToolStripMenuItem.Enabled = false;
			}
			else
			{
				editToolStripMenuItem.Visible = true;
				editToolStripMenuItem.Enabled = true;
			}
		}

		private void optionsToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			ServerSettingsDialog dialog = new ServerSettingsDialog();
			dialog.Port = ServerSettings.Port;
			dialog.LocalHostOnly = ServerSettings.LocalHostOnly;
			dialog.FilesLocation = ServerSettings.FilesLocation;
			dialog.CustomFilesLocation = ServerSettings.CustomFilesLocation;
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				ServerSettings.Port = dialog.Port;
				ServerSettings.LocalHostOnly = dialog.LocalHostOnly;
				ServerSettings.FilesLocation = dialog.FilesLocation;
				ServerSettings.CustomFilesLocation = dialog.CustomFilesLocation;

				RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Soundboard");
				key.SetValue("Port", ServerSettings.Port, RegistryValueKind.DWord);
				key.SetValue("LocalHostOnly", ServerSettings.LocalHostOnly, RegistryValueKind.DWord);
				key.SetValue("FilesLocation", ServerSettings.FilesLocation, RegistryValueKind.String);
				key.SetValue("CustomFilesLocation", ServerSettings.CustomFilesLocation, RegistryValueKind.DWord);
			}
		}

		private void openInBrowserToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			Process.Start("http://localhost:" + ServerSettings.Port + "/");
		}

		private void startToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			listener = new HttpListener();
			var host = Dns.GetHostEntry(Dns.GetHostName());
			if (!ServerSettings.LocalHostOnly)
			{
				var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
				var principal = new System.Security.Principal.WindowsPrincipal(identity);
				var isAdministrator = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
				if (isAdministrator)
				{
					foreach (var ip in host.AddressList)
					{
						if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
						{
							listener.Prefixes.Add($"http://{ip.ToString()}:{ServerSettings.Port}/");
						}
					}
				}
			}
			listener.Prefixes.Add($"http://localhost:{ServerSettings.Port}/");

			serverThread = new Thread(() => {
				listener.Start();
				try
				{
					while (listener.IsListening)
					{
						var context = listener.GetContext();
						string webFilePath = ((context.Request.Url.AbsolutePath.Substring(1) ?? "") == "")? "index.html" : context.Request.Url.AbsolutePath.Substring(1);
						try
						{
							using (var writer = new StreamWriter(context.Response.OutputStream))
							{
								if (webFilePath == "status.html")
								{
									context.Response.ContentType = MimeType.GetMimeType(".json");
									writer.Write(createStatus());
								}
								else if (webFilePath == "change.html") {
									string requestBody;
									using (Stream reciveStream = context.Request.InputStream)
									{
										using (StreamReader reader = new StreamReader(reciveStream, Encoding.UTF8))
										{
											requestBody = reader.ReadToEnd();
										}
									}
									parseRequest(requestBody);
								}
								else { if (!ServerSettings.CustomFilesLocation)
									{
										if (webFilePath == "index.html")
										{
											context.Response.ContentType = MimeType.Html;
											writer.Write(Properties.Resources.index);
											context.Response.StatusCode = 200;
										}
										else if (webFilePath == "navbar.css")
										{
											context.Response.ContentType = MimeType.Css;
											writer.Write(Properties.Resources.navbar);
											context.Response.StatusCode = 200;
										}
										else if (webFilePath == "script.js")
										{
											context.Response.ContentType = MimeType.JavaScript;
											writer.Write(Properties.Resources.script);
											context.Response.StatusCode = 200;
										}
										else if (webFilePath == "soundboard.css")
										{
											context.Response.ContentType = MimeType.Css;
											writer.Write(Properties.Resources.soundboard);
											context.Response.StatusCode = 200;
										}
										else
										{
											context.Response.StatusCode = 404;
										}
									}
									else
									{
										try
										{
											var path = System.IO.Path.Combine(ServerSettings.FilesLocation, webFilePath);
											var ext = System.IO.Path.GetExtension(path);
											var bytes = File.ReadAllBytes(path);
											writer.Write("Content-Type: " + MimeType.GetMimeType(ext) + "\r\n");
											writer.Write("Content-Length: " + bytes.Length + "\r\n");
											writer.BaseStream.Write(bytes, 0, bytes.Length);
										}
										catch (FileNotFoundException)
										{
											if (webFilePath == "index.html")
											{
												context.Response.ContentType = MimeType.Html;
												writer.Write(Properties.Resources.index);
												context.Response.StatusCode = 200;
											}
											else if (webFilePath == "navbar.css")
											{
												context.Response.ContentType = MimeType.Css;
												writer.Write(Properties.Resources.navbar);
												context.Response.StatusCode = 200;
											}
											else if (webFilePath == "script.js")
											{
												context.Response.ContentType = MimeType.JavaScript;
												writer.Write(Properties.Resources.script);
												context.Response.StatusCode = 200;
											}
											else if (webFilePath == "soundboard.css")
											{
												context.Response.ContentType = MimeType.Css;
												writer.Write(Properties.Resources.soundboard);
												context.Response.StatusCode = 200;
											}
											else
											{
												context.Response.StatusCode = 404;
											}
										}
									}
								}
							}
							context.Response.Close();
						}
						catch (Exception)
						{
							context.Response.StatusCode = 500;
							context.Response.Close();
						}

					}
				}
				catch (HttpListenerException ex) when (ex.ErrorCode == 995)
				{

				}
				catch (Exception) {
				
				}
			});
			serverThread.Start();
			stopToolStripMenuItem.Enabled = true;
			startToolStripMenuItem.Enabled = false;
		}

		private string createStatus()
		{
			string response = $"{{\"path\":\"{ActualServerPath.Replace("\\", "/")}\", \"buttons\":[";

			var anode = List.Nodes[0];
			
			var splitted = ActualServerPath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var pathPart in splitted)
			{
				if (pathPart == "SoundBoard") continue;
				anode = anode.Nodes[pathPart];
			}

			var prevPath = string.Join("/", splitted.Where((part) => { return part != splitted.Last(); }));

			List<string> entries = new List<string>();

			if (!(anode.Tag is MainNodeTag))
				entries.Add($"{{\"id\":\"{prevPath.Replace("\\", "/")}\", \"title\":\"\", \"isPlaying\":\"false\", \"isBack\":\"true\"}}");

			foreach (TreeNode node in anode.Nodes)
			{
				//e.Node.ImageIndex = e.Node.SelectedImageIndex = 1
				entries.Add($"{{\"id\":\"{node.FullPath.Replace("\\", "/")}\", \"title\":\"{node.Text}\", \"isPlaying\":\"{((node.Tag as NodeTag)?.Playing ?? false).ToString().ToLower()}\", \"isBack\":\"false\"}}");
			}

			var str = string.Join(", ", entries);
			response += str + "]}";

			return response;
		}

		private void parseRequest(string query)
		{
			query = query.Replace("/", "\\");
			var anode = List.Nodes[0];
			var splitted = query.Split(new string[]{ "\\" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var pathPart in splitted)
			{
				if (pathPart == "SoundBoard") continue;
				anode = anode.Nodes[pathPart];
			}

			if (anode.Tag is DirTag || anode.Tag is MainNodeTag)
			{
				ActualServerPath = anode.FullPath;
			}
			else if (anode.Tag is NodeTag)
			{
				ClickNode(anode);
			}
		}

		private void stopToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			listener.Abort();
			serverThread.Abort();
			stopToolStripMenuItem.Enabled = false;
			startToolStripMenuItem.Enabled = true;
		}
	}
}
