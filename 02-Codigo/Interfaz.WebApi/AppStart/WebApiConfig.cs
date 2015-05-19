using System;
using System.Linq;
using System.Web.Http;

namespace Babel.Interfaz.WebApi.AppStart
{
	public static class WebApiConfig
	{
		public static void Register (HttpConfiguration config)
		{
			// Configuración y servicios de API web

			// Rutas de API web
			config.MapHttpAttributeRoutes ();			
		}
	}
}
