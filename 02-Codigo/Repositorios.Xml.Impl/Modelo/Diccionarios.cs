using System.Collections.Generic;
using System.Xml.Serialization;

namespace Babel.Repositorio.Xml.Impl.Modelo
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
