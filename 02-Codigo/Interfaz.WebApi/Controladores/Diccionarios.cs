using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System;
using Babel.Interfaz.WebApi.Modelos.Respuesta;
using Babel.Interfaz.WebApi.Modelos.Peticion;
using Babel.Nucleo.Aplicacion.Fachada;
using System.Net;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Controladores
{

    [RoutePrefix("api/")]
    
	public class Diccionarios : ApiController
    {
        private IAplicacionMantenimientoDiccionario aplicacionMantenimientoDiccionario;
        
        public Diccionarios(IAplicacionMantenimientoDiccionario aplicacionMantenimientoDiccionario) 
        {
            this.aplicacionMantenimientoDiccionario = aplicacionMantenimientoDiccionario;
        }

        [Route("diccionarios")]
        [HttpGet]
        public HttpResponseMessage ObtenerTodosDiccionarios()
        {
            var respuestaApp = this.aplicacionMantenimientoDiccionario.ConsultarDiccionarios();
            var respuestaContenido = ConsultarDiccionariosRespuesta.CrearNuevaRespuestaConRespuestaDeAplicacion(respuestaApp);
            var respuestaHttp = Request.CreateResponse(HttpStatusCode.OK, respuestaContenido, new MediaTypeWithQualityHeaderValue("application/json"));

          return respuestaHttp;
        }
        [Route("diccionarios")]
        [HttpPost]
        public HttpResponseMessage CrearUnDiccionario(HttpRequestMessage peticion)
        {
            var peticionHttp = JsonConvert.DeserializeObject<Diccionario>(peticion.Content.ReadAsStringAsync().Result);
            var peticionApp = CrearUnDiccionarioPeticion.CrearUnaNuevaPeticion(peticionHttp);
            var respuestaApp = this.aplicacionMantenimientoDiccionario.CrearUnDiccionario(peticionApp.DiccionarioPeticion);

            var respuestaContenido = CrearUnDiccionarioRespuesta.CrearNuevaRespuesta(respuestaApp);
            var respuestaHttp = Request.CreateResponse(HttpStatusCode.OK, respuestaContenido, new MediaTypeWithQualityHeaderValue("application/json"));
            return respuestaHttp;
        }

            
    }
}

