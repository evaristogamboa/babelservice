using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo
{
	[XmlRoot ("etiquetas")]
	public class Etiquetas
	{
		[XmlElement ("etiqueta")]
		public List<Etiqueta> etiquetas { get; set; }

		public Etiquetas ()
		{
			this.etiquetas = new List<Etiqueta> ();
		}

		public Etiquetas (Etiqueta etiqueta)
		{
			this.etiquetas = new List<Etiqueta> ();
			this.etiquetas.Add (etiqueta);
		}
	}
}

