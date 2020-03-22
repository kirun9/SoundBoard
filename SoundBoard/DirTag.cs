namespace SoundBoard
{
	internal class DirTag: IFavorite {
		public bool Favorite { get; set; }
		public string FavoritePath { get; set; }
	}

	internal interface IFavorite
	{
		bool Favorite { get; set; }
		string FavoritePath { get; set; }
	}
}
