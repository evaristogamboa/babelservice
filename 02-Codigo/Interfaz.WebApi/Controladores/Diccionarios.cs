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
        #region propiedades y variables globales
        private readonly app.IAplicacionMantenimientoDiccionario aplicacionMantenimientoDiccionario;

        const string Ambiente = "Desarrollo";
        #endregion

        #region Constructor de la clase
        public Diccionarios(app.IAplicacionMantenimientoDiccionario aplicacionMantenimientoDiccionario) 
        {
            this.aplicacionMantenimientoDiccionario = aplicacionMantenimientoDiccionario;
        }
        #endregion

#region 
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
        public HttpResponseMessage CrearUnDiccionario(HttpRequestMessage peticion)
        {
            //Se instancia el modelo de peticion WebApi como referencia del modelo de peticion de la aplicación 
            var peticionWeb = peticionApi.CrearUnDiccionarioPeticion.CrearUnaNuevaPeticion(peticion);

            // Se llama al metodo crear diccionario de la interfaz IAplicacionMantenimientoDiccionario
            var respuestaApp = this.aplicacionMantenimientoDiccionario.CrearUnDiccionario(peticionWeb.AppDiccionarioPeticion);

            //Si la respuesta donde se llama al modulo de crear diccionario tiene el argumento peticionApp nulo o el metodo devuelve nulo se envia una respuesta http de error
            if(respuestaApp is NullReferenceException || respuestaApp is ArgumentNullException)
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,respuestaApp.Respuesta.ToString());

            //Se solicita cargar el modelo de respuesta del WebApi con la respuesta del metodo fachada de la aplicación
            var respuestaContenido = respuestaApi.CrearUnDiccionarioRespuesta.CrearNuevaRespuesta(respuestaApp);

            //Si la respuesta con el contenido tiene el argumento respuestaApp nulo o el metodo devuelve nulo se envia una respuesta http de error
            if (respuestaContenido is ArgumentNullException || respuestaContenido is NullReferenceException)
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, respuestaApp.Respuesta.ToString());

            //Devolvemos el diccionario creado seteado como respuesta http 
            return Request.CreateResponse(HttpStatusCode.OK, respuestaContenido, new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}

#endregion