using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Babel.Repositorio.Xml.Impl.Modelo
{
	[XmlRoot ("traducciones")]
	public class Traducciones
	{
		[XmlElement ("traduccion")]
		public List<Traduccion> traducciones{ get; set; }

		public Traducciones ()
		{
			this.traducciones = new List<Traduccion> ();
		}

		public Traducciones (Traduccion traduccion)
		{
			this.traducciones = new List<Traduccion> ();
			this.traducciones.Add (traduccion);
		}
	}
}

