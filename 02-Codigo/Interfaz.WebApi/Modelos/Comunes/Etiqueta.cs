using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Comunes
{
    [JsonObject ("etiqueta")]
	public class Etiqueta
	{
		[JsonProperty ("id")]
		public Guid Id { get; set; }

        [JsonProperty("nombre")]
		public string Nombre { get; set; }

        [JsonProperty("activo")]
		public bool Activo { get; set; }

        [JsonProperty("default")]
		public string IdiomaPorDefecto { get; set; }

        [JsonProperty("nombreetiqueta")]
		public string NombreEtiqueta { get ; set ; }

        [JsonProperty("descripcion")]
		public string Descripcion { get; set; }

        [JsonProperty("traducciones")]
		public Traducciones Traducciones{ get; set; }

        [JsonConstructor]
		public Etiqueta ()
		{
			this.Id = Guid.NewGuid ();
			this.Activo = false;
			this.IdiomaPorDefecto = string.Empty;

		}
	}
}