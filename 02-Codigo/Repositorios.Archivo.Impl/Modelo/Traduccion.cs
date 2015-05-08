using System;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo
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

