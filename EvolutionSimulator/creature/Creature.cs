using EvolutionSimulator.creature.brain;
using EvolutionSimulator.creature.dna;
using EvolutionSimulator.creature.organ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.creature
{
	public class Creature
	{

		//The main cell of the creature
		public MainCell mainCell;
		
		//The mount of energy the creature currently has
		public int energy;

		//Amount of Neurons in the brain
		public int iq;
		//The AI that controls the creature
		public Brain brain;
		
		//List of all input organs of the creature (the creature's senses)
		public List<InputOrgan> inputs = new List<InputOrgan>();
		//List of all output organs of the creature (i.e movement, digestion, etc')
		public List<OutputOrgan> outputs = new List<OutputOrgan>();

		//List of all organs
		public List<Organ> organs = new List<Organ>();

		public Creature(int x, int y, DNA dna)
		{
            mainCell = dna.dna.organ;
			brain = new Brain(inputs.Sum(p => p.amount), outputs.Sum(p => p.amount), iq, mainCell.brainSpeed, mainCell.brainChange);
		}

		internal void Update()
		{

			mainCell.Update();
			brain.Update(energy);

			//Get the values the input organs currently get
			List<double> inputs = new List<double>();
			foreach (InputOrgan o in this.inputs) inputs.AddRange(o.GetInput());
			//Push the data to the brain for him to decide what to do
			List<double> actions = brain.Eval(inputs);

			for (int i = 0; i < actions.Count; i++) outputs[i].Activate(actions[i]);

		}

		internal void Render()
		{
			mainCell.Render();
		}

		public void Move(double x, double y) { mainCell.Move(x, y); }
	}
}
