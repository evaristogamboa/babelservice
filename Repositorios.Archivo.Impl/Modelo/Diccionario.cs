using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo
{
	[XmlRoot ("diccionario")]
	public class Diccionario
	{
		#region propiedades

		[XmlAttribute ("id")]
		public Guid id { get; set; }

		[XmlAttribute ("ambiente")]
		public string ambiente{ get; set; }

		[XmlElement ("etiquetas")]
		public Etiquetas etiquetas;

		#endregion

		#region constructores

		public Diccionario (string ambiente)
		{
			this.id = Guid.NewGuid ();
			this.ambiente = ambiente;
			this.etiquetas = new Etiquetas ();
		}

		public Diccionario ()
		{
			this.id = Guid.NewGuid ();
		}

		public Diccionario (string ambiente, Etiquetas etiquetas)
		{
			this.id = Guid.NewGuid ();
			this.ambiente = ambiente;
			this.etiquetas = etiquetas;
		}

		#endregion
	}
}

