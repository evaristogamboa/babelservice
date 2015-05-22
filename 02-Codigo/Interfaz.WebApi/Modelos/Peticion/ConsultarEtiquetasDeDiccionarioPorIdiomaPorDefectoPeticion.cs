using System;
using System.Linq;
using System.Net.Http;
using app = Babel.Nucleo.Aplicacion.Modelos;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
	public class ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion
	{

        [JsonProperty]
        public Guid DiccionarioId { get; set; }

        [JsonProperty]
        public string IdiomaPorDefecto { get; set; }

        private ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion ParametrosPeticion{get;  set;} 

        public app.Peticion.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion appEtiquetasDicionarioPeticion { get; set; }

		#region constructores

        [JsonConstructor]
        public ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion()
        {

        }

		private ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion(HttpRequestMessage peticionHttp,string id)
		{
            ParametrosPeticion = new ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion();
            ParametrosPeticion= JsonConvert.DeserializeObject<ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion>(peticionHttp.Content.ReadAsStringAsync().Result);
            this.appEtiquetasDicionarioPeticion.DiccionarioId = new Guid(id);
            this.appEtiquetasDicionarioPeticion.IdiomaPorDefecto = ParametrosPeticion.IdiomaPorDefecto;

		}

		public static ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion CrearNuevaPeticion(HttpRequestMessage peticionHttp, string id)
		{
			return new ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion( peticionHttp,id);
		}

		#endregion
	}
}