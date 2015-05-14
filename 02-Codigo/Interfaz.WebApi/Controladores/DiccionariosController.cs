using System.Net.Http;
using System.Web.Http;
using System.Net;
using System;
using System.Net.Http.Headers;
using Babel.Interfaz.WebApi.Modelos;
using Babel.Nucleo.Aplicacion.Fachada;

namespace Babel.Interfaz.WebApi.Controladores
{
    [RoutePrefix("api/diccionarios")]
	public class DiccionariosController : ApiController
	{
        HttpResponseMessage respuesta;
        private readonly IAplicacionMantenimientoDiccionario metodosAppDiccionario;

        public DiccionariosController(IAplicacionMantenimientoDiccionario metodosMantenimientoAplicacion)
        {
            this.metodosAppDiccionario = metodosMantenimientoAplicacion;
        }

        #region metodos Get
		[HttpGet]
		[Route ("")]
		public HttpResponseMessage ObtenerTodosLosDiccionarios ()
		{
            //Solicitar respuesta

			//Preparar respuesta
            respuesta = Request.CreateResponse(HttpStatusCode.OK, new Diccionarios(), new MediaTypeWithQualityHeaderValue("application/json"));
			//Retornar respuesta
			return respuesta;
		}

		[HttpGet]
		[Route ("diccionario/{id}")]
		public HttpResponseMessage ConsultarUnDiccionario (int id)
		{
            //Solicitar contenido


            //preparar respuesta
            respuesta = id == 1 ? Request.CreateResponse(HttpStatusCode.OK, new Diccionario(), new MediaTypeWithQualityHeaderValue("application/json")) : Request.CreateResponse(HttpStatusCode.NotFound, new Diccionario(), new MediaTypeWithQualityHeaderValue("application/json"));
            
            //retornar respuesta
            return respuesta;
		}


        #endregion

        [HttpPut]
        [Route("diccionario")]
        public HttpResponseMessage CrearUndiccionario()
        {
            //Leer Parametros
            var modeloPeticion = this.CrearUndiccionario();
             

            //Solicitar Contenido
            metodosAppDiccionario.CrearUnDiccionario(modeloPeticion);

        }

	}

}

