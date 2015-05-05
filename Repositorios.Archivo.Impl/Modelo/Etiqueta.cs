using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo
{
	public class Etiqueta
	{
		[XmlAttribute ("id")]
		public Guid id { get; set; }

		[XmlAttribute ("nombre")]
		public string nombre { get; set; }

		[XmlAttribute ("activo")]
		public bool activo { get; set; }

		[XmlAttribute ("default")]
		public string defecto { get; set; }

		[XmlElement ("nombre")]
		public string nombreEtiqueta { get { return this.nombre; } set { this.nombreEtiqueta = value; } }

		[XmlElement ("descripcion")]
		public string descripcion { get; set; }

		[XmlElement ("traducciones")]
		public Traducciones traducciones{ get; set; }


		public Etiqueta ()
		{
			this.id = Guid.NewGuid ();
			this.activo = false;
			this.defecto = string.Empty;

		}
	}
}