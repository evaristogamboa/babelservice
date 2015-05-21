using System;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Comunes
{
    [JsonObject("diccionario")]
	public class Diccionario
	{
		#region propiedades

        [JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty ("ambiente")]
		public string Ambiente{ get; set; }

        [JsonProperty("etiquetas")]
		public Etiquetas Etiquetas;

		#endregion

		#region constructores

        [JsonConstructor]
		public Diccionario ()
		{

		}

		#endregion
	}
}

