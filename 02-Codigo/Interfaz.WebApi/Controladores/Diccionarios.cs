using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System;
using respuestaApi = Babel.Interfaz.WebApi.Modelos.Respuesta;
using peticionApi = Babel.Interfaz.WebApi.Modelos.Peticion;
using app = Babel.Nucleo.Aplicacion.Fachada;
using modelosApp = Babel.Nucleo.Aplicacion.Modelos.Peticion;
using System.Net;
using Dominio = Babel.Nucleo.Dominio.Entidades.Diccionario;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Controladores
{
    [RoutePrefix("api/")]
	public class Diccionarios : ApiController
    {
        private readonly app.IAplicacionMantenimientoDiccionario aplicacionMantenimientoDiccionario;

        const string Ambiente = "Desarrollo";
        
        public Diccionarios(app.IAplicacionMantenimientoDiccionario aplicacionMantenimientoDiccionario) 
        {
            this.aplicacionMantenimientoDiccionario = aplicacionMantenimientoDiccionario;
        }

        [Route("diccionarios")]
        [HttpGet]
        public HttpResponseMessage ObtenerTodosDiccionarios()
        {
            var respuestaApp = this.aplicacionMantenimientoDiccionario.ConsultarDiccionarios();
            var respuestaContenido = respuestaApi.ConsultarDiccionariosRespuesta.CrearNuevaRespuestaConRespuestaDeAplicacion(respuestaApp);
            var respuestaHttp = Request.CreateResponse(HttpStatusCode.OK, respuestaContenido, new MediaTypeWithQualityHeaderValue("application/json"));

          return respuestaHttp;
        }
        [Route("diccionarios")]
        [HttpPost]
        public HttpResponseMessage CrearUnDiccionario()
        {

            var peticionApp = peticionApi.CrearUnDiccionarioPeticion.CrearUnaNuevaPeticion(Ambiente);

            var respuestaApp = this.aplicacionMantenimientoDiccionario.CrearUnDiccionario(peticionApp.AppDiccionarioPeticion);

            if(respuestaApp is NullReferenceException || respuestaApp is ArgumentNullException)
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,respuestaApp.Respuesta.ToString());

            var respuestaContenido = respuestaApi.CrearUnDiccionarioRespuesta.CrearNuevaRespuesta(respuestaApp);

            if (respuestaContenido is ArgumentNullException || respuestaContenido is NullReferenceException)
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, respuestaApp.Respuesta.ToString());

            //Devolvemos el diccionario creado seteado como respuesta http 
            return Request.CreateResponse(HttpStatusCode.OK, respuestaContenido, new MediaTypeWithQualityHeaderValue("application/json"));
        }

            
    }
}

