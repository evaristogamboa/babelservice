using System;
using System.Xml.Serialization;


namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo
{
	public class Traduccion
	{
		[XmlAttribute ("cultura")]
		public string cultura{ get; set; }

		[XmlAttribute ("tooltip")]
		public string tooltip{ get; set; }

		[XmlText]
		public string value{ get; set; }

		public Traduccion ()
		{

		}

		public Traduccion (string cultura, string tooltip, string value)
		{
			this.cultura = cultura;
			this.tooltip = tooltip;
			this.value = value;
		}
	}
}

