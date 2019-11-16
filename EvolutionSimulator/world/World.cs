using EvolutionSimulator.creature;
using EvolutionSimulator.utils;
using EvolutionSimulator.world.unorganic;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.world
{
	public class World
	{

		public static World world;

		public List<Creature> creatures = new List<Creature>();
		public List<Sugar> sugar = new List<Sugar>();

		public World()
		{
			world = this;
			Random r = new Random();
			for (int i = 0; i < 100; i++)
				sugar.Add(new Sugar(r.Next(0, Program.WIDTH), r.Next(0, Program.HEIGHT)));
		}

		public List<Sugar> NearSugar(int x, int y, int radius)
		{
			List<Sugar> results = new List<Sugar>();
			foreach (Sugar s in sugar) if (Utils.dist(x, y, s.x, s.y) < radius) results.Add(s);
			return results;
		}

		internal void Render()
		{
            foreach (Creature c in creatures)
			{
				c.Render();
			}
			foreach (Sugar s in sugar) s.Render();
		}

		internal void Update()
		{
			foreach(Creature c in creatures)
			{
				c.Update();
			}
		}
	}
}
