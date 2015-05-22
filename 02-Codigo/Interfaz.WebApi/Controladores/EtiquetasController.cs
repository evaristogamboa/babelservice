using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using app = Babel.Nucleo.Aplicacion.Fachada;
using peticionApi = Babel.Interfaz.WebApi.Modelos.Peticion;
using respuestaApi = Babel.Interfaz.WebApi.Modelos.Respuesta;

namespace Babel.Interfaz.WebApi.Controladores
{
    [RoutePrefix("api/diccionario/id/{id1}")]
    public class EtiquetasController : ApiController
    {
        #region propiedades y variables globales
        private readonly app.IAplicacionMantenimientoDiccionario aplicacionMantenimientoDiccionario;

        #endregion

        #region Constructor de la clase
        public EtiquetasController(app.IAplicacionMantenimientoDiccionario aplicacionMantenimientoDiccionario) 
        {
            if (aplicacionMantenimientoDiccionario == null)
                throw new ArgumentNullException("aplicacionMantenimientoDiccionario");
            this.aplicacionMantenimientoDiccionario = aplicacionMantenimientoDiccionario;
        }
        #endregion

        #region Metodos Get
        [Route("etiquetas")]
        [HttpGet]
        public HttpResponseMessage ConsultarEtiquetasPorIdiomaPorDefecto(HttpRequestMessage peticionHttp,string id1)
        {
            //Se instancia el modelo de peticion WebApi como referencia del modelo de peticion de la aplicación 
            var peticionWeb = peticionApi.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion.CrearUnaNuevaPeticion(peticionHttp, id1);

            // Se llama al metodo crear diccionario de la interfaz IAplicacionMantenimientoDiccionario
            var respuestaApp = this.aplicacionMantenimientoDiccionario.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto(peticionWeb.appEtiquetasDicionarioPeticion);

            //Se solicita cargar el modelo de respuesta del WebApi con la respuesta del metodo fachada de la aplicación
            var respuestaContenido = respuestaApi.ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta.CrearNuevaRespuesta(respuestaApp);

            return Request.CreateResponse(HttpStatusCode.OK, respuestaContenido, new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion


    }
}
