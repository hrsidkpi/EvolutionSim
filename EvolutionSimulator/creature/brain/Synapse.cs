using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.creature.brain
{
	public class Synapse
	{

		public Neuron n1, n2;
		public double weight;
		public double lastWeight;

		public Synapse(Neuron n1, Neuron n2, double weight)
		{
			this.n1 = n1;
			this.n2 = n2;
			this.weight = weight;
		}

		public void Revert() {
			weight = lastWeight;
		}

		public void Change(double amount)
		{
			lastWeight = weight;
			weight += amount;
			if (weight < 0) weight = 0;
		}

	}
}
