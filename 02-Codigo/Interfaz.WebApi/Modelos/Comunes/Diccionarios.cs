using System.Collections.Generic;
using System.Xml.Serialization;
using Babel.Interfaz.WebApi.Modelos.Comunes;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Comunes
{
	
	public class Diccionarios
	{
		#region propiedades

		[JsonProperty ("diccionarios")]
		public List<Diccionario> ListaDiccionarios{ get; set; }

		#endregion

		#region constructores

        [JsonConstructor]
		public Diccionarios ()
		{
			this.ListaDiccionarios = new List<Diccionario> ();
		}

        [JsonConstructor]
		public Diccionarios (Diccionario diccionario)
		{
			this.ListaDiccionarios = new List<Diccionario> ();
			this.ListaDiccionarios.Add (diccionario);
		}



		#endregion


	}
}
