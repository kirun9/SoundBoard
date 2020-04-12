using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.WinApi;
using System.Windows.Forms;
using WMPLib;

namespace SoundBoard
{
	public partial class Form1 : Form
	{
		private List<TreeNode> players = new List<TreeNode>();
		private string Path;
		private HttpListener listener;
		private Thread serverThread;
		private string ActualServerPath = "SoundBoard";
		private string FavoritePath = "!favorite!";
		private TreeView FavoritesList;
		private bool OnlyFavorite = false;

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
			startup();
		}

		public Form1(string path)
		{
			startup();
			openFile(path);
		}

		private void startup()
		{
			InitializeComponent();
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Soundboard");
			if (key != null)
			{
				ServerSettings = new ServerSettings()
				{
					Port = UInt16.Parse(key.GetValue("Port").ToString()),
					FilesLocation = key.GetValue("FilesLocation").ToString(),
					LocalHostOnly = key.GetValue("LocalHostOnly").ToString() == "1" ? true : false,
					CustomFilesLocation = key.GetValue("CustomFilesLocation").ToString() == "1" ? true : false
				};
			}
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
				Path = dialog.FileName;
				Text = System.IO.Path.GetFileNameWithoutExtension(Path);

				List.Nodes.Clear();
				List.Enabled = true;

				var root = List.Nodes.Add("SoundBoard", "SoundBoard");
				root.Tag = new MainNodeTag();
				root.ImageIndex = 0;
				root.SelectedImageIndex = 0;
				List.SelectedNode = List.Nodes[0];

				saveToolStripMenuItem_Click(sender, e);

				actionToolStripMenuItem.Enabled = true;
				saveAsToolStripMenuItem.Enabled = true;
				saveToolStripMenuItem.Enabled = true;
			}
		}

		private void exitToolStripMenuItem_Click(Object sender, EventArgs e)
		{
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
				if (e.Node.Tag is NodeTag nodeTag)
				{
					var url = nodeTag.Path ?? "";
					var _players = players.Where((p) => { return p.FullPath == e.Node.FullPath; });
					if (_players.Count() > 0)
					{
						foreach (var player in _players)
						{
							var t = player.Tag as NodeTag;
							t.Player.controls.stop();
							t.Player.controls.pause();
						}
						e.Node.ImageIndex = e.Node.SelectedImageIndex = 1;
						players.RemoveAll((p) => { return p.FullPath == e.Node.FullPath; });
					}
					else
					{
						var player = new WindowsMediaPlayer();
						player.URL = url;
						player.settings.volume = nodeTag.PlaybackSettings.Volume;
						player.controls.currentPosition = nodeTag.PlaybackSettings.StartPos;
						if (nodeTag.PlaybackSettings.Repeat) player.settings.setMode("loop", true);

						nodeTag.Player = player;
						e.Node.Tag = nodeTag;
						players.Add(e.Node);
						player.PlayStateChange += (state) =>
						{
							if ((WMPPlayState)state == WMPPlayState.wmppsStopped)
							{
								e.Node.ImageIndex = e.Node.SelectedImageIndex = 1;
								nodeTag.Playing = false;
								e.Node.Tag = nodeTag;
							}
							else if ((WMPPlayState)state == WMPPlayState.wmppsPlaying)
							{
								e.Node.ImageIndex = e.Node.SelectedImageIndex = 2;
								nodeTag.Playing = true;
								e.Node.Tag = nodeTag;
							}
						};
						player.controls.play();
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
					n.Tag = new NodeTag() { Path = dialog.FilePath, Playing = false, Favorite = false };
					List.SelectedNode.Expand();
				}
				else
				{
					var n = List.SelectedNode.Parent.Nodes.Add(dialog.SoundName, dialog.SoundName, 1, 1);
					n.Tag = new NodeTag() { Path = dialog.FilePath, Playing = false, Favorite = false };
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
				var favorite = (node.Tag is NodeTag nodeTag ? (nodeTag.Favorite ? "1" : "0") : (node.Tag is DirTag dirTag ? (dirTag.Favorite ? "1" : "0") : "0"));
				var tagType = (node.Tag is MainNodeTag ? "0" : (node.Tag is DirTag ? "1" : (node.Tag is NodeTag ? "2" : "")));
				var path = (node.Tag is NodeTag tag ? tag.Path : "");
				var repeat = (node.Tag as NodeTag)?.PlaybackSettings?.Repeat ?? false ? 1 : 0;
				var volume = (node.Tag as NodeTag)?.PlaybackSettings.Volume ?? 0;
				var startPos = (node.Tag as NodeTag)?.PlaybackSettings.StartPos ?? 0;

				output += $"{tagType}|{favorite}|{node.FullPath}|{path}|{repeat}|{volume}|{startPos}\n";
			}

			var outputArray = Convert.ToBase64String(Encoding.UTF8.GetBytes(output.ToCharArray())).ToCharArray();

			using (GZipStream stream = new GZipStream(File.OpenWrite(Path), CompressionLevel.Optimal)) {
				foreach (var c in outputArray)
				{
					stream.WriteByte((byte)c);
				}
			}
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

		private void openFile(string path)
		{
			Path = path;

			TreeNode AddNode(TreeNode node, string key)
			{
				return node.Nodes.ContainsKey(key) ? node.Nodes[key] : node.Nodes.Add(key, key);
			}

			Text = System.IO.Path.GetFileNameWithoutExtension(Path);

			string readedBase64 = "";
			using (GZipStream stream = new GZipStream(File.OpenRead(Path), CompressionMode.Decompress))
			{
				int i;
				while ((i = stream.ReadByte()) != -1)
				{
					readedBase64 += (char)i;
				}
			}

			var outputArray = Encoding.UTF8.GetChars(Convert.FromBase64String(readedBase64));

			string readed = "";

			foreach (var b in outputArray)
			{
				readed += (char)b;
			}
			readed = readed.Replace("\r\n", "\n").Replace("\r", "\n");

			string[] lines = readed.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

			var root = new TreeNode();
			TreeNode actualNode;

			foreach (var line in lines)
			{
				actualNode = root;
				var splitted = line.Split('|');

				var settings = new PlaybackSettings();

				string type = splitted[0];
				bool favorite = (splitted[1] == "1" ? true : false);
				string tagPath = splitted[2];
				string soundPath = splitted[3];
				if (splitted.Length >= 7)
				{
					settings.Repeat = (splitted[4] == "1" ? true : false);
					settings.Volume = Int32.Parse(splitted[5]);
					settings.StartPos = Double.Parse(splitted[6]);
				}

				foreach (var pathPart in tagPath.Split('\\'))
				{
					actualNode = AddNode(actualNode, pathPart);
				}
				actualNode.Tag = (type == "0" ? new MainNodeTag() :
					(type == "1" ? new DirTag() { Favorite = favorite } :
					(type == "2" ? new NodeTag() { Path = soundPath, Playing = false, Favorite = favorite, PlaybackSettings = settings } : new object())));
				actualNode.ForeColor = favorite ? Color.DarkGreen : Color.Black;
				actualNode.ImageIndex = actualNode.SelectedImageIndex = (type == "2" ? 1 : 0);
			}

			List.Nodes.Clear();
			foreach (TreeNode node in root.Nodes)
			{
				List.Nodes.Add(node);
			}
			actionToolStripMenuItem.Enabled = true;
			List.Enabled = true;
			saveAsToolStripMenuItem.Enabled = true;
			saveToolStripMenuItem.Enabled = true;
			CheckFavorites();
		}

		private void openToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			

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
				openFile(dialog.FileName);
			}
		}

		private void pauseAllSoundsToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			foreach (var player in players)
			{
				var tag = player.Tag as NodeTag;
				tag.Player.controls.pause();
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
							item.Tag = new NodeTag() { Path = filePath, Playing = false, Favorite = false };
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
							item.Tag = new NodeTag() { Path = filePath, Playing = false, Favorite = false };
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
							item.Tag = new NodeTag() { Path = filePath, Playing = false, Favorite = false };
						}
					}
					else
					{
						foreach (var filePath in dialog.FilePaths.Lines)
						{
							var fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
							var item = List.SelectedNode.Parent.Nodes.Add(fileName, fileName, 1, 1);
							item.Tag = new NodeTag() { Path = filePath, Playing = false, Favorite = false };
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
			editToolStripMenuItem.Visible = !(List.SelectedNode.Tag is MainNodeTag);
			editToolStripMenuItem1.Visible = !(List.SelectedNode.Tag is MainNodeTag);
			editToolStripMenuItem.Enabled = !(List.SelectedNode.Tag is MainNodeTag);
			editToolStripMenuItem1.Enabled = !(List.SelectedNode.Tag is MainNodeTag);

			settingsToolStripMenuItem.Visible = (List.SelectedNode.Tag is NodeTag);
			settingsToolStripMenuItem1.Visible = (List.SelectedNode.Tag is NodeTag);
			settingsToolStripMenuItem.Enabled = (List.SelectedNode.Tag is NodeTag);
			settingsToolStripMenuItem1.Enabled = (List.SelectedNode.Tag is NodeTag);

			if (List.SelectedNode.Tag is IFavorite favorite)
			{
				setFavoriteToolStripMenuItem.Visible = true;
				setFavoriteToolStripMenuItem1.Visible = true;
				setFavoriteToolStripMenuItem.Enabled = true;
				setFavoriteToolStripMenuItem1.Enabled = true;
				setFavoriteToolStripMenuItem.Text = favorite.Favorite ? "Remove Favorite" : "Set Favorite";
				setFavoriteToolStripMenuItem1.Text = favorite.Favorite ? "Remove Favorite" : "Set Favorite";
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
			
			void sendDefaultFile(string webFilePath, HttpListenerContext context, StreamWriter writer)
			{
				void sendResponse(MimeType mimeType, string resource)
				{
					context.Response.ContentType = mimeType;
					writer.Write(resource);
					context.Response.StatusCode = 200;
				}

				if (webFilePath == "index.html") sendResponse(MimeType.Html, Properties.Resources.index);
				else if (webFilePath == "navbar.css") sendResponse(MimeType.Css, Properties.Resources.navbar);
				else if (webFilePath == "script.js") sendResponse(MimeType.JavaScript, Properties.Resources.script);
				else if (webFilePath == "soundboard.css") sendResponse(MimeType.Css, Properties.Resources.soundboard);

				else if (webFilePath == "nowPlaying.html") sendResponse(MimeType.Html, Properties.Resources.nowPlaying_html);
				else if (webFilePath == "nowPlaying.css") sendResponse(MimeType.Css, Properties.Resources.nowPlaying_css);
				else if (webFilePath == "nowPlaying.js") sendResponse(MimeType.Css, Properties.Resources.nowPlaying_js);

				else
				{
					context.Response.StatusCode = 404;
				}
			}

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
						context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
						context.Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET");
						string webFilePath = ((context.Request.Url.AbsolutePath.Substring(1) ?? "") == "")? "index.html" : context.Request.Url.AbsolutePath.Substring(1);
						try
						{
							using (var writer = new StreamWriter(context.Response.OutputStream))
							{
								if (webFilePath == "status.html")
								{
									context.Response.ContentType = MimeType.JSON;
									writer.Write(createStatus());
								}
								else if (webFilePath == "playing.html")
								{
									context.Response.ContentType = MimeType.JSON;
									writer.Write(getNowPlaying());
								}
								else if (webFilePath == "change.html")
								{
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
								else
								{
									if (!ServerSettings.CustomFilesLocation)
									{
										sendDefaultFile(webFilePath, context, writer);
									}
									else
									{
										try
										{
											var path = System.IO.Path.Combine(ServerSettings.FilesLocation, webFilePath);
											var ext = System.IO.Path.GetExtension(path);
											var bytes = File.ReadAllBytes(path);
											context.Response.ContentType = MimeType.GetMimeType(ext);
											context.Response.ContentLength64 = bytes.Length;
											writer.BaseStream.Write(bytes, 0, bytes.Length);
										}
										catch (FileNotFoundException)
										{
											sendDefaultFile(webFilePath, context, writer);
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
				catch (HttpListenerException ex) when (ex.ErrorCode == WinError.ERROR_OPERATION_ABORTED)
				{

				}
				catch (Exception) {
				
				}
			});
			serverThread.Start();
			stopToolStripMenuItem.Enabled = true;
			startToolStripMenuItem.Enabled = false;
		}

		private TreeNode CloneNode(TreeNode node)
		{
			TreeNode n = new TreeNode();
			n.Name = node.Name;
			n.Text = node.Text;
			foreach (TreeNode nod in node.Nodes)
			{
				n.Nodes.Add(CloneNode(nod));
			}
			n.Tag = node.Tag;
			n.ForeColor = node.ForeColor;
			n.SelectedImageIndex = node.SelectedImageIndex;
			n.ImageIndex = node.ImageIndex;
			return n;
		}

		private void CheckFavorites()
		{
			FavoritesList = new TreeView();
			FavoritesList.Nodes.Clear();
			TreeNode Favorites = new TreeNode("!favorite!");
			FavoritesList.Nodes.Add(Favorites);
			FavoritesList.TreeViewNodeSorter = new FavoritesComparer();
			Favorites.Tag = new MainNodeTag();

			Favorites.Nodes.Clear();

			void checkNode(TreeNode node, TreeNode parent, bool forceAdd = false)
			{
				if (node.Tag is NodeTag nodeTag)
				{
					if (forceAdd || nodeTag.Favorite)
					{
						var cnode = CloneNode(node);
						(cnode.Tag as NodeTag).FavoritePath = node.FullPath;
						if (nodeTag.Favorite) Favorites.Nodes.Add(CloneNode(cnode));
					}
				}
				if (node.Tag is DirTag dirTag)
				{
					if (forceAdd || dirTag.Favorite)
					{
						var cnode = CloneNode(node);
						(cnode.Tag as DirTag).FavoritePath = node.FullPath;
						parent.Nodes.Add(cnode);
						if (parent != Favorites && !forceAdd) Favorites.Nodes.Add(CloneNode(cnode));

						foreach (TreeNode n in node.Nodes)
						{
							checkNode(n, cnode, true);
						}
					}
					else
					{
						foreach (TreeNode n in node.Nodes)
						{
							checkNode(n, parent, false);
						}
					}
				}
				if (node.Tag is MainNodeTag)
				{
					foreach (TreeNode n in node.Nodes)
					{
						checkNode(n, parent, forceAdd);
					}
				}
			}
			checkNode(List.Nodes[0], Favorites);

		}

		private string getNodeJSON(string path, string title, bool isPlaying, bool isBack, bool isFavorite, bool isDir, string filePath = null)
		{
			var ret = "{";
			ret += "\"id\":\"" + path.Replace("\\", "/") + "\", ";
			ret += "\"title\":\"" + title + "\", ";
			ret += "\"isPlaying\":\"" + isPlaying.ToString().ToLower() + "\", ";
			ret += "\"isBack\":\"" + isBack.ToString().ToLower() + "\", ";
			ret += "\"isFavorite\":\"" + isFavorite.ToString().ToLower() + "\", ";
			ret += "\"isDir\":\"" + isDir.ToString().ToLower() + "\"";
			if (filePath != null) ret += ", \"filePath\":\"" + filePath.Replace("\\", "/") + "\"";
			ret += "}";
			return ret;
		}

		private string getNowPlaying()
		{
			string response = "{";
			response += "\"count\":\"" + players.Count + "\", ";
			response += "\"players\":[" ;

			List<string> entries = players.ConvertAll<string>((node) => {
				return getNodeJSON(node.FullPath, node.Text, ((node.Tag as NodeTag)?.Playing ?? false), false, (node.Tag is IFavorite f ? f.Favorite : false), false, (node.Tag as NodeTag)?.Path);
			});

			var str = string.Join(", ", entries);
			response += str + "]}";
			return response;
		}

		private string createStatus()
		{
			if (OnlyFavorite)
			{
				if (!((FavoritesList?.Nodes?.Count ?? 0) > 0))
				{
					CheckFavorites();
					return createStatus();
				}
				else
				{
					string response = $"{{\"path\":\"{FavoritePath.Replace("\\", "/")}\", \"buttons\":[";

					var anode = FavoritesList.Nodes[0];

					var splitted = FavoritePath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
					foreach (var pathPart in splitted)
					{
						if (pathPart == "!favorite!") continue;
						anode = anode.Nodes[pathPart];
					}

					var prevPath = string.Join("/", splitted.Where((part) => { return part != splitted.Last(); }));
					List<string> entries = new List<string>();
					if (!(anode.Tag is MainNodeTag))
						entries.Add(getNodeJSON(prevPath, "", false, true, false, false));

					foreach (TreeNode node in anode.Nodes)
					{
						entries.Add(getNodeJSON(node.FullPath, node.Text, ((node.Tag as NodeTag)?.Playing ?? false), false, (node.Tag is IFavorite f ? f.Favorite : false), node.Tag is DirTag));
					}
					var str = string.Join(", ", entries);
					response += str + "]}";
					return response;
				}
			}
			else
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
					entries.Add(getNodeJSON(prevPath, "", false, true, false, false));

				foreach (TreeNode node in anode.Nodes)
				{
					entries.Add(getNodeJSON(node.FullPath, node.Text, ((node.Tag as NodeTag)?.Playing ?? false), false, (node.Tag is IFavorite f ? f.Favorite : false), node.Tag is DirTag));
				}

				var str = string.Join(", ", entries);
				response += str + "]}";

				return response;
			}
		}

		private void parseRequest(string query)
		{
			parseRequest(query, OnlyFavorite = query.StartsWith("!favorite!"));
		}

		private void parseRequest(string query, bool favOnly)
		{
			if (FavoritesList == null) CheckFavorites();

			query = query.Replace("/", "\\");
			var anode = favOnly ? FavoritesList.Nodes[0] : List.Nodes[0];
			var splitted = query.Split(new string[]{ "\\" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (var pathPart in splitted)
			{
				if (pathPart == "SoundBoard") continue;
				if (pathPart == "!favorite!") continue;
				anode = anode.Nodes[pathPart];
			}

			if (anode.Tag is DirTag || anode.Tag is MainNodeTag)
			{
				if (favOnly) FavoritePath = anode.FullPath;
				else ActualServerPath = anode.FullPath;
			}
			else if (anode.Tag is NodeTag)
			{
				if (favOnly) parseRequest((anode.Tag as IFavorite).FavoritePath, false);
				else ClickNode(anode);
			}
		}

		private void stopToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			listener?.Stop();
			listener?.Close();

			stopToolStripMenuItem.Enabled = false;
			startToolStripMenuItem.Enabled = true;
		}

		private void setFavoriteToolStripMenuItem1_Click(Object sender, EventArgs e)
		{
			if (List.SelectedNode.Tag is IFavorite favorite)
			{
				favorite.Favorite = !favorite.Favorite;
				List.SelectedNode.ForeColor = favorite.Favorite ? Color.Green : Color.Black;
				CheckFavorites();
			}
		}

		private void actionToolStripMenuItem_DropDownOpening(Object sender, EventArgs e)
		{
			if (List.SelectedNode.Tag is IFavorite favorite)
			{
				setFavoriteToolStripMenuItem.Visible = true;
				setFavoriteToolStripMenuItem1.Visible = true;
				setFavoriteToolStripMenuItem.Enabled = true;
				setFavoriteToolStripMenuItem1.Enabled = true;
				setFavoriteToolStripMenuItem.Text = favorite.Favorite ? "Remove Favorite" : "Set Favorite";
				setFavoriteToolStripMenuItem1.Text = favorite.Favorite ? "Remove Favorite" : "Set Favorite";
			}
		}

		private void Form1_FormClosed(Object sender, FormClosedEventArgs e)
		{
			exitToolStripMenuItem_Click(null, null);
			listener?.Stop();
			listener?.Close();
		}

		private void settingsToolStripMenuItem1_Click(Object sender, EventArgs e)
		{
			PlaybackSettingsDialog dialog = new PlaybackSettingsDialog(List.SelectedNode);
			
			var tag = List.SelectedNode.Tag as NodeTag;

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				tag.PlaybackSettings.Repeat = dialog.LoopPlayback;
				tag.PlaybackSettings.Volume = dialog.Volume;
				tag.PlaybackSettings.StartPos = dialog.StartPos;
				List.SelectedNode.Tag = tag;
			}
		}
	}
}
