using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.creature.organ
{
	public abstract class OutputOrgan : Organ
	{

		public int amount = 1;

		public override void Init(Organ parent, int size, double x, double y)
		{
			base.Init(parent, size, x, y);
			creature.outputs.Add(this);
		}

		public abstract void Activate(double value);

	}
}
