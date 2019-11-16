using EvolutionSimulator.creature.organ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionSimulator.creature.dna
{
    public class MainCellDna : OrganDna
    {

        public double x, y;
        public Creature creature;
        public Organ parent;

        public int brainSpeed;
        public double brainChange;

        private string color;

        public MainCellDna(double x, double y, Creature creature, Organ parent, int brainSpeed, double brainChange, string color, int size, string color);
        {                                                                      

        }                                                                       

        

    }
}
