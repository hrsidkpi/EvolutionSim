using EvolutionSimulator.creature.;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvolutionSimulator.creature.dna
{
    public static class DnaReader
    {
        internal static OrganDna GetDna(XmlNode abstraction)
        {
            MainCellDna main = new MainCellDna();
            foreach(XmlNode n in abstraction.ChildNodes)
            {

            }
        }
    }
}
