using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.creature.organ
{
	public abstract class Organ
	{

		public List<Organ> Organs { get; set; } = new List<Organ>();
		public Organ parent;
		public Creature creature;
		public int size;
		public double x, y;

		public virtual void Init(Organ parent, Creature creature, int size, double x, double y)
		{
			this.parent = parent;
			this.creature = creature;
			this.size = size;
			this.x = x;
			this.y = y;

			creature.organs.Add(this);
		}

		public virtual void Init(Organ parent, int size, double x, double y)
		{
			this.parent = parent;
			this.creature = parent.creature;
			this.size = size;
			this.x = x;
			this.y = y;

			creature.organs.Add(this);
		}

		public virtual void Move(double x, double y)
		{
			this.x += x;
			this.y += y;
			foreach (Organ o in Organs) o.Move(x, y);
		}

		public virtual void Render()
		{
			foreach (Organ o in Organs) o.Render();
		}

		public virtual void Update()
		{
			foreach (Organ o in Organs) o.Update();
		}

	}
}
