using EvolutionSimulator.utils;
using EvolutionSimulator.world;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvolutionSimulator.creature.organ
{
	public class Eye : InputOrgan
	{

		public Eye(double x, double y, DNA dna, Organ parent)
		{
			base.Init(parent, int.Parse(dna.abstraction.GetElementsByTagName("size")[0].InnerText), x, y);
			amount = 3;

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

		public override double[] GetInput()
		{
			double dir1 = Math.PI - Math.Atan2(creature.mainCell.y - y, creature.mainCell.x - x);
			double dir0 = dir1 - Math.PI / 6;
			double dir2 = dir1 + Math.PI / 6;

			foreach(Creature c in World.world.creatures)
				foreach(Organ o in c.organs)
					if(Geometry.LineCircleHit())


			return new double[] { };
		}
	}
}
