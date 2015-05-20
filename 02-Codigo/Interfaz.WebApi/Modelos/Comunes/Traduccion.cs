using System;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Comunes
{
    [JsonObject("traduccion")]
	public class Traduccion
	{
		[JsonProperty ("cultura")]
		public string Cultura{ get; set; }

        [JsonProperty("tooltip")]
		public string Tooltip{ get; set; }

		[JsonProperty("value")]
		public string Value{ get; set; }

        [JsonConstructor]
		public Traduccion ()
		{

		}

		public Traduccion (string cultura, string tooltip, string value)
		{
			this.Cultura = cultura;
			this.Tooltip = tooltip;
			this.Value = value;
		}
	}
}

