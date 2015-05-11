﻿using System;
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

			config.Routes.MapHttpRoute (
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
