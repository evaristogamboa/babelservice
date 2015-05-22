using System.Net.Http;
using app = Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Newtonsoft.Json;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;

namespace Babel.Interfaz.WebApi.Modelos.Peticion
{
	public class CrearUnDiccionarioPeticion 
	{
        
        public comunes.Diccionario Diccionario { get; set; }
        public app.CrearUnDiccionarioPeticion AppDiccionarioPeticion { get; set; }

        public CrearUnDiccionarioPeticion(HttpRequestMessage peticionHttp)
        {
            Diccionario = JsonConvert.DeserializeObject<comunes.Diccionario>(peticionHttp.Content.ReadAsStringAsync().Result);
            AppDiccionarioPeticion = app.CrearUnDiccionarioPeticion.CrearNuevaInstancia(Diccionario.Ambiente);
        }

        public static CrearUnDiccionarioPeticion CrearUnaNuevaPeticion(HttpRequestMessage peticionHttp)
        {
            return new CrearUnDiccionarioPeticion(peticionHttp) ;
        }
        
	}
}
