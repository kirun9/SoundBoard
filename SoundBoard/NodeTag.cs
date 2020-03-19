namespace SoundBoard
{
	internal class NodeTag
	{
		public string Path { get; set; }
		public bool Playing { get; set; } = false;
		public NodeTag() { }
		public NodeTag(string path)
		{
			Path = path;
		}
	}
}
