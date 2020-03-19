namespace SoundBoard
{
	internal class ServerSettings
	{
		public ushort Port { get; set; }
		public string FilesLocation { get; set; }
		public bool LocalHostOnly { get; set; }
		public bool CustomFilesLocation { get; set; }
	}
}
