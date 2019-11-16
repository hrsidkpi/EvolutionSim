using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.creature.brain
{
	public class Neuron
	{
		private double _Value;
		public double Value { get { return _Value; } set { _Value = value;} }
		public List<Synapse> synapses;

		public Neuron()
		{
			Value = 0.5;
			synapses = new List<Synapse>();
		}

		public void Update()
		{
			if (synapses.Count == 0) return;
			Value = 0;
			foreach(Synapse synapse in synapses)
			{
				synapse.n1.Update();
				Value += synapse.n1.Value * synapse.weight / synapses.Count;
			}
		}

	}
}
