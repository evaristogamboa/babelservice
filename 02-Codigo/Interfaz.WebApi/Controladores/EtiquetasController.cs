using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Babel.Nucleo.Aplicacion.Fachada;
using ModeloPeticion = Babel.Interfaz.WebApi.Modelos.Peticion;

namespace Babel.Interfaz.WebApi.Controladores
{
    
    [RoutePrefix("Diccionario/{Id}/")]
    public class EtiquetasController : ApiController
    {
        HttpResponseMessage respuesta;
        private readonly IAplicacionMantenimientoDiccionario metodosAppDiccionario;

        [HttpPut]
        public HttpResponseMessage AgregarEtiquetasAUnDiccionario(int idDiccionario)
        {
            try
            {
                //Obtenemos el cuerpo de la respuesta http

                // Instanciamos el modelo de peticion
                var modeloPeticion = new ModeloPeticion.AgregarEtiquetasAUnDiccionarioPeticion(idDiccionario);

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}