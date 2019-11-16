using EvolutionSimulator.creature;
using EvolutionSimulator.world;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvolutionSimulator
{
	public class Program
	{

		public const int SIZE = 60;
		public const int WIDTH = 16 * SIZE;
		public const int HEIGHT = 9 * SIZE;

		public static List<Drawable> renders = new List<Drawable>();

		static void Main(string[] args)
		{
			RenderWindow window = new RenderWindow(new VideoMode(WIDTH, HEIGHT), "Evolution Simultaor");
			window.SetActive();

			window.Closed += (s, e) =>
			{
				window.Close();
			};

			World world = new World();
			world.creatures.Add(new Creature(100, 100, DNA.germ));

			Clock updates = new Clock();

			while(window.IsOpen)
			{
				Clear(window);
				window.DispatchEvents();

				world.Render();
				if(updates.ElapsedTime.AsSeconds() > 1/20)
				{
					world.Update();
					updates = new Clock();
				}
				
				foreach(Drawable d in renders)
				{
					window.Draw(d);
				}

				window.Display();
			}
		}

		static void Clear(RenderWindow window)
		{
			window.Clear();
			renders.Clear();
		}
	}
}
