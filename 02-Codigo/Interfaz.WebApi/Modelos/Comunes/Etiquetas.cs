using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Comunes
{
	[JsonObject ("etiquetas")]
	public class Etiquetas
	{
        [JsonProperty ("etiquetas")]
        public List<Babel.Interfaz.WebApi.Modelos.Comunes.Etiqueta> ListaEtiquetas { get; set; }

        [JsonConstructor]
        public Etiquetas()
        {
            this.ListaEtiquetas = new List<Babel.Interfaz.WebApi.Modelos.Comunes.Etiqueta>();
        }

        public Etiquetas(Babel.Interfaz.WebApi.Modelos.Comunes.Etiqueta etiqueta)
        {
            this.ListaEtiquetas = new List<Babel.Interfaz.WebApi.Modelos.Comunes.Etiqueta>();
            this.ListaEtiquetas.Add(etiqueta);
		}
	}
}

