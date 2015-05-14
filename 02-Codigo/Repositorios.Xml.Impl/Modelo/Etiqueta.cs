using System;
using System.Xml.Serialization;

namespace Babel.Repositorio.Xml.Impl.Modelo
{
	public class Etiqueta
	{
		[XmlAttribute ("id")]
		public Guid Id { get; set; }

		[XmlAttribute ("nombre")]
		public string Nombre { get; set; }

		[XmlAttribute ("activo")]
		public bool Activo { get; set; }

		[XmlAttribute ("default")]
		public string IdiomaPorDefecto { get; set; }

		[XmlElement ("nombre")]
		public string NombreEtiqueta { get ; set ; }

		[XmlElement ("descripcion")]
		public string Descripcion { get; set; }

		[XmlElement ("traducciones")]
		public Traducciones Traducciones{ get; set; }


		public Etiqueta ()
		{
			this.Id = Guid.NewGuid ();
			this.Activo = false;
			this.IdiomaPorDefecto = string.Empty;

		}
	}
}