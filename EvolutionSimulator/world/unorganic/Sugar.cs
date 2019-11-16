using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.world.unorganic
{
	public class Sugar
	{

		public int x, y;

		public Sugar(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public void Render()
		{
			Program.renders.Add(new CircleShape(4) { Position = new Vector2f(x, y) });
		}

	}
}
