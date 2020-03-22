using System;
using System.Collections;
using System.Windows.Forms;


namespace SoundBoard
{
	internal class FavoritesComparer : IComparer
	{
		public Int32 Compare(object tx, object ty)
		{
			TreeNode x = (TreeNode) tx;
			TreeNode y = (TreeNode) ty;

			if (x.Tag is DirTag && y.Tag is NodeTag) return -1;
			else if (x.Tag is NodeTag && y.Tag is DirTag) return 1;
			else if (x.Tag is NodeTag && y.Tag is NodeTag) return x.Name.CompareTo(y.Name);
			else if (x.Tag is DirTag && y.Tag is DirTag) return x.Name.CompareTo(y.Name);
			else return 0;
		}
	}
}
