using EvolutionSimulator.utils;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvolutionSimulator.creature.organ
{
	class Fin : OutputOrgan
	{

		private string color;

		public Fin(double x, double y, Organ parent, DNA dna)
		{
			base.Init(parent, int.Parse(dna.abstraction.GetElementsByTagName("size")[0].InnerText), x, y);
			amount = 1;

			color = dna.abstraction.GetElementsByTagName("color")[0].InnerText;

			foreach (XmlElement xml in dna.abstraction.GetElementsByTagName("MainCell"))
			{
				double dir;
				int size;
				switch (xml.Name)
				{
					case "MainCell":
						dir = double.Parse(xml.GetElementsByTagName("dir")[0].Value);
						size = int.Parse(xml.GetElementsByTagName("size")[0].Value);
						Organs.Add(new MainCell((int)(x + size * Math.Cos(dir)), (int)(y + size * Math.Sin(dir)), creature, new DNA(xml)));
						break;
					case "Fin":
						dir = double.Parse(xml.GetElementsByTagName("dir")[0].Value);
						size = int.Parse(xml.GetElementsByTagName("size")[0].Value);
						Organs.Add(new Fin((int)(x + size * Math.Cos(dir)), (int)(y + size * Math.Sin(dir)), this, new DNA(xml)));
						break;
					default:
						break;
				}
			}

		}

		public override void Activate(double value)
		{
			creature.Move(value * (creature.mainCell.x - x), value * (creature.mainCell.y - y));
		}

		public override void Render()
		{
			base.Render();

			Program.renders.Add(new CircleShape(size) { Position = new Vector2f((float)x - size, (float)y - size), FillColor = Utils.ColorFromString(color) });
		}

	}
}
