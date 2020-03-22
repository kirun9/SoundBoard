namespace SoundBoard
{
	internal class NodeTag: IFavorite
	{
		public string Path { get; set; }
		public bool Playing { get; set; } = false;
		public bool Favorite { get; set; }
		public string FavoritePath { get; set; }
		public NodeTag() { }
		public NodeTag(string path)
		{
			Path = path;
		}
	}
}
