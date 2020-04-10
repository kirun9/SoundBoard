using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard
{
	public class PlaybackSettings
	{
		public int Volume { get; set; } = 100;
		public bool Repeat { get; set; } = false;
		public double StartPos { get; set; } = 0;
	}
}
