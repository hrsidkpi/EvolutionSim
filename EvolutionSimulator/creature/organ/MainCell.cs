using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EvolutionSimulator.utils;
using EvolutionSimulator.world;
using EvolutionSimulator.world.unorganic;
using SFML.Graphics;
using SFML.System;

namespace EvolutionSimulator.creature.organ
{
	public class MainCell : Organ
	{

		public DNA dna;

		public int brainSpeed;
		public double brainChange;

		private string color;

		public MainCell(double x, double y, Creature creature, DNA dna)
		{
			base.Init(null, creature, int.Parse(dna.abstraction.GetElementsByTagName("size")[0].InnerText), x, y);
			this.dna = dna;

			color = dna.abstraction.GetElementsByTagName("color")[0].InnerText;

			foreach (XmlElement xml in dna.abstraction.ChildNodes)
			{
				double dir;
				int size;
				switch(xml.Name)
				{
					case "MainCell":
						dir = double.Parse(xml.GetElementsByTagName("dir")[0].InnerText);
						size = int.Parse(xml.GetElementsByTagName("size")[0].InnerText);
						Organs.Add(new MainCell((int) (x + size * Math.Cos(dir)), (int) (y + size * Math.Sin(dir)), new DNA(xml), creature));
						break;
					case "Fin":
						dir = double.Parse(xml.GetElementsByTagName("dir")[0].InnerText);
						size = int.Parse(xml.GetElementsByTagName("size")[0].InnerText);
						Organs.Add(new Fin((x + size * Math.Cos(dir)), (y + size * Math.Sin(dir)), new DNA(xml), creature));
						break;
					default:
						break;
				}
			}

			brainSpeed = int.Parse(dna.abstraction.GetElementsByTagName("brainSpeed")[0].InnerText);
			brainChange = double.Parse(dna.abstraction.GetElementsByTagName("brainChange")[0].InnerText);
			creature.iq += 4;

		}

		public override void Update()
		{
			base.Update();
			foreach (Sugar s in World.world.NearSugar((int)x, (int)y, size))
			{
				World.world.sugar.Remove(s);
				creature.energy++;
			}
		}

		public override void Render()
		{
			base.Render();

			int NUCLEUS_SIZE = size/2;

			Program.renders.Add(new CircleShape(size) { Position=new Vector2f((float) x - size, (float) y - size), FillColor = Utils.ColorFromString(color)});
			Program.renders.Add(new CircleShape(NUCLEUS_SIZE) { Position = new Vector2f((float)x-NUCLEUS_SIZE, (float)y-NUCLEUS_SIZE), FillColor = Color.Black });
		}
	}
}
