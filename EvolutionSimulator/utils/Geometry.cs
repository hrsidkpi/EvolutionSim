using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.utils
{
	public static class Geometry
	{

		//ax,ay coords of first line point, bx,by of second point, cx,cy of circle center, r is radius.
		public static bool LineCircleHit(int ax, int ay, int bx, int by, int cx, int cy, int r)
		{
			ax -= cx;
			ay -= cy;
			bx -= cx;
			by -= cy;
			int a = ax ^ 2 + ay ^ 2 - r ^ 2;
			int b = 2 * (ax * (bx - ax) + ay * (by - ay));
			int c = (bx - ax) ^ 2 + (by - ay) ^ 2;
			int disc = b ^ 2 - 4 * a * c;
			if (disc <= 0) return false;
			double sqrtdisc = Math.Sqrt(disc);
			double t1 = (-b + sqrtdisc) / (2 * a);
			double t2 = (-b - sqrtdisc) / (2 * a);
			return  (0 < t1 && t1 < 1) || (0 < t2 && t2 < 1);
		}

	}
}
