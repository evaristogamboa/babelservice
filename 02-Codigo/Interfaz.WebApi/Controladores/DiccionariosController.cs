using System.Net.Http;
using System.Web.Http;
using System.Net;
using System;
using System.Net.Http.Headers;
using Babel.Interfaz.WebApi.Modelos;

namespace Babel.Interfaz.WebApi.Controladores
{
    [RoutePrefix("api/diccionarios")]
	public class DiccionariosController : ApiController
	{
        HttpResponseMessage respuesta;

        #region metodos Get
		[HttpGet]
		[Route ("")]
		public HttpResponseMessage ObtenerTodosLosDiccionarios ()
		{
			//Preparar respuesta
            respuesta = Request.CreateResponse(HttpStatusCode.OK, new Diccionarios(), new MediaTypeWithQualityHeaderValue("application/json"));
			//Retornar respuesta
			return respuesta;
		}

		[HttpGet]
		[Route ("diccionario/{id}")]
		public HttpResponseMessage ObtenerUnDiccionarioPorId (int id)
		{

            //preparar respuesta
            respuesta = id == 1 ? Request.CreateResponse(HttpStatusCode.OK, new Diccionario(), new MediaTypeWithQualityHeaderValue("application/json")) : Request.CreateResponse(HttpStatusCode.NotFound, new Diccionario(), new MediaTypeWithQualityHeaderValue("application/json"));
            
            //retornar respuesta
            return respuesta;
		}



        #endregion
	}

}

