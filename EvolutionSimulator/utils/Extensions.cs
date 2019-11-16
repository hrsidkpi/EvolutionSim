using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EvolutionSimulator.utils
{
	public static class Extenstion
	{
		//Method to create an XmlElement from a string
		public static XmlNode LoadAndReturn(string s)
		{
			XmlDocument x = new XmlDocument();
			x.LoadXml(s);
			return x.DocumentElement;
		}

		//Method to get a child node by id from an XmlNode. This fails if called from a node that is not an element
		public static XmlNodeList GetElementsByTagName(this XmlNode x, string name)
		{
			return (x as XmlElement).GetElementsByTagName(name);
		}

		

	}
}
