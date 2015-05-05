using System.Collections.Generic;
using System.Xml.Serialization;

namespace Nubise.Hc.Utils.I18n.Babel.Repositorio.Archivo.Impl.Modelo
{
	[XmlRoot ("Diccionarios")]
	public class Diccionarios
	{
		#region propiedades

		[XmlElement ("Etiquetas")]
		public List<Diccionario> etiquetas{ get; set; }

		#endregion


	}
}
