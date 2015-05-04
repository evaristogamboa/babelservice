using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Nubise.Hc.Utils.I18n.Babel.Interfaz.WebApi.AppStart;

namespace Nubise.Hc.Utils.I18n.Babel.Interfaz.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
