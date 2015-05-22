using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using app = Babel.Nucleo.Aplicacion.Modelos.Peticion;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
	public class ConsultarUnDiccionarioPeticion
	{

        public comunes.Diccionario Diccionario { get; set; }
        public app.ConsultarUnDiccionarioPeticion AppDiccionarioPeticion { get; set; }

        private ConsultarUnDiccionarioPeticion(HttpRequestMessage peticionHttp, string id)
        {

            Diccionario = JsonConvert.DeserializeObject<comunes.Diccionario>(peticionHttp.Content.ReadAsStringAsync().Result);
            Diccionario.Id = new Guid(id);
            this.AppDiccionarioPeticion = app.ConsultarUnDiccionarioPeticion.CrearNuevaInstancia();

            this.AppDiccionarioPeticion.DiccionarioId = Diccionario.Id;
        }

        public static ConsultarUnDiccionarioPeticion CrearUnaNuevaPeticion(HttpRequestMessage peticionHttp, string id)
        {
            return new ConsultarUnDiccionarioPeticion(peticionHttp, id);
        }
    }
}
