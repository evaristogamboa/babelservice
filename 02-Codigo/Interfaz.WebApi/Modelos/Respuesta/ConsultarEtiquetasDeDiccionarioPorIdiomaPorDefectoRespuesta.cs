using System;
using System.Linq;
using System.Collections.Generic;
using app = Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Interfaz.WebApi.Modelos.Comunes;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta
	{
        [JsonProperty]
		public Etiquetas Etiquetas { get; set; }

        [JsonProperty("relaciones")]
		public Dictionary<string, Guid> Relaciones { get; set; }

		#region constructores

		private ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta(app.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuestaApp)
		{
			this.Relaciones = respuestaApp.Relaciones;
			this.Etiquetas = new Etiquetas();
            this.Etiquetas.ListaEtiquetas = respuestaApp.ListaDeEtiquetas.Cast<Etiqueta>().ToList();
		}

		public static ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta CrearNuevaRespuesta(app.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta respuestaApp)
		{
			return new ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta(respuestaApp);
		}

		#endregion
	}
}