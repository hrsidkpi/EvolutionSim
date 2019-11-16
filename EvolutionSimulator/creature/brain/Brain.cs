using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.creature.brain
{
	public class Brain
	{

		private int deltaTime;
		private double learnChange;

		private List<Neuron> inputs;
		private List<Neuron> outputs;
		private List<Synapse> synapses;

		public Brain(int input, int output, int hidden, int deltaTime, double learnChange)
		{
			this.deltaTime = deltaTime;
			this.learnChange = learnChange;

			inputs = new List<Neuron>();
			outputs = new List<Neuron>();
			synapses = new List<Synapse>();

			int perLayer = (input + output) / 2;
			List<Neuron> layer = new List<Neuron>();
			List<Neuron> last;
			
			for (int i = 0; i < input; i++)
			{
				inputs.Add(new Neuron());
			}
			last = inputs;

			while (hidden > 0)
			{
				layer.Add(new Neuron());
				hidden--;
				if (layer.Count >= perLayer)
					foreach (Neuron n in last) foreach (Neuron n2 in layer)
						{
							Synapse s = new Synapse(n, n2, 0.5);
							n2.synapses.Add(s);
							synapses.Add(s);
						}
				last = layer;
				layer = new List<Neuron>();
			}
			if (layer.Count == 0) layer = last;

			for (int i = 0; i < output; i++)
			{
				outputs.Add(new Neuron());
			}
			foreach (Neuron n in layer) foreach (Neuron n2 in outputs)
			{
				Synapse s = new Synapse(n, n2, 0.5);
				n2.synapses.Add(s);
				synapses.Add(s);
			}


		}

		public List<double> Eval(List<double> inputs)
		{
			for (int i = 0; i < inputs.Count; i++) this.inputs[i].Value = inputs[i];
			foreach(Neuron n in outputs) n.Update();

			List<double> results = new List<double>();
			foreach(Neuron n in outputs) results.Add(n.Value);
			return results;
		}

		int time = 0;
		int lastReward = 0;
		public void Update(int reward)
		{
			int delta = reward - lastReward;

			if (time < deltaTime) { time++; return; }
			time = 0;

			if (delta < 0) foreach (Synapse s in synapses) s.Revert();
			else foreach (Synapse s in synapses) s.Change((new Random().NextDouble() * 2 - 1) * learnChange);
		}

	}
}
