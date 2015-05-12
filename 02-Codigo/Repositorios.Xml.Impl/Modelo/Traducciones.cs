using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Babel.Repositorio.Xml.Impl.Modelo
{
	[XmlRoot ("traducciones")]
	public class Traducciones
	{
		[XmlElement ("traduccion")]
		public List<Traduccion> Traducciones1{ get; set; }

		public Traducciones ()
		{
			this.Traducciones1 = new List<Traduccion> ();
		}

		public Traducciones (Traduccion traduccion)
		{
			this.Traducciones1 = new List<Traduccion> ();
			this.Traducciones1.Add (traduccion);
		}
	}
}

