using System.Collections.Generic;
using System.Net.Http;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using app = Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Newtonsoft.Json;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;
using dominio = Babel.Nucleo.Dominio.Entidades;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
	public class CrearUnDiccionarioPeticion 
	{
        
        public comunes.Diccionario diccionario { get; set; }
        public app.CrearUnDiccionarioPeticion AppDiccionarioPeticion { get; set; }

        public CrearUnDiccionarioPeticion(HttpRequestMessage peticionHttp)
        {
            diccionario = JsonConvert.DeserializeObject<comunes.Diccionario>(peticionHttp.Content.ReadAsStringAsync().Result);
            AppDiccionarioPeticion = app.CrearUnDiccionarioPeticion.CrearNuevaInstancia(diccionario.Ambiente);
        }

        public static CrearUnDiccionarioPeticion CrearUnaNuevaPeticion(HttpRequestMessage peticionHttp)
        {
            return new CrearUnDiccionarioPeticion(peticionHttp) ;
        }
        
	}
}
