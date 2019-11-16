using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.utils
{
	public static class Utils
	{

		public static double dist(int x1, int y1, int x2, int y2)
		{
			int w = x2 - x1;
			int h = y2 - y1;
			return Math.Sqrt(w * w + h * h);
		}

		public static Color ColorFromString(string s)
		{
			byte[] bytes = StringToBytes(s);
			return new Color(bytes[0], bytes[1], bytes[2]);

		}

		public static byte[] StringToBytes(string hex)
		{
			hex = hex.Trim().ToUpper();
			if (hex.Length % 2 == 1)
				throw new Exception("The binary key cannot have an odd number of digits");

			byte[] arr = new byte[hex.Length >> 1];

			for (int i = 0; i < hex.Length >> 1; ++i)
			{
				arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
			}

			return arr;
		}

		public static int GetHexVal(char hex)
		{
			int val = (int)hex;
			return val - (val < 58 ? 48 : 55);
		}

	}
}
