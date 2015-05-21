using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using app = Babel.Nucleo.Aplicacion.Modelos.Peticion;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;
using dominio = Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
	public class ModificarUnDiccionarioPeticion
	{
        public comunes.Diccionario Diccionario { get; set; }
        public app.ModificarUnDiccionarioPeticion AppDiccionarioPeticion { get; set; }

        private ModificarUnDiccionarioPeticion(HttpRequestMessage peticionHttp)
        {
            this.Diccionario = JsonConvert.DeserializeObject<comunes.Diccionario>(peticionHttp.Content.ReadAsStringAsync().Result);
            this.AppDiccionarioPeticion = app.ModificarUnDiccionarioPeticion.CrearNuevaInstancia(Diccionario.Id,Diccionario.Ambiente);
            this.AppDiccionarioPeticion.Diccionario.Ambiente = Diccionario.Ambiente;

        }
        
        public static ModificarUnDiccionarioPeticion CrearUnaNuevaPeticionDeModificacion(HttpRequestMessage peticionHttp)
        {
            return new ModificarUnDiccionarioPeticion(peticionHttp);
        }

    }
}
