using System.Collections.Generic;
using System.Xml.Serialization;
using Babel.Interfaz.WebApi.Modelos.Comunes;

namespace Babel.Interfaz.WebApi.Modelos.Comunes
{
	[XmlRoot ("diccionarios")]
	public class Diccionarios
	{
		#region propiedades

		[XmlElement ("diccionario")]
		public List<Diccionario> ListaDiccionarios{ get; set; }

		#endregion

		#region constructores

		public Diccionarios ()
		{
			this.ListaDiccionarios = new List<Diccionario> ();
		}

		public Diccionarios (Diccionario diccionario)
		{
			this.ListaDiccionarios = new List<Diccionario> ();
			this.ListaDiccionarios.Add (diccionario);
		}



		#endregion


	}
}
