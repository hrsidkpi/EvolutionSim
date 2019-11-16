using EvolutionSimulator.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvolutionSimulator.creature.dna
{


	public class DNA
	{

        public OrganDna dna;


		public static DNA germ = new DNA(Extenstion.LoadAndReturn(
		  @"<MainCell> 
				<brainSpeed>60</brainSpeed>
				<brainChange>0.01</brainChange>
				<size> 10 </size>
				<color> ff0000 </color>
				<Fin>
					<dir> 3.14159265359</dir>
					<size> 12 </size>
					<color> 0000FF </color>
				</Fin>
			</MainCell>
		   "
		));

		public DNA(XmlNode abstraction)
		{
            dna = DnaReader.GetDna(abstraction);
		}

		public DNA Mutate()
		{
			return this;
		}


	}
}
