using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Comunes
{
	[JsonObject ("traducciones")]
	public class Traducciones
	{
        [JsonProperty ("traduccion")]
        public List<Babel.Interfaz.WebApi.Modelos.Comunes.Traduccion> Traducciones1 { get; set; }

        [JsonConstructor]
        public Traducciones()
        {
            this.Traducciones1 = new List<Babel.Interfaz.WebApi.Modelos.Comunes.Traduccion>();
        }

        public Traducciones(Babel.Interfaz.WebApi.Modelos.Comunes.Traduccion traduccion)
        {
            this.Traducciones1 = new List<Babel.Interfaz.WebApi.Modelos.Comunes.Traduccion>();
            this.Traducciones1.Add(traduccion);
		}
	}
}

