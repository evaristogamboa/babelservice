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

		public Diccionario (string ambiente)
		{
			this.Id = Guid.NewGuid ();
			this.Ambiente = ambiente;
			this.Etiquetas = new Etiquetas ();
		}

        [JsonConstructor]
		public Diccionario ()
		{
			this.Id = Guid.NewGuid ();
		}

		#endregion
	}
}

