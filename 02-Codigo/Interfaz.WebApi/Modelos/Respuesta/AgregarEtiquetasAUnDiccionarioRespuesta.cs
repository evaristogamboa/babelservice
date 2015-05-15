using System;
using System.Collections.Generic;
using System.Linq;
using app=Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using CollectionJson;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
    public class AgregarEtiquetasAUnDiccionarioRespuesta
    {
        public List<Etiqueta> respuesta { get; set; }

        //public List<Link> relaciones { get; set; }

        //public AgregarEtiquetasAUnDiccionarioRespuesta(app.AgregarEtiquetasAUnDiccionarioRespuesta respuestaApp)
        //{
        //    this.respuesta = respuestaApp.ListaDeEtiquetas;
        //    this.relaciones = new List<Link>();
        //}

    }
}