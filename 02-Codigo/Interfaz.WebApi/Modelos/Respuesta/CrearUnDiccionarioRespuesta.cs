using System;
using System.Collections.Generic;
using System.Linq;
using app=Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using CollectionJson;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class CrearUnDiccionarioRespuesta
	{
        [JsonProperty(PropertyName = "diccionario")]
		public Diccionario DiccionarioNuevo { get; set; }
        
        [JsonProperty(PropertyName = "relaciones")]
		public List<Link> Relaciones { get; set; }

		#region constructores

		private CrearUnDiccionarioRespuesta(app.CrearUnDiccionarioRespuesta respuestaApp)
		{
            this.DiccionarioNuevo = respuestaApp.DiccionarioNuevo;
            this.Relaciones = new List<Link>();
		}

        public static CrearUnDiccionarioRespuesta CrearNuevaRespuesta(app.CrearUnDiccionarioRespuesta respuestaApp)
		{
			return new CrearUnDiccionarioRespuesta(respuestaApp);
		}

		#endregion
	}
}