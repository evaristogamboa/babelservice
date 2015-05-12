using System;
using System.Linq;
using System.Web.Http;

using Babel.Interfaz.WebApi.AppStart;

namespace Babel.Interfaz.WebApi
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start ()
		{
			GlobalConfiguration.Configure (WebApiConfig.Register);
		}
	}
}
