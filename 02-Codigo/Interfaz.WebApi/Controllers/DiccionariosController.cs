using System.Net.Http;
using System.Web.Http;
using System.Net;
using System;
using Babel.Interfaz.WebApi.Models.Response;
using System.Net.Http.Headers;

namespace Babel.Interfaz.WebApi.Controllers
{
    [RoutePrefix("api/diccionarios")]
	public class DiccionariosController : ApiController
	{
		[HttpGet]
		[Route ("")]
		public HttpResponseMessage ObtenerTodosLosDiccionarios ()
		{
			//Obtener contenido respuesta
			var responsemodel = new ObtenerTodosLosDiccionariosResponse ();
			//Preparar respuesta
			HttpResponseMessage response = Request.CreateResponse (HttpStatusCode.OK, responsemodel, new MediaTypeWithQualityHeaderValue ("application/json"));
			//Retornar respuesta
			return response;
		}

		[HttpGet]
		[Route ("id/{id}")]
		public HttpResponseMessage ObtenerUnDiccionarioPorId (int id)
		{
			HttpResponseMessage response;
			var responsemodel = new ObtenerUnDiccionarioEspecificoResponse ();
			response = id == 1 ? Request.CreateResponse (HttpStatusCode.OK, responsemodel, new MediaTypeWithQualityHeaderValue ("application/json")) : Request.CreateResponse (HttpStatusCode.NotFound, responsemodel, new MediaTypeWithQualityHeaderValue ("application/json"));
			return response;
		}
	}

}

