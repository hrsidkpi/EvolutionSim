using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.creature.organ
{
	public abstract class InputOrgan : Organ
	{

		public int amount = 1;

		public override void Init(Organ parent, Creature creature, int size, double x, double y)
		{
			base.Init(parent, creature, size, x, y);
			creature.inputs.Add(this);
		}

		public abstract double[] GetInput();
	}
}
