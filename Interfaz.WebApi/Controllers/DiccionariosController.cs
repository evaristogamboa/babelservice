using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Net;
using System;


namespace  Nubise.Hc.Utils.I18n.Babel.Interfaz.WebApi.Controllers
{
	public class DiccionariosController : ApiController
	{
		[HttpGet]
		[Route ("api/diccionarios")]
		public HttpResponseMessage ObtenerTodosLosDiccionarios ()
		{
			HttpResponseMessage response = new HttpResponseMessage (HttpStatusCode.OK);
			return response;
		}

		[HttpGet]
		[Route ("api/diccionario/id/{id}")]
		public HttpResponseMessage ObtenerUnDiccionarioEspecifico (int id)
		{
			HttpResponseMessage response = new HttpResponseMessage ();
			switch (id) {
			case 1:
				{
					response.StatusCode = HttpStatusCode.OK;
					break;
				}
				;
			default:
				{
					response.StatusCode = HttpStatusCode.NotFound;
					break;
				}
			}

			return response;
		}
	}

}

