using System;
using System.Xml.Serialization;

namespace Babel.Interfaz.WebApi.Modelos
{
	public class Traduccion
	{
		[XmlAttribute ("cultura")]
		public string Cultura{ get; set; }

		[XmlAttribute ("tooltip")]
		public string Tooltip{ get; set; }

		[XmlText]
		public string Value{ get; set; }

		public Traduccion ()
		{

		}

		public Traduccion (string cultura, string tooltip, string value)
		{
			this.Cultura = cultura;
			this.Tooltip = tooltip;
			this.Value = value;
		}
	}
}

