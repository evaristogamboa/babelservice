using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Babel.Nucleo.Aplicacion.Fachada;
using ModeloPeticion = Babel.Interfaz.WebApi.Modelos.Peticion;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using Newtonsoft.Json;

namespace Babel.Interfaz.WebApi.Controladores
{
    
    [RoutePrefix("Diccionario/{id}/")]
    public class EtiquetasController : ApiController
    {
        HttpResponseMessage respuesta;
        private readonly IAplicacionMantenimientoDiccionario metodosAppDiccionario;

        [HttpPut]
        [Route("Etiqueta/")]
        public HttpResponseMessage AgregarEtiquetasAUnDiccionario(
            [FromUri]string idDiccionario,
            HttpRequestMessage request)
        {
            //try
            //{
            //    //Deserializar el mensaje de request
               
            //    List<Etiqueta> listaEtiquetas=JsonConvert.DeserializeObject<List<Etiqueta>>(request.Content.ReadAsStringAsync().Result);
            //    // Instanciamos el modelo de peticion
            //    var modeloPeticion = new ModeloPeticion.AgregarEtiquetasAUnDiccionarioPeticion(idDiccionario,

            //    var modeloRespuesta = metodosAppDiccionario.AgregarEtiquetasAUnDiccionario();

            //    respuesta = Request.
                

            //    return respuesta;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}