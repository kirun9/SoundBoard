namespace SoundBoard
{
	public class MimeType
	{
		public string Name { get; private set; }
		public string[] Extensions { get; private set; }

		public static readonly MimeType Default = new MimeType() { Name = "text/plain", Extensions = new string[] { ".txt" } };
		public static readonly MimeType Html = new MimeType("text/html", new string[] { ".htm", ".html" });
		public static readonly MimeType Css = new MimeType("text/css", new string[] { ".css" });
		public static readonly MimeType JavaScript = new MimeType("text/javascript", new string[] { ".js" });
		public static readonly MimeType JSON = new MimeType("application/json", new string[] { ".json" });

		public static MimeType[] SupportedMimeTypes =
		{
			Default,
			Html,
			Css,
			JavaScript,
			JSON,
			new MimeType("image/bmp",           new string[] { ".bmp" }),
			new MimeType("image/gif",           new string[] { ".gif" }),
			new MimeType("image/x-icon",        new string[] { ".ico", ".cur" }),
			new MimeType("image/jpeg",          new string[] { ".jpg", ".jpeg", ".jfif", ".pjpeg", ".pjp" }),
			new MimeType("image/png",           new string[] { ".png" }),
			new MimeType("image/svg+xml",       new string[] { ".svg" }),
			new MimeType("image/webp",          new string[] { ".webp" }),
			new MimeType("text/acc",            new string[] { ".acc" }),
			new MimeType("application/ld+json", new string[] { ".jsonld" }),
			new MimeType("application/rtf",     new string[] { ".rtf" }),
			new MimeType("font/ttf",            new string[] { ".ttf" }),
			new MimeType("text/xml",            new string[] { ".xml" }),
		};

		public MimeType(string name, string[] extensions)
		{
			if (name == "" || name == ".")
			{
				throw new System.ArgumentException("Cannot create MimeType without name", nameof(name));
			}
			foreach (var extension in extensions)
			{
				if (extension == "" || extension == ".")
				{
					throw new System.ArgumentException("Cannot create MimeType with empty extension", nameof(extensions));
				}
			}
			for (int i = 0; i < extensions.Length; i++)
			{
				extensions[i] = (!extensions[i].StartsWith(".") ? "." : "") + extensions[i];
			}

			Name = name;
			Extensions = extensions;
		}

		public MimeType(string name, string extension) => new MimeType(name, new string[] { extension });

		private MimeType() { }

		public static MimeType GetMimeType(string extension)
		{
			extension = (!extension.StartsWith(".") ? "." : "") + extension;
			foreach (var mimeType in SupportedMimeTypes)
			{
				foreach (var ext in mimeType.Extensions)
				{
					if (extension == ext) return mimeType;
				}
			}
			return Default;
		}

		public override System.String ToString()
		{
			return Name;
		}

		public static implicit operator string(MimeType type)
		{
			return type.Name;
		}
	}
}
