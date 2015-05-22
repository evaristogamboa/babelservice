using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Babel.Interfaz.WebApi.Controladores
{
    [RoutePrefix("api/diccionario/{iddiccionario:string}")]
    public class EtiquetasController : ApiController
    {
        

        [Route("etiquetas/")]
        [HttpGet]
        public HttpResponseMessage ConsultarEtiquetasPorIdiomaPorDefecto(HttpRequestMessage httpRequestMessage,[FromUri]string iddionario)
        {
            throw new NotImplementedException();
        }
    }
}
